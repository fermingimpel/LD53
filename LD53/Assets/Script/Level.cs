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

    // Start is called before the first frame update
    private void Start()
    {
        grid = GetComponent<CustomGrid>();
        spawnedBuildings = new List<GameObject>();
        SpawnHouses();
    }

    void SpawnHouses()
    {
        for (int i = 0; i < houseQty; i++)
        {
            spawnedBuildings.Add(Instantiate(mapPrefabs[Random.Range(0, mapPrefabs.Count - 1)]));
            spawnedBuildings[i].transform.position = grid.SetHouseLocation();
        }
    }
}