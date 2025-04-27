using UnityEngine;

public class BoltSpawner : MonoBehaviour
{
    public GameObject boltPrefab; // Træk Bolt prefab her
    public Transform[] spawnPoints; // Tilføj dine spawnpoints

    void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(boltPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
