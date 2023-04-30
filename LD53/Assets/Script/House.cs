using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private float gravity = 1;
    private bool isCurrent;
    private List<GameObject> packages;

    private void Start()
    {
        Package.onPackageDestroyed += OnPackageDestroy;
        packages = new List<GameObject>();
    }

    public void SetCurrent(bool current)
    {
        isCurrent = current;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package"))
        {
            if (packages.Count <= 0)
            {
                packages.Add(other.gameObject);
                other.gameObject.GetComponent<Package>().inOrbit = true;
                other.gameObject.GetComponent<Package>().orbitCenter = transform.position;
                return;
            }

            for (int i = 0; i < packages.Count; i++)
            {
                if (packages[i] != other.gameObject)
                {
                    packages.Add(other.gameObject);
                    other.gameObject.GetComponent<Package>().inOrbit = true;
                    other.gameObject.GetComponent<Package>().orbitCenter = transform.position;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < packages.Count; i++)
        {
            if (packages[i] == other.gameObject)
            {
                other.gameObject.GetComponent<Package>().inOrbit = true;
                packages.Remove(other.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Package.onPackageDestroyed -= OnPackageDestroy;
    }

    private void OnPackageDestroy(GameObject package)
    {
        for (int i = 0; i < packages.Count; i++)
        {
            if (packages[i] == package)
            {
                package.GetComponent<Package>().inOrbit = true;
                packages.Remove(package);
            }
        }
    }
}