using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkBox : MonoBehaviour {
	OldMan oldMan;
	// Use this for initialization
	void Start () {
		oldMan = GetComponentInParent<OldMan> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			oldMan.Talk (collider.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.CompareTag ("Player")) {
			oldMan.Quiet();
		}
	}
}
