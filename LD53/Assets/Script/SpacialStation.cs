using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacialStation : MonoBehaviour
{
    private ShipPackageController PlayerShip;
    private void Start()
    {
        PlayerShip = FindObjectOfType<ShipPackageController>();
        if (!PlayerShip)
            Debug.LogError("Cant find player ship in spacial station");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == PlayerShip.gameObject)
        {
            if(PlayerShip.GetRemainingDeliveriesLeft() <= 0)
            {
                PlayerShip.CreateNewDeliveries();
            }
            PlayerShip.RegeneratePackages();
        }
    }

}
