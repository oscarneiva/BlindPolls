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
    public float wait;
    public GameObject drone;
    public GameObject sheep;
    public GameObject lhama;
    public GameObject direitaDrone, esquerdaDrone;
    private GameObject drone_correto;
    //public GameObject lhama;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        tempo += Time.deltaTime;
        if (tempo >= wait)
        {
            if (count < max)
            {
                random = Random.Range(0, 3);
                if(random == 0)
                {
                    cria_drone();
                }
                else if(random == 1)
                {
                    cria_ovelha();
                }
                else
                {
                    cria_lhama();
                }
            }
            tempo = 0;
        }
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
        count++;
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
        count++;
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
        count++;
    }
}
