using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameStateManagerScript : MonoBehaviour
{
    public PlayerStateObject player;

    public PanelRenderer gameOverPanel;

    [ContextMenu("Increase player score")]
    public void IncrementPlayerScore()
    {
        player.score++;
    }

    [ContextMenu("Restart Game")]
    public void RestartGame()
    {
        SceneManager.LoadScene(Constants.Scenes.Main);
    }

    [ContextMenu("Game Over")]
    public void GameOver()
    {
        player.isAlive = false;
        gameOverPanel.enabled = true;
    }

    private void OnEnable()
    {
        player.ResetToInitial();
    }

    private void Start()
    {
        // Short pause before game start.
        StartCoroutine(FreezeGame(1.5f));
    }

    private IEnumerator FreezeGame(float seconds)
    {
        var gameTimeScale = Time.timeScale;

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(seconds);

        Time.timeScale = gameTimeScale;
    }
}