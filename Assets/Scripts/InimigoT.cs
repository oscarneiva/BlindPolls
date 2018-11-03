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
	public bool podeMover = true;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
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

				transform.Translate(-speed *vrd* Time.deltaTime, 0, 0);
			}
			else
			{
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
		}

		if (gameObject.transform.position.x - player_pos.x < 0)
		{
			esquerda = false;
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


}

