using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_ast : MonoBehaviour
{
    public string targetTag = "Destroy";
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Destroy(gameObject);              // destroy this object
            //Destroy(collision.gameObject);   destroy the target (optional)
        }
    }
    */

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(targetTag))
        {
            //Destroy(other.gameObject); // destruye el objetivo
            Destroy(gameObject);       //destruye la bala
        }

    }
}

