using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    //Inspector variables
    [Header("Movement")]
    [SerializeField] private float Force = 10f;
    [SerializeField] private float TurboForce = 20f;
    [SerializeField] private float turboCooldown = 1f;

    [Header("Audio")] 
    [SerializeField] private AudioClip StartEngine;
    public AudioClip LoopEngine;
    public AudioClip TurboLoopEngine;
    public AudioClip StopEngine;

    [Header("VFX")] 
    [SerializeField] private float turboShakeMagnitude = .4f;
    [SerializeField] private float turboShakeDuration = .15f;
    
    
    //Variables
    private Vector3 Movement;
    private Vector2 MovementAxis;
    private float HoverDirection;
    private bool isTurboOn = false;
    private bool canActivateTurbo = true;
    private bool isInCooldown = false;
    private Animator shipAnimator;

    //Components
    private Rigidbody Rigidbody;
    private AudioManager _audioManager;
    private AudioClip currentEngineSound;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MovementAxis = Vector2.zero;
        _audioManager = AudioManager.Instance;
        shipAnimator = GetComponentInChildren<Animator>();
        currentEngineSound = LoopEngine;
    }

    void OnMove(InputValue value)
    {
        MovementAxis = value.Get<Vector2>();
        PlayThrusterSound();
    }

    void OnHover(InputValue value)
    {
        HoverDirection = value.Get<float>();
        PlayThrusterSound();
    }

    void OnTurbo()
    {
        if (canActivateTurbo && !isInCooldown)
        {
            if (!isTurboOn)
            {
                shipAnimator.SetBool("IsInTurbo", true);
            }
            
            isTurboOn = !isTurboOn;
            PlayThrusterSound();
            if (!isTurboOn)
            {
                shipAnimator.SetBool("IsInTurbo", false);
                StartCoroutine(TurboCooldown());
            }
        }
    }

    void Update()
    {
        if (isTurboOn)
        {
            StartCoroutine(ScreenShakeManager.Instance.ScreenShake(turboShakeDuration, turboShakeMagnitude));
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(Rigidbody.velocity.magnitude);
        float currentForce = isTurboOn ? TurboForce : Force;
        Vector3 Direction = new Vector3(MovementAxis.x, HoverDirection, MovementAxis.y);
        Rigidbody.AddForce(transform.TransformDirection(Direction) * currentForce, ForceMode.Acceleration);
    }

    private bool IsVectorCloseToZero(Vector2 vector, float offset)
    {
        return vector.x >= (-0.05 - offset) && vector.x <= (0.05 + offset) && 
               vector.y >= (-0.05 - offset) && vector.y <= (0.05 + offset);
    }
    
    private bool IsFloatCloseToZero(float value, float offset)
    {
        return value >= (-0.05 - offset) && value <= (0.05 + offset);
    }

    public void PlayThrusterSound()
    {
        currentEngineSound = isTurboOn ? TurboLoopEngine : LoopEngine;
        if (_audioManager.GetCurrentSFX().clip != StopEngine && 
            IsVectorCloseToZero(MovementAxis, 0.05f) && IsFloatCloseToZero(HoverDirection, 0.05f))
        {
            OnTurbo();
            canActivateTurbo = false;
            _audioManager.StopShipSound();
            _audioManager.Play2DShipSound(StopEngine);
        }
        else if (_audioManager.GetCurrentSFX().clip != currentEngineSound)
        {
            _audioManager.PlayAndLoopAudio(currentEngineSound);
            canActivateTurbo = true;
        }
    }

    IEnumerator TurboCooldown()
    {
        isInCooldown = true;
        yield return new WaitForSeconds(turboCooldown);
        isInCooldown = false;
    }
}
