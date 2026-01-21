using System.Collections.Generic;
using UnityEngine;

public class AstSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    [SerializeField] private float spawnRadius = 1.15f;
    [SerializeField] private LayerMask asteroidMask;

    [SerializeField] private int a;
    [SerializeField] private int b;
    [SerializeField] private int r;

    public int A => a;
    public int B => b;
    public int R => r;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<int> num = new() { 0,1,2,3,4,5,6,7,8,9 };

            int x = Random.Range(0, 10);
            a = Random.Range(-100, 101);
            b = Random.Range(-50, 50);
            r = x * a + b;

            num.Remove(x);

            for (int i = 0; i < 4; i++)
            {
                //Vector3 pos = GetFreePosition();
                Vector3 pos = new Vector3(0, 100, 0);

                if (i == 1)
                {
                    Instantiate(prefabs[x], pos, Quaternion.identity);
                    //Instantiate(prefabs[0], pos, Quaternion.identity);
                }
                /*
                else
                {
                    int notx = num[Random.Range(0, num.Count)];
                    Instantiate(prefabs[notx], pos, Quaternion.identity);
                    num.Remove(notx);
                }
                */
            }
        }
    }

    Vector3 GetFreePosition()
    {
        Vector3 pos = new Vector3(Random.Range(0, 21), 100, Random.Range(0, 21));
        bool finish = IsPositionFree(pos);
        while (!finish)
        {
            pos = new Vector3(Random.Range(0, 21), 100, Random.Range(0, 21));
            finish = IsPositionFree(pos);
        }
        return pos;
    }

    bool IsPositionFree(Vector3 position)
    {
        return !Physics.CheckSphere(
            position,
            spawnRadius,
            asteroidMask,
            QueryTriggerInteraction.Ignore
        );
    }
}