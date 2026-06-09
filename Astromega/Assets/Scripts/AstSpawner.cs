using System.Collections.Generic;
using UnityEngine;

public class AstSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    private float max = 17.51f;
    private float min = -17.5f;
    private float dt = 0.0f;
    private float lastT = 0.0f;
    private int a;
    private int b;
    private int r;
    public int A => a;
    public int B => b;
    public int R => r;
    private bool spawn = true;
    public bool Spawn
    {
        get { return spawn; }
        set { spawn = value; }
    }
    private bool reduce = true;
    public bool Reduce
    {
        get { return reduce; }
        set { reduce = value; }
    }
    private bool stop = false;
    public bool Stop
    {
        get { return stop; }
        set { stop = value; }
    }

    void Update()
    {
        dt= Time.time - lastT;
        if (dt >= 6.0f && !Stop)
        {
            Spawn = true;
        }
        if (Spawn == true)
        {
            Spawn = false;
            Reduce = true;
            List<int> num = new() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            List<float> pointsx = new List<float>();
            List<float> pointsy = new List<float>();
            float px;
            float py;
            int x = Random.Range(0, 10);
            a = Random.Range(-10, 10);
            while (a == 0)
            {
                a = Random.Range(-10, 10);
            }
            b = Random.Range(-10, 11);
            r = x * a + b;
            for (int i = 0; i < 4; i++)
            {                    
                px = Random.Range(min, max);
                py = Random.Range(min, max);
                if (i > 0)
                {
                    x = num[Random.Range(0, num.Count)];

                    if (i == 1)
                    {
                        while (intersect(px, pointsx[0]) && intersect(py, pointsy[0]))
                        {
                            px = Random.Range(min, max);
                            py = Random.Range(min, max);
                        }
                    }
                    if (i == 2)
                    {
                        while (intersect(px, pointsx[0]) && intersect(py, pointsy[0]) || intersect(px, pointsx[1]) && intersect(py, pointsy[1]))
                        {
                            px = Random.Range(min, max);
                            py = Random.Range(min, max);
                        }
                    }
                    if (i == 3)
                    {
                        while (intersect(px, pointsx[0]) && intersect(py, pointsy[0]) || intersect(px, pointsx[1]) && intersect(py, pointsy[1]) || intersect(px, pointsx[2]) && intersect(py, pointsy[2]))
                        {
                            px = Random.Range(min, max);
                            py = Random.Range(min, max);
                        }
                    }
                }
                pointsx.Add(px);
                pointsy.Add(py);
                Instantiate(prefabs[x], new Vector3(px, py, 100f), Quaternion.Euler(0f, -90f, -90f));
                num.Remove(x);
            }
            lastT = Time.time;
        }
    }

    bool intersect(float a, float b)
    {
        if ((b - 5.5f) <= (a + 5.5f) && (b - 5.5f) >= (a - 5.5f) || (b + 5.5f) <= (a + 5.5f) && (b + 5.5f) >= (a - 5.5f)) return true;
        else return false;
    }
}
