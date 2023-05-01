using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private bool isCurrent;
    private ShipPackageController shipPackageController;

   void Start()
    {
        shipPackageController = FindObjectOfType<ShipPackageController>();
    }

    public void SetCurrent(bool current)
    {
        isCurrent = current;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Package") && isCurrent)
        {
            other.gameObject.GetComponent<Package>().inOrbit = true;
            other.gameObject.GetComponent<Package>().orbitCenter = transform.position;
            SetCurrent(false);
            shipPackageController.PackageDelivered();
        }
    }
}