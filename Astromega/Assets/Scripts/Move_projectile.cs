using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_projectile : MonoBehaviour
{
    public float speed = 5f;
    private float startTime = 0f;
    private float interval = 0.3f;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if ((Time.time - startTime) < interval)
        {
            if (UpManager.Instance.shootB.Up)
            {
                transform.position += new Vector3(-1.5f/(interval * speed), 0.1f, -0.2f/(interval * speed)) * speed * Time.deltaTime;
            }
            else
            {
                transform.position += new Vector3(-1.5f/(interval * speed), 0.1f, -0.7f/(interval * speed)) * speed * Time.deltaTime;
            }
            
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if ((Time.time - startTime) >= 5f)
        {
            Destroy(gameObject);
        }
    }
}