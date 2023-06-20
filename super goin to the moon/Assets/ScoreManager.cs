using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;          // Reference to the UI text displaying the current score
    public Text highScoreText;      // Reference to the UI text displaying the high score

    private int score = 0;          // Current score
    private int highScore = 0;      // High score

    private void Start()
    {
        // Load the high score from player preferences
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
        UpdateScoreText(); // Update the score text at the start
    }

    private void Update()
    {
        // Increase the score by 1 every second
        score += 1;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Update the score text
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("Score updated: " + score.ToString()); // Log the score update
    }

    private void UpdateHighScoreText()
    {
        // Update the high score text
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void EndGame()
    {
        // Check if the current score is higher than the saved high score
        if (score > highScore)
        {
            // Set the new high score
            highScore = score;
            UpdateHighScoreText();

            // Save the new high score to player preferences
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        // Reset the current score
        score = 0;
        UpdateScoreText();
    }
}
