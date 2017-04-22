using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveRB2D : MonoBehaviour
{

    Vector3 pos;                                // For movement
    public float speed = 96.0f;                         // Speed of movement
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pos = rb2d.position;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {        // Left
            pos += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {        // Right
            pos += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {        // Up
            pos += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {        // Down
            pos += Vector3.down;
        }

        rb2d.MovePosition(Vector3.MoveTowards(rb2d.position, pos, Time.deltaTime * speed));    // Move there
    }
}
