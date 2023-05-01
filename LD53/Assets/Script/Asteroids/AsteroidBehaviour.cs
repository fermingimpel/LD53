using System;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidBehaviour : MonoBehaviour
{
    public UnityAction<GameObject> OnDestroyed;

    [SerializeField] private float asteroidSpeed = 10.0f;
    [SerializeField] private float lifeSpan = 10.0f;

    Transform player;
    Rigidbody rb;


    Vector3 direction;

    private void Awake()
    {
        player = GameObject.Find("Ship").transform;    
        rb = GetComponentInChildren<Rigidbody>();
        
        direction = (transform.position - player.position).normalized;

        Destroy(gameObject, lifeSpan);
    }

    void FixedUpdate()
    {
        rb.AddForce(-direction * asteroidSpeed);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(gameObject);
    }
}
