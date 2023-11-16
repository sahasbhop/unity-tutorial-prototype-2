using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] topAnimals;
    public GameObject[] leftAnimals;
    public GameObject[] rightAnimals;

    private const float SpawnRangeX = 22;
    private const float SpawnPositionZ = 20;
    private const float SpawnMaxZ = 15;
    private const float SpawnMinZ = 5;
    private const float SpawnMinRate = 0.5f;
    private const float SpawnMaxRate = 3.5f;

    private void Start()
    {
        Invoke(nameof(SpawnAnimalsFromTheTop), Random.Range(SpawnMinRate, SpawnMaxRate));
        Invoke(nameof(SpawnAnimalsFromTheLeft), Random.Range(SpawnMinRate, SpawnMaxRate));
        Invoke(nameof(SpawnAnimalsFromTheRight), Random.Range(SpawnMinRate, SpawnMaxRate));
    }

    private void SpawnAnimalsFromTheTop()
    {
        var spawnPosition = new Vector3(Random.Range(-13, 13), 0, SpawnPositionZ);
        SpawnAnimal(topAnimals, nameof(SpawnAnimalsFromTheTop), spawnPosition);
    }

    private void SpawnAnimalsFromTheLeft()
    {
        var spawnPosition = new Vector3(-SpawnRangeX, 0, Random.Range(SpawnMinZ, SpawnMaxZ));
        SpawnAnimal(leftAnimals, nameof(SpawnAnimalsFromTheLeft), spawnPosition);
    }

    private void SpawnAnimalsFromTheRight()
    {
        var spawnPosition = new Vector3(SpawnRangeX, 0, Random.Range(SpawnMinZ, SpawnMaxZ));
        SpawnAnimal(rightAnimals, nameof(SpawnAnimalsFromTheRight), spawnPosition);
    }

    private void SpawnAnimal(IReadOnlyList<GameObject> animals, string methodName, Vector3 spawnPosition)
    {
        var spawnAnimal = animals[Random.Range(0, animals.Count)];
        Instantiate(spawnAnimal, spawnPosition, spawnAnimal.transform.rotation);
        Invoke(methodName, Random.Range(SpawnMinRate, SpawnMaxRate));
    }
}