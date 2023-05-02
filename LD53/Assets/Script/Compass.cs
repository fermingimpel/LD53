using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private GameObject compass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        compass.transform.position = transform.position;
    }

    void OnDrawGizmos()
    {
        compass.transform.position = transform.position;
    }
}
