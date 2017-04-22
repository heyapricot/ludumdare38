using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyMover : MonoBehaviour {
	public Vector2 velocity = new Vector2(-4, 1);
	public Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Jump() {
		if (velocity != null)
			rb2d.velocity = velocity;
	}
	public void Land() {
		rb2d.velocity = Vector2.zero;
	}
}
