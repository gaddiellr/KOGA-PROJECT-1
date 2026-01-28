/*
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IPointerDownHandler
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public bool isShooting;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (projectilePrefab == null || spawnPoint == null)
        {
            Debug.LogError("Projectile Prefab or Spawn Point not assigned!");
            return;
        }
        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
    }
}
*/
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour, IPointerDownHandler
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;

    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        //Instantiate(projectilePrefab, new Vector3(10, 0.5f, 10), Quaternion.identity);
    }
}