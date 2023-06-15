using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    private bool isGameOver = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle") && gameObject.CompareTag("Player") && !isGameOver)
        {
            isGameOver = true;
            ShowGameOverPanel();
        }
    }

    private void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
