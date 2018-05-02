using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (RayCastEnemies))]
public class EnemyBase : MonoBehaviour {

    float moveSpeed = 6;
    float gravity = -20;
    Vector3 velocity;

    Controller2D controller;
	// Use this for initialization
	void Start () {
        controller = GetComponent<Controller2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(new Vector2(moveSpeed, 0) * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
	}
}
