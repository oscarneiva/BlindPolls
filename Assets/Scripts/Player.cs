using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //ANIMATOR
    private Animator anima;

    //OBJETOS DE REFERENCIA
    public GameObject municao_dir;
    public GameObject municao_esq;
    public GameObject explosao;
    public GameObject pe;

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
    private bool fly;
    private bool speed;
    private bool olhando_dir;
    private bool move;

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
    private int quant_tiros = 0;
    private float tempo;
    private float tempo_especial = 0;
    private int vida = 5;
    private int inimigos_derrotados = 10;

    // Use this for initialization
    void Start () {
        anima = gameObject.GetComponent<Animator>();
        ground = GameObject.FindGameObjectWithTag("ground");
        move = false;
        olhando_dir = true;
        jump = true;
        tiro = true;
        fly = false;
        //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

        pos_player = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update () {

        if (fly)
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

    public void checa_animacao()
    {
        if (jump)
        {
            anima.SetBool("jump", true);
        }
        else
        {
            anima.SetBool("jump", false);
        }

        if (fly)
        {
            anima.SetBool("fly", true);
        }
        else
        {
            anima.SetBool("fly", false);
        }

        if (olhando_dir)
        {
            anima.SetBool("direita", true);
        }
        else
        {
            anima.SetBool("direita", false);
        }

        if (move)
        {
            anima.SetBool("move", true);
        }
        else
        {
            anima.SetBool("move", false);
        }

    }

    public void especial()
    {
        if(gameObject.transform.position.y < (ground.transform.position.y + 300.0f))
        {
            print("aqui");
            print(gameObject.transform.position.y);
            gameObject.transform.Translate(0, vel_fly*Time.deltaTime, 0);
        }
        else
        {
            if (tempo_especial > 1.5f)
            {
                fly = false;
                checa_animacao();
                //INSTANCIAR EFEITO DE ESPECIAL AQUI
                //DESTRUIR TODOS OS INIMIGOS AQUI
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 4.3f;
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
        else
        {
            tiro = true;
        }
    }

    public void carrega_tiro()
    {
        if(quant_tiros < 15)
        {
            quant_tiros++;
            checa_tiro();
        }
 
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
        if (Input.GetKeyDown(KeyCode.W) && (!jump) && (inimigos_derrotados >= 10) && (!fly))
        {
            fly = true;
            inimigos_derrotados = 0;
            checa_animacao();
        }
    }

    //DETECTA A AÇÃO DE PULO E CONFIGURA OS PARAMETROS NECESSÁRIOS
    public void jump_pressed()
    {
        if (!jump && (Input.GetKeyDown(KeyCode.Space)) && !fly)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 17500.0f));
            //gameObject.transform.Translate(0, 1.0f, 0);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 40.0f;
            jump = true;
            pe.SendMessage("checa");
            checa_animacao();
        }
    }

    public void movimenta()
    {
        move = false;

        //MOVE DIREITA
        if (Input.GetKey(KeyCode.RightArrow) && (!fly))
        {
            gameObject.transform.Translate(vel_pers_hor * Time.deltaTime, 0, 0);
            olhando_dir = true;
            move = true;
        }
        //MOVE ESQUERDA
        if (Input.GetKey(KeyCode.LeftArrow) && (!fly))
        {
            gameObject.transform.Translate(-vel_pers_hor * Time.deltaTime, 0, 0);
            olhando_dir = false;
            move = true;
        }

        checa_animacao();

        jump_pressed();

        special_pressed();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.00001f;
            gameObject.transform.Translate(0, 0.3f, 0);
            jump = false;
            pe.SendMessage("checa");
        }


        if(collision.gameObject.tag == "Finish_left")
        {
            gameObject.transform.Translate(8.5f, 0, 0);
        }
        else if(collision.gameObject.tag == "Finish_right")
        {
            gameObject.transform.Translate(-8.5f, 0, 0);
        }
    }

    public void instancia_tiro()
    {
        if (Input.GetKeyDown(KeyCode.Q) && (tiro))
        {
            quant_tiros--;
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
