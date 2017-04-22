using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusedToroidWorld : MonoBehaviour {
	public int tileSize = 16;
	public int worldWidth = 16;
	public int worldHeight = 16;
	public GameObject focus;
	public GameObject[] worldTiles;
	// Use this for initialization
	void Start () {
		for (int x = 0; x < worldWidth; x++) {
			for (int y = 0; y < worldHeight; y++) {
				GameObject tile = worldTiles [x + y * worldWidth];
				if (tile != null)
					tile.transform.position.Set (x * tileSize, y * tileSize, 0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (focus.transform.position.x > worldWidth * tileSize) {
			focus.transform.position -= new Vector3(worldWidth * tileSize, 0, 0);
		} else if (focus.transform.position.x < 0) {
			focus.transform.position += new Vector3(worldWidth * tileSize, 0, 0);
		}
		if (focus.transform.position.y > worldHeight * tileSize) {
			focus.transform.position -= new Vector3(0, worldWidth * tileSize, 0);
		} else if (focus.transform.position.y < 0) {
			focus.transform.position += new Vector3(0, worldWidth * tileSize, 0);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.white;
		Vector3 tl = new Vector3 (0, worldHeight * tileSize, 0);
		Vector3 tr = new Vector3 (worldWidth * tileSize, worldHeight * tileSize, 0);
		Vector3 bl = new Vector3 (0, 0, 0);
		Vector3 br = new Vector3 (worldWidth * tileSize, 0, 0);
		Vector3[] box = { tl, tr, br, bl };
		for (int i = 0;i < box.Length;i++) {
			Gizmos.DrawLine (box [i], box [i == box.Length - 1 ? 0 : i + 1]);
		}
	}
}
