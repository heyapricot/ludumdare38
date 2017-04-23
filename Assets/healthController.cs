using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour {
    public float health = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(this.gameObject.name + "'s health: " + health);
        isDead();
	}

    private bool isDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }

    }
}
