using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float speed = 4f;
    private float startTime = 0f;
    private Vector3 vel;
    private float t = 35f;
    private float goalV = 3800f;
    private float goalH = 2569f;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (SphereManager.Instance.spawner.IsV)
        {
            if (SphereManager.Instance.spawner.Neg)
            {
                transform.Rotate(Vector3.left * 1f * speed * Time.deltaTime);
                vel = Vector3.up * (SphereManager.Instance.spawner.SpawnV - goalV) / (t / 2);
            }
            else
            {
                transform.Rotate(Vector3.left * -1f * speed * Time.deltaTime);
                vel = Vector3.up * (goalV - SphereManager.Instance.spawner.SpawnV) / (t / 2);
            }
        }
        else
        {
            if (SphereManager.Instance.spawner.Neg)
            {
                transform.Rotate(Vector3.left * -1f * speed * Time.deltaTime);
                vel = Vector3.forward * (SphereManager.Instance.spawner.SpawnH - goalH) / (t / 2);
            }
            else
            {
                transform.Rotate(Vector3.left * 1f * speed * Time.deltaTime);
                vel = Vector3.forward * (SphereManager.Instance.spawner.SpawnH - goalH) / (t / 2);
            }
        }
        if ((Time.time - startTime) >= 0 && (Time.time - startTime) < (t / 2))
        {
            transform.position += vel * Time.deltaTime;
        }
        if ((Time.time - startTime) >= (t / 2) && (Time.time - startTime) < t)
        {
            transform.position -= vel * Time.deltaTime;
        }
        if ((Time.time - startTime) >= t)
        {
            Destroy(gameObject);
        }
    }
}