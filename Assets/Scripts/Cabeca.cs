using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeca : MonoBehaviour {

    public GameObject parent;
    public GameObject explosao;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroi()
    {
        acertou();
    }

    public void acertou()
    {
        Destroy(parent, 0.15f);

        //INSTANCIAR A EXPLOSAO AQUI DE ACORDO COM ESSA POSICAO
        GameObject nova_explosao = Instantiate(explosao, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(nova_explosao, 1.0f);

        Destroy(gameObject);
    }
}
