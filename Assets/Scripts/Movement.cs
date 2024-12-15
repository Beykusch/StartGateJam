using UnityEngine.SceneManagement;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movSpeed;
    public int point;
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

        if (other.gameObject.CompareTag("Gate"))
        {
            Debug.Log("Gate detected!");
            point += 100;
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            Debug.Log(point);
        }

        if (other.gameObject.CompareTag("Egypt Gate"))
        {
            SceneManager.LoadScene("SampleScene");
        }

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

        if (other.gameObject.CompareTag("Sword"))
        {
            Debug.Log("Sword detected!");
            HealthManager healthManager = healthBar.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(10);
                Debug.Log("Player took damage!");
            }
            else
            {
                Debug.LogWarning("HealthManager component not found on the health bar!");
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy detected!");
            HealthManager healthManager = healthBar.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(20);
                Destroy(other.gameObject);
                Debug.Log("Player took damage!");
            }
            else
            {
                Debug.LogWarning("HealthManager component not found on the health bar!");
            }
        }
    }

}

