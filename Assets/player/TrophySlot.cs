using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophySlot : MonoBehaviour {
	public DrakeAI.DrakeColor color;
	GameObject filled;
	float targetScale = 1f;
	float blinkScale = 1.35f;
	float blinkDuration = 0.5f;
	float blinkProgress = 0;
	// Use this for initialization
	void Start () {
		filled = transform.FindChild ("Filled").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (filled.activeSelf) {
			blinkProgress += Time.deltaTime;
			if (blinkProgress < blinkDuration) {
				float difference = targetScale - blinkScale;
				float proportion = (blinkProgress / blinkDuration);
				float scale = blinkScale + proportion * difference;
				filled.transform.localScale = Vector3.one * scale;
			} else {
				filled.transform.localScale = Vector3.one;
			}
		}
	}

	public void Obtain() {
		filled.SetActive (true);
		blinkProgress = 0;
	}
}
