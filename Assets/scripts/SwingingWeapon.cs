using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingWeapon : MonoBehaviour {
    public float swingAngle = 180;
    public float targetAngle;
    public float duration;
    private float progress = 0;
    // Use this for initialization
    void Start () {
        transform.RotateAround(transform.parent.position, Vector3.back, getAngleAtTime(0));
    }
	
	// Update is called once per frame
	void Update ()
    {
        float previousAngle = getAngleAtTime(progress);
        progress += Time.deltaTime;
        float percentThrough = progress / duration;
        float currentAngle = getAngleAtTime(progress);
        transform.RotateAround(transform.parent.position, Vector3.back, (currentAngle - previousAngle));
        if (percentThrough >= 1)
        {
            Destroy(gameObject);
        }
	}

    private float getAngleAtTime(float t)
    {
        return Mathf.LerpAngle(targetAngle - swingAngle / 2, targetAngle + swingAngle / 2, t / duration);
    }
}
