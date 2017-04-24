using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWeaponController : MonoBehaviour {

    private playerStatus getPlayerStatus;

	public GameObject drawnWeapon;
	// Use this for initialization
	void Start () {
        //Get player status
        getPlayerStatus = this.GetComponent<playerStatus>();
    }
	
	// Update is called once per frame
	void Update () {
        trigger_swing();
		if (GetComponentInChildren<weaponStatus> () != null) {
			followPlayer (GetComponentInChildren<weaponStatus> ().gameObject);
		}
    }

    private void trigger_swing()
    {
        if (Input.GetKeyDown("space"))
            drawWeapon();
    }

    private void drawWeapon()
    {
		if (GetComponentInChildren<weaponStatus>() == null)
        {
			GameObject weapon = Instantiate (drawnWeapon, transform);
			Destroy (weapon, 0.25f);
			followPlayer (weapon);
        }
    }

	void followPlayer(GameObject weapon)
    {
        
        switch (getPlayerStatus.getFaceDirection())
        {
            case playerStatus.directions.up:
                weapon.transform.position = transform.position + new Vector3(0, 1.0f , 0);
                weapon.transform.localRotation = Quaternion.identity;
                break;
            case playerStatus.directions.down:
                weapon.transform.position = transform.position + new Vector3(0, -1.0f, 0);
                weapon.transform.localRotation = Quaternion.AngleAxis(180, Vector3.forward);
                break;
            case playerStatus.directions.left:
                weapon.transform.position = transform.position + new Vector3(-0.6f, 0, 0);
                weapon.transform.localRotation = Quaternion.AngleAxis(90, Vector3.forward);
                break;
            case playerStatus.directions.right:
                weapon.transform.position = transform.position + new Vector3(0.6f, 0, 0);
                weapon.transform.localRotation = Quaternion.AngleAxis(270, Vector3.forward);
                break;
        }
    }
}
