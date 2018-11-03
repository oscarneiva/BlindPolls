using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public GameObject tiro;
	public bool parado;
	
	private GameObject player;
	private GameObject inimgo;
	private Transform trp;

	private Vector3 player_pos;
	//private FixedJoint2D jt;

	private BoxCollider2D bc;
	private Rigidbody2D rb;
	
	public bool esquerda ;
	
	public float speed;
	
	public bool podeMover = true;
	private float cont;
	void Start ()
	{
		speed = 10f;
		parado = true;

		player = GameObject.FindGameObjectWithTag("Player");
		inimgo = transform.parent.gameObject;
	
		

	}
	
	// Update is called once per frame
	public void SpawnBullet(bool esquerda)
	{
		instancia_tiro(esquerda);
	}
	void instancia_tiro(bool esquerda)
	{
		GameObject novo_tiro = Instantiate(tiro, gameObject.transform.position, gameObject.transform.rotation);
		if (esquerda)
			novo_tiro.GetComponent<AmmoT>().SetSpeed(-speed);
		else
			novo_tiro.GetComponent<AmmoT>().SetSpeed(speed);
	}
}
