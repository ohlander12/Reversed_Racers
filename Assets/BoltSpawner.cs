using UnityEngine;

public class BoltSpawner : MonoBehaviour
{
    public GameObject boltPrefab; // Tr�k Bolt prefab her
    public Transform[] spawnPoints; // Tilf�j dine spawnpoints

    void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(boltPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
