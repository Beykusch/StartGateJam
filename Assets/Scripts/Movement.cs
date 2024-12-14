using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger!");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("CollisionEnter");
    }
}
