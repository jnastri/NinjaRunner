using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    public float moveSpeedX;
    public float moveSpeedY;
    public bool goVertical;
    public bool goDiagonal;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        EnemyMovement();
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor")
        {
            moveSpeedX *= -1;
            moveSpeedY *= -1;
        }
        if(col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }

    void EnemyMovement()
    {
        if (goDiagonal)
        {
            goVertical = false;
            transform.Translate(new Vector2(moveSpeedX, moveSpeedY) * Time.deltaTime);
            
        }
            
        if (!goVertical && !goDiagonal)
        {
            transform.Translate(new Vector2(moveSpeedX, 0) * Time.deltaTime);
        }
            
        if(goVertical && !goDiagonal)
        {
            transform.Translate(new Vector2(0, moveSpeedY) * Time.deltaTime);
        }
            

    }
}
