using System.Collections;
using UnityEngine;

public class Attack_Spear: MonoBehaviour
{
    public GameObject laserPrefab;
    public Sprite newSprite;

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
        GameObject laser = Instantiate(laserPrefab, new Vector2(transform.position.x - 10,transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        laser.GetComponent<BoxCollider2D>().isTrigger = true;
        SpriteRenderer spriteRenderer = laser.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
            spriteRenderer.sprite = newSprite;
        }

        // Play the animation
        Animator animator = laser.GetComponent<Animator>();
        if (animator != null)
        {
            animator.enabled = true; // Ensure your animation has a trigger parameter called "PlayAnimation"
        }
    
        Destroy(laser, 1f);
    }

}
