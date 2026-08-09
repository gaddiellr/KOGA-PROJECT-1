using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    public float maxSize = 100f;
    public float vel = 20f;
    public bool dest = false;
    public bool parent = false;
    private float t;
    private float growTime;
    private float timer = 0f;
    private float startTime = 0f;
    private Vector3 startScale;
    private Vector3 maxScale;
    private float t_dest;

    void Start()
    {
        startTime = Time.time;
        startScale = transform.localScale;
        maxScale = new Vector3(maxSize, maxSize, maxSize);
        t = ObjManager.Instance.spawner.TObj;
        growTime = 0.8f * t;
        t_dest = 17 * t / vel;
    }

    void Update()
    {
        if (timer < growTime && !parent)
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            timer += Time.deltaTime;
        }
        if (((Time.time - startTime) >= t) || (dest && (Time.time - startTime) >= t_dest))
        {
            Destroy(gameObject);
        }
    }
}