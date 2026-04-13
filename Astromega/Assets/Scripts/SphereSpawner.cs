using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    private float spawnV = 4350f;
    private float spawnH = 2900f;
    private float limitV = 1200f;
    private float limitH = 2000f;
    public float SpawnV => spawnV;
    public float SpawnH => spawnH;
    public float LimitV => limitH;
    public float LimitH => limitH;
    private float dt = 0.0f;
    private float lastT = 0.0f;
    private bool spawn = true;
    private bool isV;
    private bool neg;
    public bool IsV => isV;
    public bool Neg => neg;

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
            isV = Random.Range(0, 2) == 1;
            neg = Random.Range(0, 2) == 1;
            if (isV)
            {
                Instantiate(prefabs[x], new Vector3(Random.Range(-limitV, limitV), neg ? -spawnV : spawnV, 977f), Quaternion.Euler(neg ? 30f : -30f, 0f, 0f));
            }
            else
            {
                Instantiate(prefabs[x], new Vector3(neg ? -spawnH : spawnH, Random.Range(-limitH, limitH), 977f), Quaternion.Euler(0f, neg ? -10f : 10f, 90f));
            }
            lastT = Time.time;
        }
    }
}