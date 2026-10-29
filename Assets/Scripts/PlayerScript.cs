using UnityEngine;
using UnityEngine.InputSystem;

public class YobaBehaviourScript : MonoBehaviour
{
    public Rigidbody2D yobaRigidBody;
    public Animator animator;
    public GameObject flameParticles;
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

            animator.SetBool(Constants.Animations.IsJumping, true);

            var flame = Instantiate(flameParticles, transform.position, flameParticles.transform.rotation);
            flame.transform.parent = transform;
            flame.transform.localScale = flameParticles.transform.localScale;
            flame.transform.localPosition = new Vector3(-0.9f, -3.6f, 0);
        }
        else
        {
            animator.SetBool(Constants.Animations.IsJumping, false);
        }
    }

    void OnCollisionEnter2D(Collision2D _)
    {
        _gameState.GameOver();
    }
}
