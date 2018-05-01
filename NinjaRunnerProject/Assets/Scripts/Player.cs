using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    public float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .1f;

    public float moveSpeed = 5;

    public float wallSlideSpeedMax = 3;
    public Vector2 wallJump;

    Vector3 velocity;
    float velocityXSmoothing;

    float jumpVelocity;
    float gravity;

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
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        int wallDirX = (playerController.collisions.left) ? -1 : 1;

        bool wallSliding = false;
        if((playerController.collisions.left || playerController.collisions.right) && !playerController.collisions.below && velocity.y < 0)
        {
            wallSliding = true;
            if(velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }
        }

        if(playerController.collisions.above || playerController.collisions.below)
        {
            velocity.y = 0;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if (wallSliding)
            {
                if(input.x == 0)
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
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (playerController.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        //playerController.AutoMove();
        playerController.Move(velocity * Time.deltaTime);
	}
}
