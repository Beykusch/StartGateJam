using UnityEngine;



public class WorldChange : MonoBehaviour

{

    public GameObject portalPrefab; // The enemy prefab

    public GameObject specialPortalPrefab; // Special portal prefab

    public float spawnInterval = 2f; // Time between spawns

    public Transform[] spawnPoints; // Array of spawn points



    private void Start()

    {

        // Start spawning enemies

        InvokeRepeating("SpawnPortal", 0f, spawnInterval);

        // Schedule to stop regular portals and spawn the special portal after 40 seconds
        Invoke("StopRegularPortalsAndSpawnSpecial", 40f);

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

    void StopRegularPortalsAndSpawnSpecial()
    {
        // Stop the regular portal spawning
        CancelInvoke("SpawnPortal");

        if (spawnPoints.Length == 0) return; // No spawn points available

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[1];

        // Instantiate the special portal prefab at the spawn point
        Instantiate(specialPortalPrefab, spawnPoint.position, Quaternion.identity);

        // Optionally destroy the special portal after a set time
        Destroy(specialPortalPrefab, 10f);
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
