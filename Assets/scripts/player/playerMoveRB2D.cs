using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveRB2D : MonoBehaviour
{

    Vector3 movement;                                // For movement
    public float speed = 96.0f;                         // Speed of movement
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		movement = new Vector3 ();
        if (Input.GetKey(KeyCode.A))
        {        // Left
			movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {        // Right
			movement += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {        // Up
			movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {        // Down
			movement += Vector3.down;
        }
		rb2d.velocity = movement * speed;
		//rb2d.MovePosition(Vector3.MoveTowards(rb2d.position, pos * speed, Time.deltaTime));    // Move there
    }
}
