using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pe : MonoBehaviour {

    public GameObject parent;
    private bool ok = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void checa()
    {
        ok = !ok;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "cabeca") && ok)
        {
            collision.gameObject.SendMessage("acertou");
            parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8000.0f));
        }
    }
}
