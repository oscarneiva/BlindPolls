using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_canvas : MonoBehaviour {

    //PARAMETROS DA UI
    public GameObject barra_vida;
    public GameObject contador;
    public GameObject gameover;

    //EFEITO PARA DESTRUIR A VIDA
    public GameObject efeito;

    //PARAMETROS DE CONTROLE
    private int life = 4;
    private int tiros = 0;
    private int especial = 0;

    //USADO PARA ATIVAR E DESATIVAR MENSAGENS
    private bool ativo = true;

    // Use this for initialization
    void Start () {
        desenha_corações();
    }
	
	// Update is called once per frame
	void Update () {

        //TESTE
        if (Input.GetKeyDown(KeyCode.A))
        {
            Hit_player();
        }

	}

    //MODIFICA PARAMENTRO DE CNTROLE DE VIDA E ATUALIZA
    void Hit_player()
    {
        life--;
        desenha_corações();
    }

    //DESENHA AS REPRESENTAÇÕES DA VIDA DO PLAYER
    //DESENHA TAMBÉM O GAME OVER
    void desenha_corações()
    {
        if (life >= 4)
        {
            //BARRA VIDA 100%
        }
        else if (life == 3)
        {
            //BARRA VIDA 75%
        }
        else if (life == 2)
        {
            //BARRA VIDA 50%
        }
        else if (life == 1)
        {
            //BARRA VIDA 25%
        }
        else
        {
            //BARRA VIDA 0%
            //gameover.gameObject.SetActive(ativo);
            
        }
    }

}
