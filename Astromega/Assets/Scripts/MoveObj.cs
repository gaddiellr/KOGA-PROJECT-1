/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public float speed = 20f;

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public float speed = 20f;
    public bool neb = false;
    public bool bg = false;
    [SerializeField] private Rigidbody rigidBody;
    private float distance;
    private float t;
    private float vel;
    private float startTime = 0f;
    private bool end = false;

    void Start()
    {
        if (bg)
        {
            t = ObjManager.Instance.spawner.TObj - 60f;
            distance = ObjManager.Instance.spawner.Dist;
            vel = distance / t;
            startTime = Time.time;
            if (neb) rigidBody.velocity = new Vector3(vel, 0, rigidBody.velocity.z);
            else rigidBody.velocity = new Vector3(vel, 0, - speed);
        }
        else rigidBody.velocity = new Vector3(0, 0, - speed);
    }

    void Update()
    {
        if (bg)
        {
            if ((Time.time - startTime) < t)
            {
                if (neb)
                {
                    rigidBody.velocity = new Vector3(vel, 0, rigidBody.velocity.z);
                }
            }
            else
            {
                if (!end)
                {
                    if (neb) rigidBody.velocity = new Vector3(0, 0, rigidBody.velocity.z);
                    else rigidBody.velocity = new Vector3(0, 0, - speed);
                    end = true;
                }

            }
        }
    }
}
