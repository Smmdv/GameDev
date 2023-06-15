using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private Rigidbody2D rb;
    private int groundCollisions;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCollisions = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            groundCollisions++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            groundCollisions--;
        }
    }

    private void FixedUpdate()
    {
        if (groundCollisions > 0)
        {
            rb.gravityScale = 0f;
            rb.drag = 10f;
        }
        else
        {
            rb.gravityScale = 1f;
            rb.drag = 0f;
        }
    }
}