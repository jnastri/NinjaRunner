using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScreenSettings : MonoBehaviour
{
    [SerializeField]
    float smokeScreenDuration = 3;

    float timer;

	// Use this for initialization
	void Start ()
    {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer > smokeScreenDuration)
        {
            Destroy(gameObject);
        }
	}
}
