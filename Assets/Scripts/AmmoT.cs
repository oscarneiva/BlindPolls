using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Networking;

public class AmmoT : MonoBehaviour
{
	private float speed;
	private float dano;
	public void SetSpeed (float newSpeed)
	{
		speed = newSpeed;
	}


	void Start ()
	{
	
		//gerar valor alatorio para dano
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(speed*Time.deltaTime,0f,0f);
	}
}
