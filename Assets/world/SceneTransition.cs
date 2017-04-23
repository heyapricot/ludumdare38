using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {
	static bool inTransition = false;
	public GameObject myWorld;
	public GameObject newWorld;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!inTransition && other.GetComponent<playerMoveRB2D> () != null) {
			inTransition = true;
			myWorld.SetActive (false);
			newWorld.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		inTransition = false;
	}
}
