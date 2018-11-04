using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeca : MonoBehaviour {

    public GameObject parent;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void acertou()
    {
        Destroy(parent, 0.15f);
        
        //INSTANCIAR A EXPLOSAO AQUI DE ACORDO COM ESSA POSICAO

        Destroy(gameObject);
    }
}
