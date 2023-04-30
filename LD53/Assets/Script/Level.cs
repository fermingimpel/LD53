using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int houseQty = 18;
    [SerializeField] private List<GameObject> mapPrefabs;

    private CustomGrid grid;
    private List<GameObject> spawnedBuildings;
    private Queue<GameObject> currentHouses;
    private ShipPackageController shipPackageController;

    // Start is called before the first frame update
    private void Start()
    {
        shipPackageController = FindObjectOfType<ShipPackageController>();
        grid = GetComponent<CustomGrid>();
        spawnedBuildings = new List<GameObject>();
        SpawnHouses();
    }

    void SpawnHouses()
    {
        for (int i = 0; i < houseQty; i++)
        {
            spawnedBuildings.Add(Instantiate(mapPrefabs[Random.Range(0, mapPrefabs.Count)]));
            spawnedBuildings[i].transform.position = grid.SetHouseLocation();
            spawnedBuildings[i].GetComponent<House>().SetCurrent(false);
        }

        ChangeHousesToDelivery();
    }

    public void ChangeHousesToDelivery()
    {
        List<GameObject> tempList = new List<GameObject>();

        for(int i = 0; i < shipPackageController.GetMaxNumOfDeliveries(); i++)
        {
            House houseToDelivery = spawnedBuildings[Random.Range(0, spawnedBuildings.Count)].GetComponent<House>();
            houseToDelivery.SetCurrent(true);
            tempList.Add(houseToDelivery.gameObject);
            spawnedBuildings.Remove(houseToDelivery.gameObject);
        }

        for (int i = 0; i < tempList.Count; i++)
            spawnedBuildings.Add(tempList[i]);
    }

}