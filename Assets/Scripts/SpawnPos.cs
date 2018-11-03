using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPos : MonoBehaviour {
    Camera myCamera;
    float xSpawn;
    // Use this for initialization
    void Start () {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        xSpawn = myCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        xSpawn = (xSpawn + 20);
        if (transform.position.x < 0f)
            xSpawn *= -1f;
        transform.position = new Vector3(xSpawn, transform.position.y, transform.position.z);
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
