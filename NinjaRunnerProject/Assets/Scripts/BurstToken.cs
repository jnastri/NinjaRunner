using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstToken : MonoBehaviour
{
    Player player;
    float dirX;
    public float burstSpeed;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            player = col.gameObject.GetComponent<Player>();
            dirX = player.gameObject.transform.localScale.x;
            player.velocity.x = dirX * player.moveSpeed * burstSpeed;
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            //player.velocity.x = dirX * burstSpeed;
        }
    }
}
