using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float width = 32;
    public float height = 2f;
    private float maxHealth;
    private healthController health;
    private Texture2D green;
    private Texture2D red;
    // Use this for initialization
    void Start()
    {
        health = GetComponent<healthController>();
        maxHealth = health.health;
        red = new Texture2D(1, 1);
        red.SetPixel(0, 0, Color.red);
        red.wrapMode = TextureWrapMode.Repeat;
        red.Apply();
        green = new Texture2D(1, 1);
        green.SetPixel(0, 0, Color.green);
        green.wrapMode = TextureWrapMode.Repeat;
        green.Apply();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        float healthPercent = health.health / maxHealth;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        screenPoint.y = Screen.height - screenPoint.y;
        screenPoint.y -= GetComponent<SpriteRenderer>().bounds.extents.y * Camera.main.pixelHeight / Camera.main.orthographicSize / 2;
        screenPoint.x -= width / 2;
        GUI.DrawTexture(new Rect(screenPoint, new Vector2(width, height)), red);
        GUI.DrawTexture(new Rect(screenPoint, new Vector2(width * healthPercent, height)), green);
    }
}
