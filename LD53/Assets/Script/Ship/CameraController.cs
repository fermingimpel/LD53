using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float MouseSensitivity;
    
    private Vector2 MouseAxis;
    private float RollDirection;
    
    private Rigidbody Rigidbody;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Rigidbody = GetComponent<Rigidbody>();
    }

    void OnLook(InputValue value)
    {
        MouseAxis = value.Get<Vector2>();
        
        if (InputManager.Instance.isPitchInverted) MouseAxis.y *= -1;
    }

    void OnRoll(InputValue value)
    {
        RollDirection = -value.Get<float>();
    }
    
    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(MouseAxis.y, MouseAxis.x,RollDirection);
        Rigidbody.AddTorque((transform.localRotation * Direction) * MouseSensitivity, ForceMode.Acceleration);
    }
}
