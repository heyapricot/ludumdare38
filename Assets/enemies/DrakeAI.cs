using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrakeAI : MonoBehaviour {
	public enum DrakeColor {
		RED,
		BLUE,
		GREEN,
		BLACK
	};
	public DrakeColor myColor = DrakeColor.RED; 
	public float fireRange = 4;
	public float speed = 6;
	public GameObject prefab;
	public GameObject target;
	bool shooting = false;
	Rigidbody2D rb2d;
	Animator animator;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && target.activeInHierarchy) {
			attack (target);
		} else {
			animator.Play (GetColor() + "Stand");
			rb2d.velocity = Vector2.zero;
		}
	}

	void attack(GameObject other) {
		Vector2 movement = other.transform.position - transform.position;
		if (movement.magnitude > fireRange && !shooting) {
			rb2d.velocity = movement.normalized * speed;
			animator.Play (GetColor() + "Walk");
			if (rb2d.velocity.x < 0) {
				GetComponent<SpriteRenderer> ().flipX = true;
			} else if (rb2d.velocity.x > 0) {
				GetComponent<SpriteRenderer> ().flipX = false;
			}
		} else {
			rb2d.velocity = Vector2.zero;
			animator.Play (GetColor() + "Attack");
			shooting = true;
		}
	}

	public void Aggro(GameObject other) {
		target = other;
	}

	public string GetColor() {
		switch (myColor) {
		case DrakeColor.RED:
			return "Red";
		case DrakeColor.BLACK:
			return "Black";
		case DrakeColor.BLUE:
			return "Blue";
		case DrakeColor.GREEN:
			return "Green";
		default:
			return "Red";
		}
	}

	public void Fire() {
		Vector3 targetVector = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (targetVector.y, targetVector.x) * Mathf.Rad2Deg;
		Debug.Log (angle);
		GameObject fireball = Instantiate (prefab, transform.position, Quaternion.AngleAxis (angle, Vector3.forward));
		fireball.GetComponent<Rigidbody2D> ().velocity = targetVector.normalized * 16;
		shooting = false;
	}
}
