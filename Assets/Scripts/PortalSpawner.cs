using UnityEngine;



public class PortalSpawner : MonoBehaviour

{

    public GameObject portalPrefab; // The enemy prefab

    public float spawnInterval = 2f; // Time between spawns

    public Transform[] spawnPoints; // Array of spawn points



    private void Start()

    {

        // Start spawning enemies

        InvokeRepeating("SpawnPortal", 0f, spawnInterval);

    }



    void SpawnPortal()

    {

        if (spawnPoints.Length == 0) return; // No spawn points available



        // Choose a random spawn point

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];



        // Instantiate the enemy prefab at the spawn point

        Instantiate(portalPrefab, spawnPoint.position, Quaternion.identity);

        Destroy(portalPrefab.gameObject, 5f);

    }



    private void OnDrawGizmos()

    {

        // Draw spawn points in the scene view

        Gizmos.color = Color.red;

        foreach (Transform spawnPoint in spawnPoints)

        {

            if (spawnPoint != null)

            {

                Gizmos.DrawSphere(spawnPoint.position, 0.5f);

            }

        }

    }

}
