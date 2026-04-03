using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject dest;
    public GameObject[] prefabs;
    private float max = 70f;
    private float min = 45f;
    private float dt = 0.0f;
    private float lastT = 0.0f;
    private bool spawn = true;
    private float px;
    private float py;
    
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
            int x = Random.Range(0, 2);
            px = Random.Range(-max, max);
            py = Random.Range(-max, max);
            
            while (px > -min && px < min && py > -min && py < min)
            {
                px = Random.Range(-max, max);
                py = Random.Range(-max, max);
            }
            //Instantiate(prefabs[x], new Vector3(px, py, 2000f), Quaternion.Euler(0f, -90f + px/1.5f, -90f + py/1.5f));
            Instantiate(prefabs[x], new Vector3(px, py, 2000f), Quaternion.Euler(0f, -90f, -90f));
            /*
            Quaternion rot = Random.rotation;
            Debug.Log(rot);
            Instantiate(prefabs[x], new Vector3(px, py, 2000f), rot);
            */
            Instantiate(dest, new Vector3(px, py, 100f), Quaternion.Euler(0f, -90f, -90f));
            lastT = Time.time;
        }
        if (dt >= 20f)
        {
        }
        
    }
}
