using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class FlyScrpt : MonoBehaviour {

	public float speed = 2.0f;
	public Transform alvo;
    private bool andar = true;
	public float distancia = 12.0f;
	public float distAtack = 10.0f;
    public float flutuation = 10f;
    public GameObject explosao;
 
	
	
	// Use this for initialization
	void Start () {
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        if(transform.position.x>alvo.transform.position.x)
			speed = -speed;
 
	}
	
	// Update is called once per frame
	void Update () {
		

	//	transform.LookAt(alvo.position);
        if(andar)
		transform.Translate(speed*Time.deltaTime,(float) Math.Sin(transform.position.x/50)*Time.deltaTime*flutuation, 0);
		
	
	
		
	
		
	//	transform.position = new Vector2(Mathf.PingPong (Time.deltaTime*speed , 5), transform.position.z);
	//	transform.position = new Vector2(transform.position.x, Mathf.PingPong(Time.deltaTime*speed , 5));
		
	}

    public void parou()
    {
        andar = false;
    }

    public void destroi()
    {
        GameObject nova_explosao = Instantiate(explosao, gameObject.transform.position, explosao.transform.rotation);
        Destroy(nova_explosao, 1.0f);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("hit");
            destroi();
        }
    }
}
