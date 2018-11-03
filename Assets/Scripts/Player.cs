using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //OBJETOS DE REFERENCIA
    public GameObject municao_dir;
    public GameObject municao_esq;
    public GameObject explosao;

    private GameObject ground;

    //VARIAVEIS DE CONTROLE DE POSICIONAMENTO E MOVIMENTAÇÃO DO PLAYER
    public float lim_dir;
    public float lim_esq;
    public float lim_cima;
    public float lim_baixo;
    private float lim_jump;
    private float lim_fly;

    //BOOLEANOS DE CONTROLE
    private bool jump;
    private bool tiro;
    public bool fly;
    public bool special;
    private bool speed;
    private bool olhando_dir;

    //VELOCIDADES USADAS
    public float vel_pers_hor;
    public float vel_pers_ver;
    public float vel_fly;
    public float vel_tiro;

    //POS ATUAL DO PLAYER
    private Vector3 pos_player;

    //POS TIRO
    private Vector3 pos_tiro;

    //QUANTIDADES ARMAZENADAS
    private int quant_tiros = 10;
    private float tempo;
    private float tempo_especial = 0;
    private int vida = 5;
    private int inimigos_derrotados = 10;

    // Use this for initialization
    void Start () {
        olhando_dir = true;
        jump = false;
        tiro = false;
        special = false;
        fly = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
        ground = GameObject.FindGameObjectWithTag("ground");
        pos_player = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update () {

        if ((fly)&&(special))
        {
            especial();
        }
        else
        {
            movimenta();
            if (speed)
            {
                checa_speed();
            }
            if (tiro)
            {
                instancia_tiro();
                checa_tiro();
            }
        }

        //TEM QUE FICAR NO FINAL DO GAME LOOP 
        pos_player = gameObject.transform.position;
    }

    public void especial()
    {
        if(gameObject.transform.position.y < (ground.transform.position.y + 150.0f))
        {
            gameObject.transform.Translate(0, vel_fly*9.8f* Time.deltaTime, 0);
        }
        else
        {
            if (tempo_especial > 1.5f)
            {
                fly = false;
                //INSTANCIAR EFEITO DE ESPECIAL AQUI
                //DESTRUIR TODOS OS INIMIGOS AQUI
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
                inimigos_derrotados = 0;
            }
            else
            {
                tempo_especial += Time.deltaTime;
            }
        }
    }

    public void checa_tiro()
    {
        if(quant_tiros <= 0)
        {
            tiro = false;
        }
    }

    public void carrega_tiro()
    {
        quant_tiros = 10;
    }

    public void checa_speed()
    {
        tempo += Time.deltaTime;
        if (tempo > 2.0f)
        {
            tempo = 0;
            speed = false;
            vel_pers_hor = vel_pers_hor / 2;
        }
    }

    public void double_speed()
    {
        speed = true;
        vel_pers_hor = vel_pers_hor * 2;
    }

    //DETECTA A AÇÃO DE USAR O ESPECIAL E, CASO HABILITADO, CHAMA
    public void special_pressed()
    {
        if (Input.GetKeyDown(KeyCode.W) && (!jump) && (inimigos_derrotados >= 10) && (!special))
        {
            fly = true;
            special = true;
            gameObject.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        }
    }

    //DETECTA A AÇÃO DE PULO E CONFIGURA OS PARAMETROS NECESSÁRIOS
    public void jump_pressed()
    {
        if (!jump && (Input.GetKeyDown(KeyCode.Space)) && !fly)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5000.0f));
            //gameObject.transform.Translate(0, 1.0f, 0);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 9.8f;
            jump = true;
        }
    }

    public void movimenta()
    {
        //MOVE DIREITA
        if ((Input.GetKey(KeyCode.RightArrow)))
        {
            if ( (!fly) && (special==false) )
            {
                gameObject.transform.Translate(vel_pers_hor* Time.deltaTime, 0, 0);
                olhando_dir = true;
            }

        }
        //MOVE ESQUERDA
        if (Input.GetKey(KeyCode.LeftArrow)  && (!fly))
        {
            if ((!fly) && (special == false) )
            {
                gameObject.transform.Translate(-vel_pers_hor*Time.deltaTime, 0, 0);
                olhando_dir = false;
            }

        }

        jump_pressed();

        special_pressed();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.transform.Translate(0, 0.02f, 0);
            jump = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            special = false;
        }
    }

    public void instancia_tiro()
    {
        if (Input.GetKeyDown(KeyCode.Q) && (tiro))
        {
            quant_tiros--;
            if (!special)
            {
                if (olhando_dir)
                {
                    GameObject novo_tiro = Instantiate(municao_dir, transform.position, transform.rotation);
                }
                else
                {
                    GameObject novo_tiro = Instantiate(municao_esq, transform.position, transform.rotation);
                }
            }
        }
    }

}
