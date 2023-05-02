using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] GameObject targetHouseLight;
    private bool isCurrent;
    private ShipPackageController shipPackageController;

    public static UnityAction<GameObject> houseNoMore;

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

            houseNoMore?.Invoke(gameObject);
        }
    }

    public bool GetIsCurrent()
    {
        return isCurrent;
    }
}