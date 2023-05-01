using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    public UnityAction<GameObject> OnDestroyed;

    //Inspector variables
    [Header("Movement")]
    [SerializeField] private float Force = 10f;


    [Header("Audio")]
    [SerializeField] private AudioClip StartEngine;
    public AudioClip LoopEngine;
    public AudioClip StopEngine;


    //Variables
    private AsteroidSpawner asteroidSpawner;
    private Vector3 Movement;
    private Vector2 MovementAxis;
    private float HoverDirection;
    private GameObject asteroidDir;

    //Components
    private Rigidbody Rigidbody;
    private AudioManager _audioManager;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MovementAxis = Vector2.zero;
        asteroidSpawner = GameObject.Find("GameManager").GetComponent<AsteroidSpawner>();
        asteroidDir = GameObject.Find("AsteroidDir");
        _audioManager = AudioManager.Instance;
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

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(MovementAxis.x, HoverDirection, MovementAxis.y);
        Rigidbody.AddForce(transform.TransformDirection(Direction) * Force, ForceMode.Acceleration);
    }

    private void Update()
    {
        UpdateHitscanRot();
    }

    private void UpdateHitscanRot()
    {
        MeshRenderer[] arrowMeshes = asteroidDir.GetComponentsInChildren<MeshRenderer>();

        if (asteroidSpawner.asteroids.Count > 0)
        {
            foreach (var mesh in arrowMeshes)
            {
                if (!mesh.enabled)
                    mesh.enabled = true;

                Vector3 closestAst = asteroidSpawner.asteroids[0].transform.position;

                foreach (var asteroid in asteroidSpawner.asteroids)
                {
                    if (Vector3.Distance(transform.position, asteroid.transform.position) <
                        Vector3.Distance(transform.position, closestAst))
                        closestAst = asteroid.transform.position;
                }

                asteroidDir.transform.LookAt(closestAst);
            }
        }
        else
        {
            foreach (var mesh in arrowMeshes)
            {
                mesh.enabled = false;
            }
        }
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
        if (_audioManager.GetCurrentSFX().clip != StopEngine &&
            IsVectorCloseToZero(MovementAxis, 0.05f) && IsFloatCloseToZero(HoverDirection, 0.05f))
        {
            _audioManager.StopShipSound();
            _audioManager.Play2DShipSound(StopEngine);
        }
        else if (_audioManager.GetCurrentSFX().clip != LoopEngine)
            _audioManager.PlayAndLoopAudio(LoopEngine);
    }
}