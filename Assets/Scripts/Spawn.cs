using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private float tempo = 0;
    private int count = 0;
    private int random;

    public GameObject esquerda_camera;
    public GameObject direita_camera;
    public int max;
    private float wait = 5;
    private float tempo_aumenta_spaw = 0;
    private bool aumenta_spaw = false;
    public GameObject drone;
    public GameObject sheep;
    public GameObject lhama;
    public GameObject direitaDrone, esquerdaDrone;
    private GameObject drone_correto;
    private GameObject[] vetor_inimigo;

    private bool andar = true;
    //public GameObject lhama;

    // Use this for initialization
    void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        vetor_inimigo = GameObject.FindGameObjectsWithTag("Inimigo");
        count = vetor_inimigo.Length;
        tempo += Time.deltaTime;

        tempo_aumenta_spaw += Time.deltaTime;
        
        if (tempo >= wait)
        {
            if ((count < max) && andar)
            {
                random = Random.Range(0, 5);
                if(random <= 1)
                {
                    cria_drone();
                }
                /*
                else if(random == 1)
                {
                    //cria_lhama();
                }
                */
                else
                {
                    cria_ovelha();
                }
            }
            tempo = 0;
        }

        if(tempo_aumenta_spaw >= 20.0f)
        {
            if (!aumenta_spaw)
            {
                wait = 3;
                aumenta_spaw = true;
                tempo_aumenta_spaw = 0;
            }
            else
            {
                wait = 1;
                aumenta_spaw = true;
                tempo_aumenta_spaw = 0;
            }
            
        }
    }

    public void parou()
    {
        andar = !andar;
    }

    public void cria_ovelha()
    {
        Vector3 posicao;
        random = Random.Range(0, 2);
        if (random == 1)
        {
            posicao = new Vector3(esquerda_camera.transform.position.x,
                sheep.transform.position.y, 0);
        }
        else
        {
            posicao = direita_camera.transform.position;
            posicao = new Vector3(direita_camera.transform.position.x,
                sheep.transform.position.y, 0);
        }

        GameObject novo_drone = Instantiate(sheep, posicao, drone.transform.rotation);
        //count++;
    }

    public void cria_lhama()
    {
        Vector3 posicao;
        random = Random.Range(0, 2);
        if (random == 1)
        {
            posicao = new Vector3(esquerda_camera.transform.position.x,
                lhama.transform.position.y, 0);
        }
        else
        {
            posicao = direita_camera.transform.position;
            posicao = new Vector3(direita_camera.transform.position.x,
                lhama.transform.position.y, 0);
        }

        GameObject novo_drone = Instantiate(lhama, posicao, drone.transform.rotation);
       // count++;
    }

    public void cria_drone()
    {
        Vector3 posicao;
        random = Random.Range(0, 2);
        print(random);
        if (random == 1)
        {
            posicao = new Vector3(esquerda_camera.transform.position.x,
                155.0f, 0);
            drone_correto = esquerdaDrone;
        }
        else
        {
            posicao = new Vector3(direita_camera.transform.position.x,
                155.0f, 0);
            drone_correto = direitaDrone;
        }

        GameObject novo_drone = Instantiate(drone_correto, posicao, drone.transform.rotation);
        //count++;
    }
}
