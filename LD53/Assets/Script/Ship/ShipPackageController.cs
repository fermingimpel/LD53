using UnityEngine;

public class ShipPackageController : MonoBehaviour
{
    [SerializeField] private int maxNumOfPackages = 3;
    [SerializeField] private int maxNumOfDeliveries = 3;
    [SerializeField] private float packageDeliveredExtraTime = 15.0f;

    int packagesDelivered = 0;

    private Level levelManager;
    private PlayerHUD playerHUD;
    private PackageControllerHUD packageHUD;

    int remainingDeliveriesLeft;
    int remainingPackagesLeft;

    private GameManager gameManager;
    void Start()
    {
        remainingPackagesLeft = maxNumOfPackages;
        remainingDeliveriesLeft = maxNumOfDeliveries;

        levelManager = FindObjectOfType<Level>();
        playerHUD = GetComponent<PlayerHUD>();
        packageHUD = GetComponent<PackageControllerHUD>();

        playerHUD.SetPackagesRemaining(remainingPackagesLeft);

        gameManager = FindObjectOfType<GameManager>();
    }

    public void PackageDelivered()
    {
        packagesDelivered++;
        remainingDeliveriesLeft--;
        if(remainingDeliveriesLeft <= 0)
        {
            remainingDeliveriesLeft = 0;

            packageHUD.ToggleOutOfDeliveries();
        }
        gameManager.AddTimeRemaining(packageDeliveredExtraTime);
    }

    public void CreateNewDeliveries()
    {
        packageHUD.ToggleOutOfDeliveries();

        remainingDeliveriesLeft = maxNumOfDeliveries;
        levelManager.ChangeHousesToDelivery();
    }

    public void RegeneratePackages()
    {
        if (remainingPackagesLeft <= 0)
            packageHUD.ToggleOutOfPackages();

        remainingPackagesLeft = maxNumOfPackages;
        playerHUD.SetPackagesRemaining(remainingPackagesLeft);
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
        if (remainingPackagesLeft <= 0)
        {
            Debug.Log("HOLA");
            remainingPackagesLeft = 0;
            packageHUD.ToggleOutOfPackages();
        }
        playerHUD.SetPackagesRemaining(remainingPackagesLeft);
    }

    public int GetMaxNumOfDeliveries()
    {
        return maxNumOfDeliveries;
    }

    public int GetPackagesDelivered()
    {
        return packagesDelivered;
    }
}
