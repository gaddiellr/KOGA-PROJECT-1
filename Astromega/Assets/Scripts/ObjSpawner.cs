using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject dest;
    public GameObject[] prefabs;
    private float[] max = {750f, 80f, 80f, 80f};
    private float[] min = {550f, 0f, 45f, 45f};
    private float dt = 0.0f;
    private float lastT = 0.0f;
    private bool spawn = true;
    private float px;
    private float py;
    private float ry = 0f;
    private float rz = 0f;
        
    void Update()
    {
        dt= Time.time - lastT;
        if (dt >= 80f)
        {
            spawn = true;
        }
        if (spawn == true)
        {
            spawn = false;
            int x = Random.Range(0, 3);
            /*
            int x = 3;
            px = 0;
            bool upp = Random.Range(0, 2) == 1;
            py = upp ? 550f : -550f;
            */
            if (x == 2)
            {
                x = Random.Range(0, 3);
                if (x == 2)
                {
                    x = Random.Range(2, 4);
                    ry = Random.Range(-max[x], max[x]) / 1.5f;
                    rz = Random.Range(-max[x], max[x]) / 1.5f;
                }
                else
                {
                    ry = 0f;
                    rz = 0f;
                }
            }
            px = Random.Range(-max[x], max[x]);
            py = Random.Range(-max[x], max[x]);
            while (px > -min[x] && px < min[x] && py > -min[x] && py < min[x])
            {
                px = Random.Range(-max[x], max[x]);
                py = Random.Range(-max[x], max[x]);
            }

            Instantiate(prefabs[x], new Vector3(px, py, 2000f), Quaternion.Euler(0f, -90f + ry, -90f + rz));
            if (x != 1) Instantiate(dest, new Vector3(px, py, 100f), Quaternion.Euler(0f, -90f, -90f));
            lastT = Time.time;
        }
    }
}
