using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .1f;

    [Header("Movement")]
    public float moveSpeed = 5;

    [Header("Wall Settings")]
    public float wallSlideSpeedMax = 3;
    public Vector2 wallJump;


    Vector3 velocity;
    float velocityXSmoothing;

    float jumpVelocity;
    float gravity;

    //Input that dictates character movement
    Vector2 input;
    //This varriable is assigned depending on which side has collisions. Left = -1 and right = 1
    int wallDirX;
    //Is the player sliding on a wall?
    bool wallSliding = false;

    Controller2D playerController;
    // Use this for initialization
    void Start ()
    {
        playerController = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Obstacle_WallController();
        JumpController();
        MovementController();
       /* input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        wallDirX = (playerController.collisions.left) ? -1 : 1;

        wallSliding = false;
        if ((playerController.collisions.left || playerController.collisions.right) && !playerController.collisions.below && velocity.y < 0)
        {
            wallSliding = true;
            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }
        }

        if (playerController.collisions.above || playerController.collisions.below)
        {
            velocity.y = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (wallSliding)
            {
                if (input.x == 0)
                {
                    velocity.x = -wallDirX * wallJump.x;
                    velocity.y = wallJump.y;
                }
            }
            if (playerController.collisions.below)
            {
                velocity.y = jumpVelocity;
            }
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (playerController.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        //playerController.AutoMove();
        playerController.Move(velocity * Time.deltaTime);*/
    }

    void Obstacle_WallController()
    {
        wallDirX = (playerController.collisions.left) ? -1 : 1;

        wallSliding = false;
        if ((playerController.collisions.left || playerController.collisions.right) && !playerController.collisions.below && velocity.y < 0)
        {
            wallSliding = true;
            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }
        }

        if (playerController.collisions.above || playerController.collisions.below)
        {
            velocity.y = 0;
        }
    }

    void JumpController()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (wallSliding)
            {
                if (input.x == 0)
                {
                    velocity.x = -wallDirX * wallJump.x;
                    velocity.y = wallJump.y;
                }
            }
            if (playerController.collisions.below)
            {
                velocity.y = jumpVelocity;
            }
        }
    }

    void MovementController()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (playerController.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        //playerController.AutoMove();
        playerController.Move(velocity * Time.deltaTime);
    }
}
