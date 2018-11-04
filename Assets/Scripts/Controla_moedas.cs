using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_moedas : MonoBehaviour {

    //CONTADORES
    private int count = 0;
    private float tempo = 0;

    //MOEDA
    public GameObject moeda;
    public GameObject poster;

    //SPANW POINTS
    public int max;
    public Transform direita_camera;
    public Transform esqueda_camera;
    public Transform dentro_camera;
    public float wait;

    private bool cria = true;

    //SORTEIO
    private int random;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (cria)
        {
            tempo += Time.deltaTime;
            if (tempo >= wait)
            {
                if (count < max)
                {
                    random = Random.Range(1, 3);
                    if (random == 2)
                    {
                        print("POSTER");
                        cria_poster();
                    }
                    else
                    {
                        cria_moeda();
                    }
                }
                tempo = 0;
            }
        }
            
	}

    public void GAME_OVER()
    {
        cria = false;
    }

    public void cria_poster()
    {
        random = Random.Range(1, 2);
        float x, y;
        x = Random.Range(esqueda_camera.position.x / 2, direita_camera.position.x / 2);
        y = Random.Range(15f, 80f);
        Vector3 pos = new Vector3(x, y, 0f);
        GameObject nova_poster = Instantiate(poster, pos, dentro_camera.rotation);
        count++;
    }

    public void cria_moeda()
    {
        random = Random.Range(1, 2);
        float x, y;
        x = Random.Range(esqueda_camera.position.x/2, direita_camera.position.x/2);
        y = Random.Range(15f, 80f);
        Vector3 pos = new Vector3(x, y, 0f);
        GameObject nova_moeda = Instantiate(moeda, pos, dentro_camera.rotation);
        count++;
    
    }

    public void destruiu()
    {
        count--;
    }
}
