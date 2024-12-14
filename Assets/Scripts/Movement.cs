using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    public GameObject hitboxSpear;
    public GameObject hitboxSword;
    public GameObject healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthBar = GameObject.FindGameObjectWithTag("healthBar");
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);
        hitboxSpear = GameObject.FindGameObjectWithTag("Spear");
        hitboxSword = GameObject.FindGameObjectWithTag("Sword");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter Detected!");

        if (other.gameObject.CompareTag("Spear"))
        {
            Debug.Log("Spear detected!");
            HealthManager healthManager = healthBar.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(20);
                Debug.Log("Player took damage!");
            }
            else
            {
                Debug.LogWarning("HealthManager component not found on the health bar!");
            }
        }
    }

}

