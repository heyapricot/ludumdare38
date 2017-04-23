using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwingWeapon : MonoBehaviour {
    GameObject weapon;
    Vector3 playerPosition;
    bool weaponOut = false;
	// Use this for initialization
	void Start () {
        
        //Weapon is the first child of player
        weapon = this.gameObject.transform.GetChild(0).gameObject;
        //Hide weapon
        weapon.SetActive(false);

        //Get player
        playerPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        trigger_swing();
	}

    private void trigger_swing()
    {
        if (Input.GetKeyDown("space"))
            drawWeapon();
    }

    private void drawWeapon()
    {
        if (!weaponOut)
        {
            weapon.SetActive(true);
            weaponOut = true;
        }
        else
        {
            weapon.SetActive(false);
            weaponOut = false;
        }

    }
}
