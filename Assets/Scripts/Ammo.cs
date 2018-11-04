using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

	public bool solta;
	public GameObject pai;
	public float speed;

	public bool parado;
	
	private GameObject player;

	private Vector3 player_pos;
	
	// Use this for initialization
	void Start () {
		parado = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (parado)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			player_pos = player.transform.position;

			if (gameObject.transform.position.x < (player_pos.x + 1.0f) &&
			     (gameObject.transform.position.x > (player_pos.x - 1.0f)))
			{
				parado = false;
				gameObject.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
				transform.SetParent(null);
				
			}
		}

	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("hit");
            Destroy(gameObject);
        }
    }

}
