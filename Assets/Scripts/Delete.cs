using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Delete"))
            Destroy(gameObject);           
    }
}
