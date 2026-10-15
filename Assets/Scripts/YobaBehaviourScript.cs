using UnityEngine;
using UnityEngine.InputSystem;

public class YobaBehaviourScript : MonoBehaviour
{
    public Rigidbody2D yobaRigidBody;
    public float flapStrength = 6;

    private GameLogicScript gameLogic;

    void Start()
    {
        gameLogic = GameObject
            .FindGameObjectWithTag("GameLogic")
            .GetComponent<GameLogicScript>();
    }

    void Update()
    {
        // Player gone offscreen.
        if (transform.position.y > 6 || transform.position.y < -6)
        {
            gameLogic.GameOver();
            return;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame
            && gameLogic.playerAlive)
        {
            yobaRigidBody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D _)
    {
        gameLogic.GameOver();
    }
}
