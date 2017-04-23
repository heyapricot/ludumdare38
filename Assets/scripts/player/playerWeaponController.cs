using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponController : MonoBehaviour {
    GameObject weapon;
	// Use this for initialization
	void Start () {
        //Weapon is the first child of player
        weapon = this.gameObject.transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        followPlayer();
	}

    void followPlayer()
    {
        weapon.transform.position = transform.position + new Vector3(-0.6f, 0, 0);
    }
}
