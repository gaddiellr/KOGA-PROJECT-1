using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_ast : MonoBehaviour
{
    public string targetTag = "Destroy";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject);
        }
    }
}