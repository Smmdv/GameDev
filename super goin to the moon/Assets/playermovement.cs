using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private bool isGrounded; // Flag to check if the player is on the ground
    private bool isDescending; // Flag to check if the player is descending

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true; // Assume the player starts on the ground
        isDescending = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && isGrounded)
        {
            // Apply jump force only when the player is on the ground
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 8, 0);
            isGrounded = false; // Set isGrounded to false to prevent multiple jumps
        }

        // Check if the player is not grounded and holding the "s" key
        if (!isGrounded && Input.GetKey("s"))
        {
            isDescending = true;
        }
        else
        {
            isDescending = false;
        }
    }

    // FixedUpdate is called at a fixed interval
    void FixedUpdate()
    {
        if (isDescending)
        {
            // Apply a higher downward force to make the player descend quicker
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -40));
        }
    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; // Set isGrounded to true when the player touches the ground
            isDescending = false; // Reset the descending flag
        }
    }
}
