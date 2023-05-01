using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidSpawner : MonoBehaviour
{
    private float spawnRadius = 10f;

    [SerializeField] List<GameObject> asteroidPrefab;
    [SerializeField] Transform player;
    [SerializeField] float spawnInterval;

    private int currentAsteroids;
    private int maxAsteroids = 10;
    private bool spawnOnStart = true;


    void Start()
    {
        player = GameObject.Find("Ship").transform;

        currentAsteroids = 0;

        if (spawnOnStart)
        {
            StartCoroutine(SpawnAsteroids());
        }
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            if (currentAsteroids < maxAsteroids)
            {
                SpawnAsteroid();
                currentAsteroids++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnAsteroid()
    {
        Vector3 spawnPosition = transform.position + Random.onUnitSphere * spawnRadius;
        GameObject asteroid = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Count)], player.position + spawnPosition, Quaternion.identity, gameObject.transform);
        asteroid.GetComponent<AsteroidBehaviour>().OnDestroyed += OnAsteroidDestroyed;
    }

    void OnAsteroidDestroyed()
    {
        currentAsteroids--;
    }
}