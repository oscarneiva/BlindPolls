using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
       
        if (col.gameObject.CompareTag("Delete"))
            Destroy(gameObject);           
    }
}
