/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSpawner : MonoBehaviour
{
    public GameObject prefab;          // El prefab que quieres instanciar
    public BoxCollider boxArea;        // El collider del objeto base donde se spawnea

    void Start()
    {
        SpawnPrefab();
    }

    void SpawnPrefab()
    {
        if (boxArea == null)
        {
            Debug.LogError("No asignaste el BoxCollider del  rea base.");
            return;
        }

        // Obtener los l mites del BoxCollider
        Bounds bounds = boxArea.bounds;

        // Crear una posici n aleatoria dentro del box
        Vector3 randomPos = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );

        Instantiate(prefab, randomPos, Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSpawner : MonoBehaviour
{
    public GameObject prefab;          // El prefab que quieres instanciar
    public BoxCollider boxArea;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(0, 21), 100, Random.Range(0, 21));
            Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSpawner : MonoBehaviour
{
    public GameObject[] prefabs;

    private string[] equations = { "5x + 4 = 9", "12x + 1 = 49" };
    private int[,] solutions = { {1, 5, 2, 7}, {4, 3, 6, 8} };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = UnityEngine.Random.Range(0, equations.Length);

            for (int i = 0; i < 4; i++)
            {
                Vector3 pos = new Vector3(
                    UnityEngine.Random.Range(0, 21),
                    100,
                    UnityEngine.Random.Range(0, 21)
                );

                Instantiate(prefabs[solutions[index, i]], pos, Quaternion.identity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    private List<int> num;
    [SerializeField] private int a;
    [SerializeField] private int b;
    [SerializeField] private int r;
    public int A => a;
    public int B => b;
    public int R => r;

    void Update()
    {
        num = new() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int x = UnityEngine.Random.Range(0, 10);
            a = UnityEngine.Random.Range(-100, 101);
            b = UnityEngine.Random.Range(-50, 50);
            r = x * a + b;
            num.Remove(x);
            for (int i = 0; i < 4; i++)
            {
                Vector3 pos = new Vector3(UnityEngine.Random.Range(0, 21), 100, UnityEngine.Random.Range(0, 21));
                if (i == 1)
                {
                    Instantiate(prefabs[x], pos, Quaternion.identity);
                }
                else
                {
                    int notx = num[UnityEngine.Random.Range(0, num.Count)];
                    Instantiate(prefabs[notx], pos, Quaternion.identity);
                    num.Remove(notx);
                }
            }
        }
    }
}
*/
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
                Vector3 pos = GetFreePosition();

                if (i == 1)
                {
                    Instantiate(prefabs[x], pos, Quaternion.identity);
                }
                else
                {
                    int notx = num[Random.Range(0, num.Count)];
                    Instantiate(prefabs[notx], pos, Quaternion.identity);
                    num.Remove(notx);
                }
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