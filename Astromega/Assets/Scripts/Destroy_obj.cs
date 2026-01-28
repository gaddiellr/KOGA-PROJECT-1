using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_obj : MonoBehaviour
{
    public string targetTag0 = "astn0";
    public string targetTag1 = "astn1";
    public string targetTag2 = "astn2";
    public string targetTag3 = "astn3";
    public string targetTag4 = "astn4";
    public string targetTag5 = "astn5";
    public string targetTag6 = "astn6";
    public string targetTag7 = "astn7";
    public string targetTag8 = "astn8";
    public string targetTag9 = "astn9";
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
            string astTag = other.tag;
            int n = int.Parse(astTag.Substring(4));
            if (spawner != null)
            {
                if (n == ((spawner.R - spawner.B) / spawner.A))
                {
                    ScoreManager.Instance.AddScore(1);
                }
            }
            Vector3 pos = gameObject.transform.position;
            Quaternion rot = Random.rotation;
            Instantiate(explosionPrefab, pos, rot);
            Destroy(other.gameObject);
            Destroy(gameObject);
            spawner.Spawn = true;
        }
    }
}