using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dest : MonoBehaviour
{
    private float startTime = 0f;
    private float t = 80f;
    private float timer = 0f;
    private float growTime = 40f;
    private float maxSize = 50f;
    private Vector3 startScale;
    private Vector3 maxScale;

    void Start()
    {
        startTime = Time.time;
        startScale = transform.localScale;
        maxScale = new Vector3(maxSize, maxSize, maxSize);
    }

    void Update()
    {
        if (timer < growTime)
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            timer += Time.deltaTime;
        }
        if ((Time.time - startTime) >= t)
        {
            Destroy(gameObject);
        }
    }
}