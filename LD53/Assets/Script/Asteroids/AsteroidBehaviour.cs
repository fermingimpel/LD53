using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidBehaviour : MonoBehaviour
{
    public Action OnDestroyed;

    [SerializeField] float asteroidSpeed;

    Transform player;
    Rigidbody rb;


    Vector3 direction;

    private void Awake()
    {
        player = GameObject.Find("Ship").transform;    
        rb = GetComponentInChildren<Rigidbody>();
        
        direction = (transform.position - player.position).normalized;


        Destroy(gameObject, 10.0f);
    }

    void FixedUpdate()
    {
        rb.AddForce(-direction * asteroidSpeed);
    }

    private void OnDestroy()
    {
        OnDestroyed.Invoke();
    }
}
