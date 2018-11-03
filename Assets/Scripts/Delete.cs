using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        print("colicao");
        if (col.gameObject.CompareTag("Delete"))
            Destroy(gameObject);           
    }
}
