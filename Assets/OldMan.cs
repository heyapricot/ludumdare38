using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class OldMan : MonoBehaviour {
	Animator animator;
	TextMesh textMesh;
	const string StartHook = "Oh my! There's drakes nesting to the north again!\nGo clear them out, go!";
	const string AnnoyedHook = "What are you still doing here!? Go!";
	const string RedHook = "Gee! That's a big one, but I thought I saw a green one earlier.\nMy eyesight might just be going, but can you check for other nests?";
	const string GreenHook = "Goodness! I told you, green!\nThere aren't any more, are there?";
	const string BlackHook = "Dear me! I would not have seen that if it were right on top of me!\nWhere do they keep coming from!?";
	const string BlueHook = "My stars! As blue as the sky and twice as deadly!\nErr, wait, no.";
	const string BlueRehook = "Nevermind that sky stuff, just go get the rest of them!";
	const string DoneHook = "Thank you, my boy. I think you got them all.";
	int talkCount = 0;
	Dictionary<DrakeAI.DrakeColor, bool> retrieved = new Dictionary<DrakeAI.DrakeColor, bool> ();
	Dictionary<DrakeAI.DrakeColor, string> retrieveText = new Dictionary<DrakeAI.DrakeColor, string> ();
	// Use this for initialization
	void Start () {
		textMesh = GetComponentInChildren<TextMesh> ();
		animator = GetComponent<Animator> ();
		retrieveText.Add (DrakeAI.DrakeColor.BLUE, BlueHook);
		retrieveText.Add (DrakeAI.DrakeColor.BLACK, BlackHook);
		retrieveText.Add (DrakeAI.DrakeColor.GREEN, GreenHook);
		retrieveText.Add (DrakeAI.DrakeColor.RED, RedHook);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Talk(GameObject player) {
		string expression = null;
		string animation = "Excited";
		if (talkCount == 0) { // Never spoken.
			expression = StartHook;
			talkCount = 1;
		} else if (talkCount == -1) { // Blue speak.
			expression = BlueRehook;
			talkCount = 1;
		} else {
			TrophyHunter trophies = player.GetComponentInChildren<TrophyHunter> ();
			foreach (DrakeAI.DrakeColor color in Enum.GetValues(typeof(DrakeAI.DrakeColor))) {
				bool has = trophies.HasTrophy (color);
				bool shown = retrieved.ContainsKey (color);
				if (has && !shown) {
					retrieved.Add (color, true);
					expression = retrieveText [color];
					if (color == DrakeAI.DrakeColor.BLUE) {
						talkCount = -1;
					} else {
						talkCount = 1;
					}
					break;
				}
			}
		}
		if (expression == null) {
			if (retrieved.Count == 4) {
				expression = DoneHook;
			} else {
				expression = AnnoyedHook;
			}
		}
		textMesh.text = expression;
		animator.Play (animation);
	}

	public void Quiet() {
		textMesh.text = "";
		animator.Play ("Stand");
	}
}
