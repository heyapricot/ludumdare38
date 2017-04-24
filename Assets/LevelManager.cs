using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void GameOver()
    {
            StartCoroutine(delay(3.0f));
    }

    IEnumerator delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        LoadLevel("00_menu");
    }

}
