using System.Collections;
using UnityEngine;

public class Attack_Sword: MonoBehaviour
{
    public GameObject slashPrefab;

    void Start()
    {
        StartCoroutine(Wait2Seconds());
        StartCoroutine(SpawnLaser());
    }
    private IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator SpawnLaser()
    {
        GameObject laser = Instantiate(slashPrefab, new Vector2(transform.position.x -Random.Range(10,17), transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        laser.GetComponent<CapsuleCollider2D>().isTrigger = true;
        Destroy(laser, 1f);
    }

}
