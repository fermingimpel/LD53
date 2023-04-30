using System;
using UnityEngine;
using UnityEngine.Events;

public class Package : MonoBehaviour
{
    [SerializeField] private float packageLifeSpan = 5.0f;
    [SerializeField] private float maxPackageSpeed = 5.0f;
    [SerializeField] private float weight = 1;

    public static UnityAction<GameObject> onPackageDestroyed;
    public Vector3 orbitCenter = Vector3.zero;
    public bool inOrbit = false;


    public Rigidbody Rb { get; private set; }

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Debug.Log("Puede ser PAAAAAAAAAAAAA");
        Debug.Log("ANASHEEEEEEEEEEEEEEEEEEEEE");

        Destroy(gameObject, packageLifeSpan);
    }

    private void FixedUpdate()
    {
        Rb.velocity = Vector3.ClampMagnitude(Rb.velocity, maxPackageSpeed);

        if (!inOrbit)
            return;

        Rb.AddForce(weight * (orbitCenter - transform.position), ForceMode.Acceleration);
    }

    private void OnDestroy()
    {
        onPackageDestroyed?.Invoke(gameObject);
    }
}
