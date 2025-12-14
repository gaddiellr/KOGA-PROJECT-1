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
            Debug.LogError("No asignaste el BoxCollider del �rea base.");
            return;
        }

        // Obtener los l�mites del BoxCollider
        Bounds bounds = boxArea.bounds;

        // Crear una posici�n aleatoria dentro del box
        Vector3 randomPos = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );

        Instantiate(prefab, randomPos, Quaternion.identity);
    }
}
*/
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
