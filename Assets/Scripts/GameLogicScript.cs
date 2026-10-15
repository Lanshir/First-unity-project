using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text scoreText;
    public int playerScore;
    public bool playerAlive = true;

    [ContextMenu("Increase player score")]
    public void IncrementPlayerScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Restart Game")]
    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    [ContextMenu("Game Over")]
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        playerAlive = false;
    }
}
