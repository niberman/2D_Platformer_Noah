using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public Transform spawnLocations;
    public GameObject whatToSpawnPrefab;
    private GameObject whatToSpawnClone;

    private void Awake()
    {
        Spawn();
    }

    void Spawn()
    {
        whatToSpawnClone = Instantiate(whatToSpawnPrefab, spawnLocations.transform.position,
        Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    private void OnTriggerEnter2D()
    {
        Destroy(whatToSpawnClone);
        Spawn();
    }
}