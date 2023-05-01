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
    [SerializeField] private GameObject hitMark;

    //Variables
    private AsteroidSpawner asteroidSpawner;
    private Vector3 Movement;
    private Vector2 MovementAxis;
    private float HoverDirection;
    private GameObject asteroidDir;

    //Components
    private Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MovementAxis = Vector2.zero;
        hitMark = GameObject.Find("HitScan");
        asteroidSpawner = GameObject.Find("GameManager").GetComponent<AsteroidSpawner>();
        asteroidDir = GameObject.Find("AsteroidDir");
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

    private void Update()
    {
        UpdateHitscanRot();
    }

    private void UpdateHitscanRot()
    {
        Vector3 closestAst = asteroidSpawner.asteroids[0].transform.position;

        foreach (var asteroid in asteroidSpawner.asteroids)
        {
            if (Vector3.Distance(transform.position, asteroid.transform.position) < Vector3.Distance(transform.position, closestAst))
                closestAst = asteroid.transform.position;
        }
        
        asteroidDir.transform.LookAt(closestAst);
    }
}