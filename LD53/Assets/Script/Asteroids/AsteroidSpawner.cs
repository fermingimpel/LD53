using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] float spawnRadius = 10f;

    [SerializeField] List<GameObject> asteroidPrefab;
    [SerializeField] Transform player;
    [SerializeField] float spawnInterval;
    [SerializeField] float initialDelay;
    public List<GameObject> asteroids;

    private int currentAsteroids;
    private int maxAsteroids = 10;
    private bool spawnOnStart = true;


    void Start()
    {
        player = GameObject.Find("Ship").transform;

        currentAsteroids = 0;

        if (spawnOnStart)
        {
            StartCoroutine(SpawnAsteroidsWithDelay());
        }
    }

    IEnumerator SpawnAsteroidsWithDelay()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(SpawnAsteroids());
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
        asteroids.Add(asteroid);
    }

    void OnAsteroidDestroyed(GameObject asteroid)
    {
        currentAsteroids--;
        asteroids.Remove(asteroid);
    }
}