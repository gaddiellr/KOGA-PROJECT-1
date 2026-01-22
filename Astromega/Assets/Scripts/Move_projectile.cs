using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_projectile : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}