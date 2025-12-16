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
*/
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