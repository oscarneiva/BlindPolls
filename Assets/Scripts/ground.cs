using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour {

    //VARIAVEIS DE CONTROLE DE POSICIONAMENTO E MOVIMENTAÇÃO DO PLAYER
    public float lim_dir;
    public float lim_esq;
    public float lim_cima;
    public float lim_baixo;

    //VELOCIDADES USADAS
    public float vel_ground_hor;
    //public float vel_groun_ver;

    public bool speed = false;
    public bool fly = false;

    //POS ATUAL DO PLAYER
    private Vector3 pos_player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos_player = gameObject.transform.position;

        movimenta();
    }

    public void especial()
    {
        fly = !fly;
    }

    public void movimenta()
    {
        //MOVE DIREITA
        if (Input.GetKey(KeyCode.RightArrow) && (pos_player.x < lim_dir) && (!fly))
        {
            gameObject.transform.Translate(vel_ground_hor, 0, 0);
        }
        //MOVE ESQUERDA
        if (Input.GetKey(KeyCode.LeftArrow) && (pos_player.x > lim_esq) && (!fly))
        {
            gameObject.transform.Translate(-vel_ground_hor, 0, 0);
        }
        
    }

    public void double_speed()
    {
        vel_ground_hor = vel_ground_hor * 2;
    }

    public void half_speed()
    {
        vel_ground_hor = vel_ground_hor / 2;
    }

}
