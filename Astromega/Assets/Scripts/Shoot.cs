using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;

    public void ShootProjectile()
    {
        
        if (projectilePrefab == null || spawnPoint == null)
        {
            Debug.LogError("Projectile Prefab or Spawn Point not assigned!");
            return;
        }

        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
    }
}