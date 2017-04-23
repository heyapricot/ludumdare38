using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour {
	public float speed = 4;
	public Rigidbody2D rb2d;
	public Animator animator;
	private GameObject target;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && target.activeInHierarchy) {
			animator.Play ("SlimeJump");
		} else {
			animator.Play ("SlimeStand");
		}
	}

	private Vector2 GetMovement() {
		return (target.transform.position - transform.position).normalized * speed;
	}

	public void Aggro(GameObject other) {
		target = other;
	}

	public void Jump() {
		if (target != null)
			rb2d.velocity = GetMovement();
	}
	public void Land() {
		rb2d.velocity = Vector2.zero;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Debug.Log("Slime was touched by a weapon");
            GetComponent<healthController>().health -= 10;
            Debug.Log("Slime's health: " + GetComponent<healthController>().health);
        }
    }

}
