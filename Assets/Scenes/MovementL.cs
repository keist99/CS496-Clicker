using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovementL : MonoBehaviour
{
    float posX = 150, posY = 450;

    private float TimeL, TimeR, TimeU, TimeD, nextL, nextR, nextU, nextD;

    float Horizontal, Vertical;

    public float speed;

    bool pressed = false;

    GameObject Spaceship;

    // Start is called before the first frame update
    void Start()
    {
        TimeL = TimeR = TimeU = TimeD = 0.05f;
        nextL = nextR = nextU = nextD = 0.0f;
        posX = GameObject.Find("Spaceship").transform.position.x;
        posY = GameObject.Find("Spaceship").transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        posX = GameObject.Find("Spaceship").transform.position.x;
        posY = GameObject.Find("Spaceship").transform.position.y;
        if (pressed)
        {
            if (Time.time > nextL)
            {
                nextL = Time.time + TimeL;
                posX -= 0.5f * speed;
            }
        }
        GameObject.Find("Spaceship").transform.position = new Vector3(posX, posY, 0);
    }

    public void OnPointerDown()
    {
        pressed = true;
    }

    public void OnPointerUp()
    {
        pressed = false;
    }
}
