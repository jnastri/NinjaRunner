using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpHeight = 4;
    public float slideJumpVelocity;
    public float timeToJumpApex = .4f;
    public float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .1f;

    [Header("Movement")]
    public float moveSpeed = 5;

    [Header("Wall Settings")]
    public float wallSlideSpeedMax = 3;
    public Vector2 wallJump;

    [Header("Slide Settings")]
    public float slideTime;
    public float slideJumpBoost = 2;
    private float slideStopWatch = 0;
    [HideInInspector]
    public bool isScalingDown;
    Vector2 originalSize;

    [HideInInspector]
    public Vector3 velocity;
    float velocityXSmoothing;

    float jumpVelocity;
    int jumpCount;
    float gravity;

    //Input that dictates character movement
    Vector2 input;
    //This varriable is assigned depending on which side has collisions. Left = -1 and right = 1
    int wallDirX;
    //Is the player sliding on a wall?
    bool wallSliding = false;

    public bool jumpBool;

    Controller2D playerController;
    // Use this for initialization
    void Start ()
    {
        playerController = GetComponent<Controller2D>();
        originalSize = transform.localScale;

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        jumpCount = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {

        Obstacle_WallController();

        JumpController();

        MovementController();

        if (Input.GetKeyDown(KeyCode.C) || isScalingDown)
        {
            SlideController();
        }
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

        if (Input.GetButtonDown("Jump") || jumpBool)
        {
            if (wallSliding)
            {
                //This used to be if(input.x == 0)
                if (input.x != 0)
                {
                    velocity.x = -wallDirX * wallJump.x;
                    velocity.y = wallJump.y;
                    //This did not exist
                    transform.localScale = new Vector3(-wallDirX,1,1);
                    //Aids in Double Jump
                    jumpCount = 1;
                }
            }

            //Adds another layer so the jump does not have to wait for the slide to kick in.
            if ((playerController.collisions.right || playerController.collisions.left) && velocity.y > 0)
            {
                //This used to be if(input.x == 0)
                if (input.x != 0)
                {
                    velocity.x = -wallDirX * wallJump.x;
                    velocity.y = wallJump.y;
                    //This did not exist
                    transform.localScale = new Vector3(-wallDirX, 1, 1);
                    //Aids in Double Jump
                    jumpCount = 1;
                }
            }
            if (playerController.collisions.below)
            {
                //Aids in Double Jump
                jumpCount = 1;

                if ((isScalingDown || transform.localScale.y != originalSize.y) && !playerController.SlidingRayCast(isScalingDown))
                {
                    velocity.y = slideJumpVelocity * 5 * slideJumpBoost;
                    isScalingDown = false;
                    Resize();
                }
                else
                {
                    velocity.y = jumpVelocity;
                }

            }
            //Aids in Double Jump
            else if (jumpCount != 0 && !wallSliding && !playerController.collisions.right && !playerController.collisions.left)
            {
                velocity.y = jumpVelocity;
                jumpCount--;
            }
            jumpBool = false;
        }

    }

    void MovementController()
    {
        if(transform.localScale.x == 1)
        {
            input = new Vector2(1, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            input = new Vector2(-1, Input.GetAxisRaw("Vertical"));
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (playerController.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    public void SlideController()
    { 
        bool isSmaller = isScalingDown;

        //Remove this statement if you want the character to be able to shrink in mid air.
        if (playerController.collisions.below)
        {
            if (!isSmaller)
            {
                slideStopWatch = 0;
                isScalingDown = true;

                Resize();
            }
            else if (isSmaller)
            {

                slideStopWatch += Time.deltaTime;
                playerController.SlidingRayCast(isSmaller);

                if (slideStopWatch > slideTime && playerController.SlidingRayCast(isSmaller) == false)
                {
                    isSmaller = false;
                    Invoke("Resize", .25f);
                }
                else
                {
                    isSmaller = true;
                }

                isScalingDown = isSmaller;
            }
        }
    }

    void Resize()
    {
        float resizeValue = .75f;
        Vector2 resizeVector = new Vector2(transform.localScale.x, transform.localScale.y - resizeValue);

        if (isScalingDown)
        {
            transform.localScale = resizeVector;
        }
        else
        {
            transform.localScale = originalSize;
        }

        playerController.CalculateRaySpacing();
        playerController.UpdateRaycastOrigins();
    }


}
