using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private float gravity = 1;
    [SerializeField] GameObject targetHouseLight;
    private bool isCurrent;
    private ShipPackageController shipPackageController;

   void Start()
    {
        shipPackageController = FindObjectOfType<ShipPackageController>();
    }

    public void SetCurrent(bool current)
    {
        isCurrent = current;

        //isCurrent ? targetHouseLight.SetActive(true) : targetHouseLight.SetActive(false);
        if (isCurrent)
        {
            targetHouseLight.SetActive(true);
        }
        else
        {
            targetHouseLight.SetActive(false);
        }

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

    public bool GetIsCurrent()
    {
        return isCurrent;
    }
}