using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : MonoBehaviour {
	public GameObject prefab;
	public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire() {
		Vector3 targetVector = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (targetVector.y, targetVector.x) * Mathf.Rad2Deg;
		Debug.Log (angle);
		GameObject fireball = Instantiate (prefab, transform.position, Quaternion.AngleAxis (angle, Vector3.forward));
		fireball.GetComponent<Rigidbody2D> ().velocity = targetVector.normalized * 16;
	}
}
