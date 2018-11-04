using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial : MonoBehaviour {

    private float tempo = 0;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        tempo += Time.deltaTime;
        if (tempo >= 15.0f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("special_pressed");
            //destruir();
            Destroy(gameObject);
        }
    }
}
