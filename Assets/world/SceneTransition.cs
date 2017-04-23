using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {
	static GameObject lastTransition;
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
		Debug.Log ("Entering.");
		if (!inTransition && other.GetComponent<playerMoveRB2D> () != null) {
			Debug.Log ("Transitioning.");
			inTransition = true;
			lastTransition = gameObject;
			myWorld.SetActive (false);
			newWorld.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Leaving.");
		if (other.GetComponent<playerMoveRB2D> () != null) {
			Debug.Log ("Exiting.");
			inTransition = false;
		}
	}
}
