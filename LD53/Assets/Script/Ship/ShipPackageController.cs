using UnityEngine;

public class ShipPackageController : MonoBehaviour
{
    [SerializeField] private int maxNumOfPackages = 3;
    [SerializeField] private int maxNumOfDeliveries = 3;

    private Level levelManager;

    int remainingDeliveriesLeft;
    int remainingPackagesLeft;
    void Start()
    {
        remainingPackagesLeft = maxNumOfPackages;
        remainingDeliveriesLeft = maxNumOfDeliveries;

        levelManager = FindObjectOfType<Level>();
    }

    public void PackageDelivered()
    {
        remainingDeliveriesLeft--;
        if(remainingDeliveriesLeft <= 0)
        {
            remainingDeliveriesLeft = 0;
        }
    }

    public void CreateNewDeliveries()
    {
        remainingDeliveriesLeft = maxNumOfDeliveries;
        levelManager.ChangeHousesToDelivery();
    }

    public void RegeneratePackages()
    {
        remainingPackagesLeft = maxNumOfPackages;
    }

    public int GetRemainingDeliveriesLeft()
    {
        return remainingDeliveriesLeft;
    }

    public int GetRemainingPackages()
    {
        return remainingPackagesLeft;
    }

    public void PackageThrowed()
    {
        remainingPackagesLeft--;
        if(remainingPackagesLeft <= 0)
            remainingPackagesLeft = 0; 
    }

    public int GetMaxNumOfDeliveries()
    {
        return maxNumOfDeliveries;
    }
}
