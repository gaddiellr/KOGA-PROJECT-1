using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject flash;
    public Transform spawnPoint;
    public RectTransform buttonRect;
    public Image targetImage;
    public AudioSource audioSource;
    public AudioClip[] soundtracks;
    private Vector2 circleCenter;
    private int radius;
    private float dt = 0.0f;
    private float lastT = -1f;
    private bool up = true;
    public bool Up => up;
    private string filePath;
    private string fileName = "settings.json";

    void Start()
    {
        string folderPath = Path.Combine(Application.dataPath, "Config");
        filePath = Path.Combine(folderPath, fileName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);
            radius = Mathf.RoundToInt(160 * (2 * data.buttonVal + 1));
            if (data.dropdownVal == 0)
            {
                circleCenter = new Vector2(Screen.width + buttonRect.anchoredPosition.x, buttonRect.anchoredPosition.y);
            }
            else
            {
                circleCenter = new Vector2(buttonRect.anchoredPosition.x, buttonRect.anchoredPosition.y);
            }            
            Debug.Log("Loaded from: " + filePath);
        }
        else
        {
            Debug.Log("No save file found.");
            radius = Mathf.RoundToInt(buttonRect.sizeDelta.x / 2f);
            circleCenter = new Vector2(Screen.width + buttonRect.anchoredPosition.x, buttonRect.anchoredPosition.y);
        }
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
                Instantiate(projectilePrefab, new Vector3(spawnPoint.position.x - 0.2f, spawnPoint.position.y - 1.5f, spawnPoint.position.z + 0.8f), Quaternion.Euler(0f, -90f, -90f));
                Instantiate(flash, new Vector3(spawnPoint.position.x - 0.2f, spawnPoint.position.y - 1.5f, spawnPoint.position.z + 0.8f), Quaternion.Euler(0f, 0f, 0f));
            }
            else
            {
                Instantiate(projectilePrefab, new Vector3(spawnPoint.position.x - 0.7f, spawnPoint.position.y - 1.5f, spawnPoint.position.z + 0.8f), Quaternion.Euler(0f, -90f, -90f));
                Instantiate(flash, new Vector3(spawnPoint.position.x - 0.7f, spawnPoint.position.y - 1.5f, spawnPoint.position.z + 0.8f), Quaternion.Euler(0f, 0f, 0f));
            }
            if (soundtracks.Length > 0)
            {
                PlayRandomTrack();
            }
            lastT = Time.time;
        }
    }

    void PlayRandomTrack()
    {
        if (soundtracks.Length == 0) return;
        int randomIndex= Random.Range(0, soundtracks.Length);
        audioSource.clip = soundtracks[randomIndex];
        audioSource.Play();
    }
}