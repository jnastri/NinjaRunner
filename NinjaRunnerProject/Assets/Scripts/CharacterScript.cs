using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float speed = 3;
    public float jumpForce = 3;
    public Transform groundPoint;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Movement();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
	}

    void Movement()
    {
        if(gameObject.transform.localScale.z == 1)
        {
            gameObject.transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        }
        else
        {
            gameObject.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }
    }

    void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundPoint.transform.position, Vector2.down, 1);
        Debug.DrawRay(groundPoint.transform.position, Vector2.down * 1, Color.red);
        if (hit.collider.gameObject.layer == 8)
        {
            //Physics based jump
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
