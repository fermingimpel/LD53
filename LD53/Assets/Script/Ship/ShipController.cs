using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    //Inspector variables
    [Header("Movement")]
    [SerializeField] private float Force = 10f;
    
    //Variables
    private Vector3 Movement;
    private Vector2 MovementAxis;
    private float HoverDirection;

    //Components
    private Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MovementAxis = Vector2.zero;
    }

    void OnMove(InputValue value)
    {
        MovementAxis = value.Get<Vector2>();
    }

    void OnHover(InputValue value)
    {
        HoverDirection = value.Get<float>();
    }

    private void FixedUpdate()
    {
        Vector3 Direction = new Vector3(MovementAxis.x, HoverDirection, MovementAxis.y);
        Rigidbody.AddForce(transform.TransformDirection(Direction) * Force, ForceMode.Acceleration);
    }
}
