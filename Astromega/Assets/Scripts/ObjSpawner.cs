using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjSpawner : MonoBehaviour
{
    public GameObject dest;
    public GameObject[] prefabs;
    private float[] max = {750f, 200f, 80f};
    private float[] min = {550f, 0f, 45f};
    private float[] t = {80f, 120f, 140f, 100f};
    private float dt = 0.0f;
    private float lastT = 0.0f;
    private bool spawn = true;
    private bool start = true;
    private float px;
    private float py;
    private float ry = 0f;
    private float rz = 0f;
    private int x = -1;
    private float tObj = 80f;
    private float dist = 0f;
    public float TObj => tObj;
    public float Dist => dist;
        
    void Update()
    {
        dt= Time.time - lastT;
        if (dt >= tObj)
        {
            spawn = true;
        }
        if (spawn == true)
        {
            spawn = false;
            //x = start ? -1 : Random.Range(-1, 3);
            x = 0;
            if (start) start = false;
            /*
            px = 0;
            //py = (Random.Range(0, 2) == 1) ? 550f : -550f;
            py = 45f;
            */
            if (x == 2)
            {
                x = Random.Range(-1, 3);
                if (x == 2)
                {
                    ry = Random.Range(-max[x], max[x]) / 1.5f;
                    rz = Random.Range(-max[x], max[x]) / 1.5f;
                }
                else
                {
                    ry = 0f;
                    rz = 0f;
                }
            }
            
            Debug.Log(x);
            tObj = t[x + 1];
            if (x > -1)
            {
                
                px = Random.Range(-max[x], max[x]);
                py = Random.Range(-max[x], max[x]);
                while (px > -min[x] && px < min[x] && py > -min[x] && py < min[x])
                {
                    px = Random.Range(-max[x], max[x]);
                    py = Random.Range(-max[x], max[x]);
                }
                
                float pz = 17f * tObj;
                float sx = Mathf.Tan(30.55f * Mathf.Deg2Rad) * pz;
                dist = px - sx;
                Instantiate(prefabs[x], new Vector3(sx, py, pz), (x > 1) ? Quaternion.Euler(0f, -90f + ry, -90f + rz) : Random.rotation);
                if (x != 1) Instantiate(dest, new Vector3(px, py, 100f), Quaternion.Euler(0f, -90f, -90f));
            }
            lastT = Time.time;
        }
    }
}
