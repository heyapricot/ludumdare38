using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponController : MonoBehaviour {

    private playerStatus getPlayerStatus;

    GameObject weapon;
    bool weaponOut = false;
	// Use this for initialization
	void Start () {
        //Weapon is the first child of player
        weapon = this.gameObject.transform.GetChild(0).gameObject;
        //Hide weapon
        weapon.SetActive(false);
        //Get player status
        getPlayerStatus = this.GetComponent<playerStatus>();
    }
	
	// Update is called once per frame
	void Update () {
        followPlayer();
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

    void followPlayer()
    {
        
        switch (getPlayerStatus.getFaceDirection())
        {
            case (int)playerStatus.directions.up:
                weapon.transform.position = transform.position + new Vector3(0, 1.0f , 0);
                weapon.transform.localRotation = Quaternion.identity;
                break;
            case (int)playerStatus.directions.down:
                weapon.transform.position = transform.position + new Vector3(0, -1.0f, 0);
                weapon.transform.localRotation = Quaternion.AngleAxis(180, Vector3.forward);
                break;
            case (int)playerStatus.directions.left:
                weapon.transform.position = transform.position + new Vector3(-0.6f, 0, 0);
                weapon.transform.localRotation = Quaternion.AngleAxis(90, Vector3.forward);
                break;
            case (int)playerStatus.directions.right:
                weapon.transform.position = transform.position + new Vector3(0.6f, 0, 0);
                weapon.transform.localRotation = Quaternion.AngleAxis(270, Vector3.forward);
                break;
        }
    }
}
