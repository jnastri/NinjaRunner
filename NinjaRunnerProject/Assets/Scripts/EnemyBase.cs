using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyBase : MonoBehaviour {

    [Header("Jump Settings")]
    public float jumpHeight= 4 ;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborn = .2f;
    float accelerationTimeGrounded= .1f;

    public float moveSpeed = 6;
    float gravity;
    int jumpCount;
    float jumpVelocity;
    Vector3 velocity;
    Vector2 input;
    float velocityXSmoothing;

    int wallDirX;
    //Is the player sliding on a wall?
    bool wallSliding = false;

    [Header("Wall Settings")]
    public float wallSlideSpeedMax = 3;
    public Vector2 wallJump;

    EnemyController controller;

    public bool goRight;
    public bool Goomba;
    public bool Lakitu;
    public bool Rabbit; 
    public bool doesEnemyFloat;

    // Use this for initialization
    void Start() {
        controller = GetComponent<EnemyController>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity" + gravity + "Jump Velocity" + jumpVelocity);
    }

    // Update is called once per frame
    void Update() {


        MovementController();
        //JumpController();
       /* if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = velocity.x = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborn);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
		*/
	}

    void MovementController()
    {
        if (Goomba)
        {
            if (goRight)
            {
                input = new Vector2(1, Input.GetAxisRaw("Vertical"));
                if (controller.collisions.right)
                {
                    transform.localScale = new Vector3(1, 1, -1);
                    goRight = false;
                }
            }

            else
            {
                input = new Vector2(-1, Input.GetAxisRaw("Vertical"));
                if (controller.collisions.left)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    goRight = true;
                }
            }
        }

        if (Lakitu)
        {
            float lakituSpeed = moveSpeed;
            if(!Rabbit)
            doesEnemyFloat = true;

            if(velocity.y == 0)
            {
                velocity.y = -lakituSpeed;
            }

            if (controller.collisions.above)
            {
                velocity.y = -lakituSpeed;
            }
            else if (controller.collisions.below)
            {
                velocity.y = lakituSpeed;
            }
        }
        
       /* if (transform.localScale.z == 1)
        {
            input = new Vector2(1, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            input = new Vector2(-1, Input.GetAxisRaw("Vertical"));
        } */ 

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborn);

        if (!doesEnemyFloat)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        controller.Move(velocity * Time.deltaTime);
    }


   /* void JumpController()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (wallSliding)
            {
                //This used to be if(input.x == 0)
                if (input.x != 0)
                {
                    velocity.x = -wallDirX * wallJump.x;
                    velocity.y = wallJump.y;
                    //This did not exist
                    transform.localScale = new Vector3(1, 1, -wallDirX);
                    //Aids in Double Jump
                    jumpCount = 1;
                }
            }
            //Adds another layer so the jump does not have to wait for the slide to kick in.
            if ((controller.collisions.right || controller.collisions.left) && velocity.y > 0)
            {
                //This used to be if(input.x == 0)
                if (input.x != 0)
                {
                    velocity.x = -wallDirX * wallJump.x;
                    velocity.y = wallJump.y;
                    //This did not exist
                    transform.localScale = new Vector3(1, 1, -wallDirX);
                    //Aids in Double Jump
                    jumpCount = 1;
                }
            }
            if (controller.collisions.below)
            {
                //Aids in Double Jump
                jumpCount = 1;

                velocity.y = jumpVelocity;
            }
            //Aids in Double Jump
            else if (jumpCount != 0 && !wallSliding && !controller.collisions.right && !controller.collisions.left)
            {
                velocity.y = jumpVelocity;
                jumpCount--;
            }
        } 
    } */
}
