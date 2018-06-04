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

    [Header("Enemy Settings")]
    public bool goRight;
    public bool Goomba;
    public bool Lakitu;
    public bool Rabbit; 
    public bool doesEnemyFloat;

    private GameObject levelChanger;

    // Use this for initialization
    void Start() {
        controller = GetComponent<EnemyController>();
        levelChanger = GameObject.Find("LevelChanger");

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity" + gravity + "Jump Velocity" + jumpVelocity);

        
    }

    // Update is called once per frame
    void Update() {

        ChooseEnemyType();
       // MovementController();
        

    }

    /*void MovementController()
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
            //if(!Rabbit)
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
        
        if (transform.localScale.z == 1)
        {
            input = new Vector2(1, Input.GetAxisRaw("Vertical"));
        }
        else
        {
            input = new Vector2(-1, Input.GetAxisRaw("Vertical"));
        } 

      float targetVelocityX = input.x * moveSpeed;
      velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborn);

        
    } */

    void ChooseEnemyType()
    {
        if (Goomba)
            GoombaType();


         if (Lakitu)
            LakituType();

         if (Rabbit)
            RabbitType();

        if (!doesEnemyFloat)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborn);
    }

    void GoombaType()
    {
        if (goRight)
        {
            input = new Vector2(1, Input.GetAxisRaw("Vertical"));
            if (controller.collisions.right)
            {
                transform.localScale = new Vector3(-1, 1, 1);
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

    void LakituType()
    {
        float lakituSpeed = moveSpeed;
        doesEnemyFloat = true;

        if (velocity.y == 0)
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

    void RabbitType()
    {
        float rabbitSpeed = moveSpeed;
        doesEnemyFloat = false;
        Goomba = true;

        if (velocity.y == 0)
        {
            velocity.y = -rabbitSpeed;
        }

        if (controller.collisions.above)
        {
            velocity.y = -rabbitSpeed;
        }
        else if (controller.collisions.below)
        {
            velocity.y = rabbitSpeed;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            levelChanger.GetComponent<LevelChanger>().FadeToLevel("GameOver");
        }
    }

}
