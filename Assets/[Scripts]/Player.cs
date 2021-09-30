using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask finishLayer;
    public LayerMask redLayer;

    public float gravity = -50f;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private float horiInput;
    public float moveSpeed = 5f;
    public float jumpForce = 2f;

    private bool isJumpPressed;
    private float jumpTimer;
    private float jumpGraceTime = 0.2f;

    private float score;

    private bool isFinished;
    private bool isRed;

    private bool isColorRed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Initialize player speed
        horiInput = 1;

        // Makes the player face in the direction they are moving
        transform.forward = new Vector3(horiInput, 0, Mathf.Abs(horiInput) - 1);

        // Check if player is on the ground (transform.position is at the bottom of the player)
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayer, QueryTriggerInteraction.Ignore);

        // Player is not grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        // Player is grounded
        else
        {
            // Add Gravity
            velocity.y += gravity * Time.deltaTime;
        }

        // Move character controller horizontally
        controller.Move(new Vector3(horiInput * moveSpeed, 0, 0) * Time.deltaTime);

        // Jumping Logic
        isJumpPressed = Input.GetKeyDown(KeyCode.Space);

        if (isJumpPressed)
        {
            jumpTimer = Time.time;
        }

        if (isGrounded && (isJumpPressed || (jumpTimer > 0 && Time.time < jumpTimer + jumpGraceTime)))
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2 * gravity);
            jumpTimer = -1;
        }

        if (Input.GetKey(KeyCode.I))
        {
            isColorRed = true;
            score++;
        }
        else
        {
            isColorRed = false;
        }


        // Vertical Velocity
        controller.Move(velocity * Time.deltaTime);

        // Checks if player collided with finish platform
        isFinished = Physics.CheckSphere(transform.position, 0.1f, finishLayer, QueryTriggerInteraction.Collide);

        isRed = Physics.CheckSphere(transform.position, 0.1f, redLayer, QueryTriggerInteraction.Ignore);

        if (isRed && isColorRed)
        {
            Debug.Log("IS RED");
        }
        else if (isRed && !isColorRed)
        {
            Debug.Log("NOT RED");          
        }

        // Goes to lose screen
        Lose();

        // Goes to win screen
        Win();

        // Retarts the game
        Restart();
    }

    void Lose()
    {
        if (transform.position.y <= -10f)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    void Win()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("WinScreen");
        }

        if (isFinished)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
    }
}