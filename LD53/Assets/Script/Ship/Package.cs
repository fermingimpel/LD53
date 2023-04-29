using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    [SerializeField] private float packageLifeSpan = 5.0f;

    void Start()
    {
        Debug.Log("ANASHEEEEEEEEEEEEEEEEEEEEE");
        Debug.Log("puede ser PAAAAAAAAAAAAA");

        Destroy(gameObject, packageLifeSpan);
    }
}
