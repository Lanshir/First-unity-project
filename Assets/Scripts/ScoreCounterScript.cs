using UnityEngine;

public class ScoreCounterScript : MonoBehaviour
{
    private GameLogicScript gameLogic;

    void Start()
    {
        gameLogic = GameObject
            .FindGameObjectWithTag("GameLogic")
            .GetComponent<GameLogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            gameLogic.IncrementPlayerScore();
        }
    }
}
