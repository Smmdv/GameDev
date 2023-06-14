using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionHandler : MonoBehaviour
{
    public Text gameOverText; // Reference to the UI Text component to display the "Game Over" message

    private bool gameEnded;

    private void Start()
    {
        gameEnded = false;
        gameOverText.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameEnded && collision.gameObject.CompareTag("obstacle"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        gameOverText.enabled = true;
        gameOverText.text = "Game Over";
    }
}
