using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array to hold multiple enemy prefabs

    public GameObject healthObject;

    public bool canSpawnEnemy = true; // Toggle to enable/disable spawning

    public float waitTime = 4f; // Time between spawns

    public float minY; // Minimum Y position for spawning
    public float maxY; // Maximum Y position for spawning

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        healthObject = GameObject.FindGameObjectWithTag("healthBar");
    }

    IEnumerator EnemySpawn()
    {
        while (canSpawnEnemy)
        {
            // Choose a random Y position within the specified range
            var randomY = UnityEngine.Random.Range(minY, maxY);
            var position = new Vector3(transform.position.x, randomY, transform.position.z);

            // Select a random prefab from the array
            if (enemyPrefabs.Length > 0)
            {
                GameObject enemy = Instantiate(
                    enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)],
                    position,
                    Quaternion.identity);

                // Destroy the enemy after 5 seconds
                Destroy(enemy, 5f);
            }

            yield return new WaitForSeconds(waitTime);
        }
    }
}
