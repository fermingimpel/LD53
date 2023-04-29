using UnityEngine;


public class PackageThrower : MonoBehaviour
{
    [SerializeField] private Transform packageSpawn;
    [SerializeField] private Package packageToThrow;
    [SerializeField] private float timeBetweenThrow = 1.0f;
    [SerializeField] private float packageForceCharge = 500.0f;
    [SerializeField] private float initialForceCharge = 100.0f;
    [SerializeField] private float maxForceCharge = 3000.0f;

    private bool chargingPackageForce = false;
    private float forceCharge;

    void Update()
    {
       if(chargingPackageForce)
        {
            forceCharge += packageForceCharge * Time.deltaTime;
            if (forceCharge >= maxForceCharge)
                forceCharge = maxForceCharge;
        }
    }

    void OnFire()
    {
       chargingPackageForce = !chargingPackageForce;

        if (chargingPackageForce)
            forceCharge = initialForceCharge;
        else
        {
            if (packageToThrow && packageSpawn)
            {
                Package instantiatedPackage = Instantiate(packageToThrow, packageSpawn.position, Quaternion.identity);

                instantiatedPackage.transform.rotation = transform.rotation;
                instantiatedPackage.GetComponent<Rigidbody>().AddForce(transform.forward * forceCharge);
            }
            else
                Debug.LogError("Package is not assigned in PackageThrower class");
        }
        
    }

}
