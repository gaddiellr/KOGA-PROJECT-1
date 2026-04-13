using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LoadSettings : MonoBehaviour
{
    public RectTransform button;
    public RectTransform joystick;
    private string filePath;
    private string fileName = "settings.json";

    void Start()
    {
        string folderPath = Path.Combine(Application.dataPath, "Config");
        filePath = Path.Combine(folderPath, fileName);
        LoadSettingsFile();
    }

    private void LoadSettingsFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);
            if (data.dropdownVal == 0)
            {
                button.anchorMin = new Vector2(1, 0);
                button.anchorMax = new Vector2(1, 0);
                joystick.anchorMin = new Vector2(0, 0);
                joystick.anchorMax = new Vector2(0, 0);
                button.anchoredPosition = new Vector2(-300, 300);
                joystick.anchoredPosition = new Vector2(300, 300);
            }
            else
            {
                button.anchorMin = new Vector2(0, 0);
                button.anchorMax = new Vector2(0, 0);
                joystick.anchorMin = new Vector2(1, 0);
                joystick.anchorMax = new Vector2(1, 0);
                button.anchoredPosition = new Vector2(300, 300);
                joystick.anchoredPosition = new Vector2(-300, 300);
            }
            button.sizeDelta = new Vector2(320 * (2 * data.buttonVal + 1), 320 * (2 * data.buttonVal + 1));
            joystick.sizeDelta = new Vector2(320 * (2 * data.joystickVal + 1), 320 * (2 * data.joystickVal + 1));
            Debug.Log(2 * data.buttonVal + 1);
            Debug.Log("Loaded from: " + filePath);
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }
}
