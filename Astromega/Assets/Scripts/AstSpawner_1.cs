using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSpawner_1 : MonoBehaviour
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
