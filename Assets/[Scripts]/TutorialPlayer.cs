using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
    public LayerMask groundLayer;

    // Player Attributes
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public float gravity = -50f;
    public float moveSpeed = 5f;
    public float jumpForce = 2f;

    // Jumping Attributes
    private bool isJumpPressed;
    private float jumpTimer;
    private float jumpGraceTime = 0.2f;

    // Player components
    public GameObject playerObject;
    public Material redMat;
    public Material blueMat;
    public Material yellowMat;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
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

        // Vertical Velocity
        controller.Move(velocity * Time.deltaTime);

        ChangeColours();
    }

    void ChangeColours()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerObject.GetComponent<Renderer>().material = redMat;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            playerObject.GetComponent<Renderer>().material = blueMat;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            playerObject.GetComponent<Renderer>().material = yellowMat;
        }
    }
}