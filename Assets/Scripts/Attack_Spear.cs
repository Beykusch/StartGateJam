using UnityEngine;

public class Attack_Spear: MonoBehaviour
{
    public GameObject laserPrefab;

    void Start()
    {
        Invoke("SpawnLaser", 1f);
    }

    void SpawnLaser()
    {
        GameObject laser = Instantiate(laserPrefab, new Vector2(transform.position.x - 10,transform.position.y), Quaternion.identity);

        Destroy(laser, 3f);
    }

}
