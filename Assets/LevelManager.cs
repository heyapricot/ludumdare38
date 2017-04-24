using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
        isGameOver(player);
	}

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public bool isGameOver(GameObject player)
    {
        if (player.GetComponent<healthController>().isDead())
        {
            StartCoroutine(delay(3.0f));
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        LoadLevel("00_menu");
    }

}
