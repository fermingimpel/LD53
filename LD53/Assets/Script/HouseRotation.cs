using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HouseRotation : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private float rotationX;
    private float rotationY;
    private float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
        rotationX = Random.Range(minSpeed, maxSpeed);
        rotationY = Random.Range(minSpeed, maxSpeed);
        rotationZ = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationX * Time.deltaTime, rotationY * Time.deltaTime, rotationZ * Time.deltaTime, Space.Self);
    }
}
