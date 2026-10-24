using UnityEngine;

public class ScoreCounterScript : MonoBehaviour
{
    private GameStateManagerScript _gameState;

    void Start()
    {
        _gameState = Helpers.GetGameStateManager();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Constants.Layers.Player
            && _gameState.player.IsAlive)
        {
            _gameState.IncrementPlayerScore();
        }
    }
}
