using UnityEngine;

public class Attack_Sword: MonoBehaviour
{
    public GameObject slashPrefab;

    void Start()
    {
        Invoke("SpawnSlash", 2f);
    }

    void SpawnSlash()
    {
        GameObject laser = Instantiate(slashPrefab, new Vector2(transform.position.x - Random.Range(2,17), transform.position.y), Quaternion.identity);

        Destroy(laser, 2f);
    }

}
