using UnityEngine;


public class PackageThrower : MonoBehaviour
{
    [SerializeField] private Transform packageSpawn;
    [SerializeField] private Package packageToThrow;
    [SerializeField] private float minTimeFirePressedToThrow = 0.5f;
    [SerializeField] private float packageForceCharge = 500.0f;
    [SerializeField] private float initialForceCharge = 100.0f;
    [SerializeField] private float maxForceCharge = 3000.0f;

    private float timeFirePressed = 0.0f;
    private bool chargingPackageForce = false;
    private float forceCharge;
    private ShipPackageController shipPackageController;

    void Awake()
    {
        shipPackageController = GetComponent<ShipPackageController>();
    }

    void Update()
    {
       if(chargingPackageForce)
        {
            timeFirePressed += Time.deltaTime;
            forceCharge += packageForceCharge * Time.deltaTime;
            if (forceCharge >= maxForceCharge)
                forceCharge = maxForceCharge;
        }
    }

    void OnFire()
    {
       chargingPackageForce = !chargingPackageForce;

        if (chargingPackageForce)
        {
            timeFirePressed = 0.0f;
            forceCharge = initialForceCharge;
        }
        else
        {
            if (packageToThrow && packageSpawn)
            {
                if (shipPackageController.GetRemainingPackages() > 0 && timeFirePressed >= minTimeFirePressedToThrow)
                {
                    Package instantiatedPackage = Instantiate(packageToThrow, packageSpawn.position, Quaternion.identity);

                    instantiatedPackage.transform.rotation = transform.rotation;
                    instantiatedPackage.GetComponent<Rigidbody>().AddForce(transform.forward * forceCharge);

                    shipPackageController.PackageThrowed();
                }
            }
            else
                Debug.LogError("Package is not assigned in PackageThrower class");
        }
        
    }

}
