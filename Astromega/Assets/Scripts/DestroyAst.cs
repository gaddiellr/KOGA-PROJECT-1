using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAst : MonoBehaviour
{
    private string targetTag = "Destroy";
    private bool hit = false;
    private float dt = 0.0f;
    private float lastT = 0.0f;
    private AstSpawner spawner;
    private int n;
    
    private void Awake()
    {
        spawner = FindObjectOfType<AstSpawner>();
    }

    void Start()
    {
        n = int.Parse(gameObject.tag.Substring(4));
    }

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
            if (spawner != null)
            {
                if (spawner.Reduce)
                {
                    StatisticManager.Instance.AddHealth(10);
                    spawner.Reduce = false;
                }
            }
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