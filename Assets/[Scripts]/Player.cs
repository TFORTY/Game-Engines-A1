using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask finishLayer;
    public LayerMask redLayer;
    public LayerMask blueLayer;
    public LayerMask yellowLayer;
    public LayerMask greyLayer;

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
    public Text scoreText;

    private bool isFinished;
    private bool isRed;
    private bool isBlue;
    private bool isYellow;
    private bool isGrey;

    private bool isColorRed;
    private bool isColorBlue;
    private bool isColorYellow;
    private bool isColorGrey;

    public GameObject playerObject;
    public Material playerMat;
    public Material redMat;
    public Material blueMat;
    public Material yellowMat;

    private bool canSwitchColor = false;

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

        // Checks what colour the player is
        ColourChecks();

        // Vertical Velocity
        controller.Move(velocity * Time.deltaTime);

        // Goes to lose screen
        Lose();

        // Goes to win screen
        Win();

        // Retarts the game
        Restart();

        // Calculates score
        CalculateScore();
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
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    SceneManager.LoadScene("WinScreen");
        //}

        // Checks if player collided with finish platform
        isFinished = Physics.CheckSphere(transform.position, 0.1f, finishLayer, QueryTriggerInteraction.Collide);

        // Switches to win screen if player finishes level
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

    void ColourChecks()
    {
        // Checks what colour platform the player is on
        isRed = Physics.CheckSphere(transform.position, 0.1f, redLayer, QueryTriggerInteraction.Ignore);
        isBlue = Physics.CheckSphere(transform.position, 0.1f, blueLayer, QueryTriggerInteraction.Ignore);
        isYellow = Physics.CheckSphere(transform.position, 0.1f, yellowLayer, QueryTriggerInteraction.Ignore);
        isGrey = Physics.CheckSphere(transform.position, 0.1f, greyLayer, QueryTriggerInteraction.Ignore);

        if (Input.GetKeyDown(KeyCode.I))
        {
            isColorRed = true;
            playerObject.GetComponent<Renderer>().material = redMat;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            isColorBlue = true;
            playerObject.GetComponent<Renderer>().material = blueMat;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            isColorYellow = true;
            playerObject.GetComponent<Renderer>().material = yellowMat;
        }

        //if (isGrey)
        //{
        //    playerObject.GetComponent<Renderer>().material = playerMat;
        //}

        //if (isGrey && canSwitchColor)
        //{
        //    isColorGrey = true;
        //    playerObject.GetComponent<Renderer>().material = playerMat;
        //    canSwitchColor = true;
        //}
        //else
        //{
        //    canSwitchColor = false;
        //}

        if (isRed && isColorRed)
        {
            Debug.Log("IS RED");
        }
        else if (isRed && !isColorRed)
        {
            Debug.Log("NOT RED");
        }
        else if (isBlue && isColorBlue)
        {
            Debug.Log("IS BLUE");
        }
        else if (isBlue && !isColorBlue)
        {
            Debug.Log("NOT BLUE");
        } 
        else if (isYellow && isColorYellow)
        {
            Debug.Log("IS YELLOW");
        }
        else if (isYellow && !isColorYellow)
        {
            Debug.Log("NOT YELLOW");
        }
       
        else if (isGrey && isColorGrey)
        {
            Debug.Log("IS GREY");
        }
    }

    void CalculateScore()
    {
        scoreText.text = Time.time.ToString("0");
    }
}