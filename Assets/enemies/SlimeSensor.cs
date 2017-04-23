using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSensor : MonoBehaviour {
	SlimeAI ai;
	// Use this for initialization
	void Start () {
		ai = gameObject.GetComponentInParent<SlimeAI> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.GetComponent<playerMoveRB2D> ()) {
			ai.Aggro (other.gameObject);
		}
	}
}
