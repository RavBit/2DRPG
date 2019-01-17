using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour {
    Vector2 vec = new Vector2(0.5f, 0.5f);
    float vx;
    float vy;
    Rigidbody2D rigidbody;

	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            vx = -1.25f;
            vy = 0.0f;
        } 
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            vx = 1.25f;
            vy = 0.0f;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vx = 0.0f;
            vy = 1.25f;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vx = 0.0f;
            vy = -1.25f;
        }
        rigidbody.velocity = new Vector2(vx, vy);
	}
}
