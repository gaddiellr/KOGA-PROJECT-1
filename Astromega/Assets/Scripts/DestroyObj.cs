using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject[] prefabs;
    private string targetTag0 = "astn0";
    private string targetTag1 = "astn1";
    private string targetTag2 = "astn2";
    private string targetTag3 = "astn3";
    private string targetTag4 = "astn4";
    private string targetTag5 = "astn5";
    private string targetTag6 = "astn6";
    private string targetTag7 = "astn7";
    private string targetTag8 = "astn8";
    private string targetTag9 = "astn9";
    public GameObject explosionPrefab;
    private AstSpawner spawner;

    private void Awake()
    {
        spawner = FindObjectOfType<AstSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag0) || other.CompareTag(targetTag1) || other.CompareTag(targetTag2) || other.CompareTag(targetTag3) || other.CompareTag(targetTag4) || other.CompareTag(targetTag5) || other.CompareTag(targetTag6) || other.CompareTag(targetTag7) || other.CompareTag(targetTag8) || other.CompareTag(targetTag9))
        {
            int n = int.Parse(other.tag.Substring(4));
            if (spawner != null)
            {
                if (n == ((spawner.R - spawner.B) / spawner.A))
                {
                    StatisticManager.Instance.AddScore(1);
                }
            }
            Vector3 pos = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z); //pos = gameObject.transform.position;
            Quaternion rot = Random.rotation;
            Instantiate(explosionPrefab, pos, rot);
            Instantiate(prefabs[n], pos, Quaternion.identity);
            Destroy(gameObject);
            //spawner.Spawn = true;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Destroy(other);
    }
}