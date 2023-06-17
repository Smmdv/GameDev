using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as desired

    private void Update()
    {
        // Move the object to the right
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
