using System;
using UnityEngine;
using UnityEngine.Events;

public class Package : MonoBehaviour
{
    [SerializeField] private float packageLifeSpan = 5.0f;
    [SerializeField] private float maxPackageSpeed = 5.0f;
    [SerializeField] private float weight = 1;

    public Vector3 orbitCenter = Vector3.zero;
    public bool inOrbit = false;

    public Rigidbody Rb { get; private set; }

    void Start()
    {
        Rb = GetComponent<Rigidbody>();

        Destroy(gameObject, packageLifeSpan);
    }

    private void FixedUpdate()
    {
        if (!inOrbit)
            return;

        Rb.velocity = Vector3.ClampMagnitude(Rb.velocity, maxPackageSpeed);
        Rb.AddForce(weight * (orbitCenter - transform.position), ForceMode.Acceleration);
    }

    public void PackageDelivered()
    {
        Destroy(gameObject, 2.0f);
    }
}
