using UnityEngine;
using UnityEngine.InputSystem;

public class YobaBehaviourScript : MonoBehaviour
{
    public Rigidbody2D yobaRigidBody;
    public float jumpStrength = 6;

    private GameStateManagerScript _gameState;

    void Start()
    {
        _gameState = Helpers.GetGameStateManager();
    }

    void Update()
    {
        // Player gone offscreen.
        if (transform.position.y > 6 || transform.position.y < -6)
        {
            _gameState.GameOver();
            return;
        }

        // Jump.
        if (Keyboard.current.spaceKey.wasPressedThisFrame
            && _gameState.player.IsAlive
            && Time.timeScale > 0)
        {
            yobaRigidBody.linearVelocity = Vector2.up * jumpStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D _)
    {
        _gameState.GameOver();
    }
}
