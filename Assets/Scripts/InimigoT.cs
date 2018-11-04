using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InimigoT : MonoBehaviour
{


	public float speed = 3.0f;
	public bool esquerda ;
	private GameObject player;
	private Vector3 player_pos;
	public Rigidbody2D inirb;
    public Animator animator;
	public bool podeMover = true;
    public GameObject cabeca;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        /*
        if (player.transform.position.x - transform.position.x < 0. )
        {
            esquerda = true;
        }
        else
        {
            esquerda = false;
        }
        */
    }

	// Update is called once per frame
	void Update()
	{
		player_pos = player.transform.position;
		if (podeMover)
		{
			float vrd = RandomGenerate();
			
			if (esquerda)
			{
                animator.SetBool("esquerda", true);
				transform.Translate(-speed *vrd* Time.deltaTime, 0, 0);
			}
			else
			{
                animator.SetBool("esquerda", false);
                transform.Translate(speed *vrd* Time.deltaTime, 0, 0);
			}
		}

		if (gameObject.transform.position.x < (player_pos.x + 3f) &&
		    (gameObject.transform.position.x > (player_pos.x - 3f)))
		{
			podeMover = false;
		}
		else
		{
			podeMover = true;


		}

		if (gameObject.transform.position.x - player_pos.x > 0)
		{
			esquerda = true;
            animator.SetBool("esquerda", true);
		}

		if (gameObject.transform.position.x - player_pos.x < 0)
		{
			esquerda = false;
            animator.SetBool("esquerda", false);
        }

	}
	private float RandomGenerate()
	{
		float vl = Random.Range(1, 3);
		float v2 = Random.Range(1, 10);
		int v3 = Random.Range(0, 100);
		v2 = (v2/10f);
		if (v3 <= 15)
		{
			return v2;
		}
		
		
		return vl;
	}

    public void destroi()
    {
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SendMessage("hit");
            destroi();
        }
    }

}

