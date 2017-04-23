using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class DungeonComponent : MonoBehaviour {
	public int width;
	public int height;
	public GameObject prefab;
	public Sprite[] floors;
	public Sprite walls;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < width; i++) {
			for (int j = 0; j <= height; j++) {
				GameObject tile = Instantiate (prefab, new Vector3 (i, j, 0) + transform.position, Quaternion.identity, transform);
				if (j == height) {
					tile.GetComponent<SpriteRenderer> ().sprite = walls;
				} else {
					tile.GetComponent<SpriteRenderer> ().sprite = RandomUtils.Choice(floors);
				}
			}
		}
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Vector3 tl = new Vector3 (0, height, 0);
		Vector3 tr = new Vector3 (width, height, 0);
		Vector3 bl = new Vector3 (0, 0, 0);
		Vector3 br = new Vector3 (width, 0, 0);
		Vector3[] box = { tl, tr, br, bl };
		for (int i = 0; i < box.Length; i++) {
			box[i] += transform.position;
			box [i] -= Vector3.one * 0.5f;
		}
		for (int i = 0;i < box.Length;i++) {
			Gizmos.DrawLine (box [i], box [i == box.Length - 1 ? 0 : i + 1]);
		}
	}
}
