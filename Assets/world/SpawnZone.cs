using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class SpawnZone : MonoBehaviour {
	BoxCollider2D area;
	public GameObject[] spawns;
	private ArrayList spawned = new ArrayList();
	public float spawnInterval;
	private float sinceLast;
	private bool playerPresent = false;
	// Use this for initialization
	void Start () {
		area = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerPresent) {
			sinceLast = 0;
		} else {
			sinceLast += Time.deltaTime;
			if (sinceLast > spawnInterval) {
				sinceLast -= spawnInterval;
				SpawnRandom ();
			}
		}
	}

	void SpawnRandom() {
		Vector2 position = RandomUtils.InBox (area.offset, area.size);
		GameObject spawn = Instantiate (RandomUtils.Choice (spawns), position, Quaternion.identity);
		spawned.Add (spawn);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<playerMoveRB2D> () != null) {
			playerPresent = true;
		} else {
			playerPresent = false;
		}
	}
}
