using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private bool isGrounded; // Flag to check if the player is on the ground

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true; // Assume the player starts on the ground
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && isGrounded)
        {
            // Apply jump force only when the player is on the ground
           GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
            isGrounded = false; // Set isGrounded to false to prevent multiple jumps
        }
    }

    // OnCollisionEnter2D is called when a collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true; // Set isGrounded to true when the player touches the ground
        }
    }
}
