using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municao : MonoBehaviour {

    public bool olha_dir;

    private float vel = 5.0f;
    private float set = 4.0f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2.0f);

        if (!olha_dir)
        {
            vel = -vel;
            set = -set;
        }
        gameObject.transform.Translate(set, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(vel, 0, 0);
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Inimigo")
        {
            collision.gameObject.SendMessage("destroi");
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "cabeca")
        {
            collision.gameObject.SendMessage("acertou");
            Destroy(gameObject);
        }
    }

}
