using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject myCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 difference = transform.position - myCamera.transform.position;
		difference.z = 0;
		myCamera.transform.position += difference;
	}
}
