using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAst : MonoBehaviour
{
    private string targetTag = "Destroy";
    private bool hit = false;
    private float dt = 0.0f;
    private float lastT = 0.0f;

    void Update()
    {
        dt = Time.time - lastT;
        if (hit)
        {
            if (dt >= 0.06f)
            {
                Destroy(gameObject);
                hit = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            hit = true;
            lastT = Time.time;
        }
    }
}