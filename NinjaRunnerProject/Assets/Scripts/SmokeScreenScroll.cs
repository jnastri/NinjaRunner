using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScreenScroll : MonoBehaviour
{
    public GameObject smokeScreenPrefab;
    [SerializeField]
    Transform targetTurretLoc;
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
            Instantiate(smokeScreenPrefab, targetTurretLoc.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
