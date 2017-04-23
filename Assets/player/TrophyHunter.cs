using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyHunter : MonoBehaviour {
	public GameObject[] trophySlots;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FillSlot(DrakeAI.DrakeColor color) {
		Debug.Log (color);
		foreach (GameObject slotObj in trophySlots) {
			TrophySlot slot = slotObj.GetComponent<TrophySlot> ();
			Debug.Log (slot.color);
			if (slot.color.Equals(color))
				slot.Obtain ();
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		Trophy trophy = other.GetComponent<Trophy> ();
		if (trophy != null) {
			FillSlot (trophy.color);
			Destroy (other.gameObject);
		}
	}
}
