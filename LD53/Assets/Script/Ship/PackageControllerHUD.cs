using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageControllerHUD : MonoBehaviour
{
    [SerializeField] private GameObject outOfDeliveries;
    [SerializeField] private GameObject outOfPackages;

    private void Start()
    {
        outOfDeliveries.SetActive(false);
        outOfPackages.SetActive(false);
    }

    public void ToggleOutOfDeliveries()
    {
        outOfDeliveries.SetActive(!outOfDeliveries.activeSelf);
    }

    public void ToggleOutOfPackages()
    {
        outOfPackages.SetActive(!outOfPackages.activeSelf);
    }

}
