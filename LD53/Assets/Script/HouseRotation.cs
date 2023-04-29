using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HouseRotation : MonoBehaviour
{
    private float rotationX;
    private float rotationY;
    private float rotationZ;

    // Start is called before the first frame update
    void Start()
    {
        rotationX = Random.Range(1.0f, 20.0f);
        rotationY = Random.Range(1.0f, 20.0f);
        rotationZ = Random.Range(1.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationX * Time.deltaTime, rotationY * Time.deltaTime, rotationZ * Time.deltaTime, Space.Self);
    }
}
