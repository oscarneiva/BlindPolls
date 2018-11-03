using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBondaryCollisions : MonoBehaviour
{
    GameObject player;
    Camera myCamera;
    float xSpawn;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        xSpawn = myCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x+30;
        if (transform.position.x < 0f)
            xSpawn = xSpawn * -1f;
        transform.position = new Vector3(xSpawn, transform.position.y, transform.position.z);
    }
}
