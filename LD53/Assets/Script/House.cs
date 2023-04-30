using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private float gravity = 1;
    private bool isCurrent;
    private ShipPackageController shipPackageController;

    private Vector3 baseScale;
   void Start()
    {
        shipPackageController = FindObjectOfType<ShipPackageController>();
        baseScale = transform.localScale;
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