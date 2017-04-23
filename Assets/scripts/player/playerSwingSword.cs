using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwingSword : MonoBehaviour {

    public GameObject swingingWeaponPrefab;
    public float swingDuration;
    private GameObject swingObject;
    Rigidbody2D rb2d;
    Rigidbody2D swordRb2d;
    Vector3 playerPosition;
    bool isCreated = false;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        
        //Create sword and disable it
        swingObject = Instantiate(swingingWeaponPrefab, rb2d.position, Quaternion.AngleAxis(90, new Vector3(0, 0, 1)));
        swordRb2d = swingObject.GetComponent<Rigidbody2D>();
        swingObject.SetActive(false);
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
        swingObject.transform.position = new Vector2(-0.5f, 0) + rb2d.position;
        if (!isCreated)
        {
            swingObject.SetActive(true);
            isCreated = true;
        }
        else
        {
            swingObject.SetActive(false);
            isCreated = false;
        }

    }

    private void swing()
    {
        
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(swingDuration);
    }
}
