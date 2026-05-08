using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class SaveSettings : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Slider slider1;
    public Slider slider2;
    private string filePath;
    [SerializeField] private string fileName = "settings.json";

     void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log("Persistent Path = " + filePath);
    }

    void Start()
    {
        LoadSettingsFile();
    }

    private void LoadSettingsFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);
            dropdown.value = data.dropdownVal;
            slider1.value = data.buttonVal;
            slider2.value = data.joystickVal;
            dropdown.RefreshShownValue();
            Debug.Log("Loaded from: " + filePath);
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }

    private void SaveSettingsFile()
    {
        SettingsData data = new SettingsData();
        data.dropdownVal = dropdown.value;
        data.buttonVal = slider1.value;
        data.joystickVal = slider2.value;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Saved to: " + filePath);
    }
}
