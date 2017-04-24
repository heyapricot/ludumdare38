using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour {

    public enum directions { down = 0, right, up, left };
    public int strength = 5;
    public int speed = 4;
    int face_direction = 0;
    GameObject levelManager;

    // Use this for initialization
    void Start () {
        levelManager = GameObject.Find("LevelManager");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public int getFaceDirection()
    {        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        if (y > 0) //Facing up
        {
            face_direction = (int)directions.up;
        }
        else if (y< 0) //Facing down
        {
            face_direction = (int)directions.down;
        }
        else if (x > 0) //Facing right
        {
            face_direction = (int)directions.right;
        }
        else if (x< 0) //Facing left
        {
            face_direction = (int)directions.left;
        }

        return face_direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Asset":
                Debug.Log("Player was touched by an asset");
                break;
            case "Missile":
                Debug.Log("Player was touched by a missile");
                GetComponent<healthController>().health -= 1;
                break;
            case "Enemy":
                Debug.Log("Player was touched by an enemy");
                GetComponent<healthController>().health -= 10;
                break;
        }
    }

    private void OnDisable()
    {
        levelManager.GetComponent<LevelManager>().GameOver();
    }
}
