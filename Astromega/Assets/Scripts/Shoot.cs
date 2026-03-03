/*
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject flash;
    public Transform spawnPoint;
    public RectTransform buttonRect;
    public Image targetImage;
    private Vector2 circleCenter;
    private int radius;
    private float dt = 0.0f;
    private float lastT = -1f;

    void Start()
    {
        radius = Mathf.RoundToInt(buttonRect.sizeDelta.x / 2f);
        circleCenter = new Vector2(Screen.width + buttonRect.anchoredPosition.x, buttonRect.anchoredPosition.y);;
        Debug.Log(radius);
        Debug.Log($"Pos X: {circleCenter.x}, Pos Y: {circleCenter.y}");
    }
    void Update()
    {
        if (Touchscreen.current != null)
        {
            foreach (var touch in Touchscreen.current.touches)
            {
                if (touch.press.wasPressedThisFrame)
                {
                    Vector2 pos = touch.position.ReadValue();
                    TryFire(pos);
                }
            }
        }
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryFire(Mouse.current.position.ReadValue());
        }
        dt= Time.time - lastT;
        if (dt <= 0.08f) targetImage.color = new Color(0.9f, 0.9f, 0.9f, 1f);
        else targetImage.color = new Color(1f, 1f, 1f, 1f);
    }

    void TryFire(Vector2 screenPosition)
    {
        //if (screenPosition.x > Screen.width / 2)
        if (Vector2.Distance(screenPosition, circleCenter) <= radius)
        {
            Instantiate(projectilePrefab, new Vector3(spawnPoint.position.x - 0.75f, 1.5f, spawnPoint.position.z), Quaternion.identity);
            Instantiate(flash, new Vector3(spawnPoint.position.x - 0.75f, 1.5f, spawnPoint.position.z), Quaternion.Euler(90f, 0f, 0f));
            lastT = Time.time;
        }
    }
}
*/

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject flash;
    public Transform spawnPoint;
    //public Transform flashPoint;
    public RectTransform buttonRect;
    public Image targetImage;
    private Vector2 circleCenter;
    private int radius;
    private float dt = 0.0f;
    private float lastT = -1f;
    private bool up = true;
    public bool Up => up;

    void Start()
    {
        radius = Mathf.RoundToInt(buttonRect.sizeDelta.x / 2f);
        circleCenter = new Vector2(Screen.width + buttonRect.anchoredPosition.x, buttonRect.anchoredPosition.y);;
        Debug.Log(radius);
        Debug.Log($"Pos X: {circleCenter.x}, Pos Y: {circleCenter.y}");
    }
    void Update()
    {
        if (Touchscreen.current != null)
        {
            foreach (var touch in Touchscreen.current.touches)
            {
                if (touch.press.wasPressedThisFrame)
                {
                    Vector2 pos = touch.position.ReadValue();
                    TryFire(pos);
                }
            }
        }
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            TryFire(Mouse.current.position.ReadValue());
        }
        dt= Time.time - lastT;
        if (dt <= 0.08f) targetImage.color = new Color(0.9f, 0.9f, 0.9f, 1f);
        else targetImage.color = new Color(1f, 1f, 1f, 1f);
    }

    void TryFire(Vector2 screenPosition)
    {
        if (Vector2.Distance(screenPosition, circleCenter) <= radius)
        {
            int rand = Random.Range(0, 2);
            up = rand == 1;
            if (up){
                Instantiate(projectilePrefab, new Vector3(spawnPoint.position.x + 1.5f, spawnPoint.position.y + 0.8f, spawnPoint.position.z + 0.2f), Quaternion.identity);
                Instantiate(flash, new Vector3(spawnPoint.position.x + 1.5f, spawnPoint.position.y + 0.8f, spawnPoint.position.z + 0.2f), Quaternion.Euler(90f, 0f, 0f));
            }
            else
            {
                //Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
                Instantiate(projectilePrefab, new Vector3(spawnPoint.position.x + 1.5f, spawnPoint.position.y + 0.8f, spawnPoint.position.z + 0.7f), Quaternion.identity);
                //Instantiate(flash, spawnPoint.position, Quaternion.Euler(90f, 0f, 0f));
                //Instantiate(flash, new Vector3(flashPoint.position.x - 0.7f, 4.2f, flashPoint.position.z - 0.5f), Quaternion.Euler(90f, 0f, 0f));
                Instantiate(flash, new Vector3(spawnPoint.position.x + 1.5f, spawnPoint.position.y + 0.8f, spawnPoint.position.z + 0.7f), Quaternion.Euler(90f, 0f, 0f));
            }
            lastT = Time.time;
        }
    }
}