using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour {
	private float targetY;
	private Vector3 velocity;
	public float popSpeed = 1;
	public float weight = 1f;
	// Use this for initialization
	void Start () {
		float angle = (Mathf.PI * 0.4f) + (Random.value * Mathf.PI * 0.2f);
		velocity = new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) * popSpeed;
		targetY = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y >= targetY) {
			transform.position += velocity * Time.deltaTime;
			velocity -= new Vector3 (0, Time.deltaTime * weight, 0);
		}
	}
}
