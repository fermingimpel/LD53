using UnityEngine;


public class PackageThrower : MonoBehaviour
{
    [Header("Package Data")]
    [SerializeField] private Transform packageSpawn;
    [SerializeField] private Package packageToThrow;
    [SerializeField] private float minPowerToThrow = 500.0f;
    [SerializeField] private float packageForceCharge = 500.0f;
    [SerializeField] private float initialForceCharge = 100.0f;
    [SerializeField] private float maxForceCharge = 3000.0f;
    [Header("Audio")] 
    [SerializeField] private AudioClip ShootAudio;

    private bool chargingPackageForce = false;
    private float forceCharge;
    private ShipPackageController shipPackageController;
    private PlayerHUD playerHUD;

    void Awake()
    {
        shipPackageController = GetComponent<ShipPackageController>();
        playerHUD = GetComponent<PlayerHUD>();
        playerHUD.SetPowerBarEnabled(false);
    }

    void Update()
    {
       if(chargingPackageForce)
        {
            forceCharge += packageForceCharge * Time.deltaTime;
            if (forceCharge >= maxForceCharge)
                forceCharge = maxForceCharge;

            playerHUD.SetPowerImageValue(forceCharge/maxForceCharge, minPowerToThrow/maxForceCharge);
        }
    }

    void OnFire()
    {
       chargingPackageForce = !chargingPackageForce;

        if (chargingPackageForce)
        {
            forceCharge = initialForceCharge;
            playerHUD.SetPowerBarEnabled(true);
            playerHUD.SetPowerImageValue(0, minPowerToThrow / maxForceCharge);
        }
        else
        {
            if (packageToThrow && packageSpawn)
            {
                if (shipPackageController.GetRemainingPackages() > 0 && forceCharge >= minPowerToThrow)
                {
                    Package instantiatedPackage = Instantiate(packageToThrow, packageSpawn.position, Quaternion.identity);

                    instantiatedPackage.transform.rotation = transform.rotation;
                    instantiatedPackage.GetComponent<Rigidbody>().AddForce(transform.forward * forceCharge);
                    
                    if(ShootAudio)
                        AudioManager.Instance.Play2DSound(ShootAudio);

                    shipPackageController.PackageThrowed();
                    playerHUD.SetPowerBarEnabled(false);
                }
            }
            else
                Debug.LogError("Package is not assigned in PackageThrower class");
        }
        
    }

}
