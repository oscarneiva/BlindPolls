using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InimigoS : MonoBehaviour
{
	public GameObject tiro;

	public float speed = 3.0f;
	public bool esquerda;
	private GameObject player;
	private Vector3 player_pos;
	public bool podeMover = true;
	private float cont;
    public Animator animator;

    // Use this for initialization
    void Start()
	{
        animator = gameObject.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		
		if (gameObject.transform.position.x - player_pos.x > 0)
		{
			esquerda = true;
			speed = -speed;
		}
		
		if (gameObject.transform.position.x - player_pos.x < 0)
		{
			esquerda = false;
		}

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
                animator.SetBool("esquerda", false);
                transform.Translate(speed * vrd * Time.deltaTime, 0, 0);
            }
            else
            {
                animator.SetBool("esquerda", true);
                transform.Translate(speed * vrd * Time.deltaTime, 0, 0);
            }
        }
        else
		{
			cont += Time.deltaTime;
			if (cont >= 2.0f)
			{
				transform.GetComponentInChildren<Shooting>().SpawnBullet(esquerda);
				cont = 0;
			}
		}

		if (gameObject.transform.position.x < (player_pos.x + 7f) &&
		    (gameObject.transform.position.x > (player_pos.x - 7f)))
		{
			podeMover = false;
		}
		else
		{
			podeMover = true;
			cont = 0;
		}

		if (gameObject.transform.position.x - player_pos.x > 0)
		{
			esquerda = true;
		}
		
		if (gameObject.transform.position.x - player_pos.x < 0)
		{
			esquerda = false;
		}
	}

	private float RandomGenerate()
	{
		float vl = Random.Range(1, 3);
		float v2 = Random.Range(6, 10);
		int v3 = Random.Range(0, 100);
		v2 = (v2/10f);
		if (v3 <= 15)
		{
			return v2;
		}
		
		
		return vl;
	}


}
