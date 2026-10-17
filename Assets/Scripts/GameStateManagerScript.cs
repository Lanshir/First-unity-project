using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManagerScript : MonoBehaviour
{
    public PlayerState player = new();

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
    }

    private void Start()
    {
        // Short pause before game start.
        StartCoroutine(FreezeGame(1));
    }

    private IEnumerator FreezeGame(float seconds)
    {
        var gameTimeScale = Time.timeScale;

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(seconds);

        Time.timeScale = gameTimeScale;
    }
}

[Serializable]
public class PlayerState
{
    public int score = 0;
    public bool isAlive = true;
}