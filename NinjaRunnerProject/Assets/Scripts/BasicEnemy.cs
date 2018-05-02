using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {

    public int EnemySpeed;
    public int DirectionInt;
    public LayerMask colMask;



	// Use this for initialization
	void Start () {
        DirectionInt = 1;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(DirectionInt, 0), 2, colMask);
        Debug.DrawRay(transform.position, new Vector2(DirectionInt, 0) * 2, Color.red);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(DirectionInt, 0) * EnemySpeed;
        if(hit)
        {
            Flip();
        }
	}

    void Flip()
    {
        if(DirectionInt > 0)
        {
            DirectionInt = -1;
            Debug.Log("Change 1");
        }
        else
        {
            DirectionInt = 1;
            Debug.Log("Change 2");
        }
    }
}
