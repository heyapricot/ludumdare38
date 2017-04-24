using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropController : MonoBehaviour {
    Vector3 position = Vector3.one;
    public GameObject loot;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDisable()
    {
        if (GetComponent<healthController>().isDead())
        {
            position = transform.position;
            Instantiate(loot, position, Quaternion.identity);
        }
    }
}
