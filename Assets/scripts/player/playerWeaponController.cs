using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponController : MonoBehaviour {

    private playerStatus getPlayerStatus;

    GameObject weapon;
	// Use this for initialization
	void Start () {
        //Weapon is the first child of player
        weapon = this.gameObject.transform.GetChild(0).gameObject;
        //Get player status
        getPlayerStatus = this.GetComponent<playerStatus>();
    }
	
	// Update is called once per frame
	void Update () {
        followPlayer();
	}

    void followPlayer()
    {
        
        switch (getPlayerStatus.getFaceDirection())
        {
            case (int)playerStatus.directions.up:
                weapon.transform.position = transform.position + new Vector3(0, 1.0f , 0);
                break;
            case (int)playerStatus.directions.down:
                weapon.transform.position = transform.position + new Vector3(0, -1.0f, 0);
                break;
            case (int)playerStatus.directions.left:
                weapon.transform.position = transform.position + new Vector3(-0.6f, 0, 0);
                break;
            case (int)playerStatus.directions.right:
                weapon.transform.position = transform.position + new Vector3(0.6f, 0, 0);
                break;
        }
    }
}
