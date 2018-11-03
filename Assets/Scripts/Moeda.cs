using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour {

    //Parametros
    private float tempo = 0;
    private float offset_vertical = 3.0f;
    private float offset_horizontal = 2.5f;
    private float pos_x;
    private float pos_y;

	// Use this for initialization
	void Start () {
        pos_x = gameObject.transform.position.x;
        pos_y = gameObject.transform.position.y;

        gameObject.transform.Translate(Random.Range((pos_x - offset_horizontal), (pos_x + offset_horizontal)),
            Random.Range(pos_y, (pos_y + offset_vertical)), 0);

	}
	
	// Update is called once per frame
	void Update () {
        tempo += Time.deltaTime;
        if(tempo >= 15.0f)
        {
            destruir();
        }
	}

    public void destruir()
    {
        GameObject controla = GameObject.FindGameObjectWithTag("MainCamera");
        controla.SendMessage("destruiu");
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            print("u cant touch me");
            //ADICIONA PONTUAÇÃO
            destruir();
        }
    }
}
