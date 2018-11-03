using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float posX, posY;
    public Vector3 offset = new Vector3(0f, 7.5f, 0f);
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //limite direita 572 
        //limete esquerda -572
        posX = transform.position.x;
        posY = transform.position.y;
        if( ( player.transform.position.x > -572F ) && ( player.transform.position.x < 572f))
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

}
