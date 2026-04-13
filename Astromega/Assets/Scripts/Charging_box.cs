using UnityEngine;
using UnityEngine.UI;   // for other UI components if needed
using TMPro;            // REQUIRED for TMP_Dropdown
using System;           // for Array.Find

[System.Serializable]
public class ElementData
{
    public string elementId;
    public float width;
    public float height;
    public bool isEnabled;
    public float sliderValue;
}

[System.Serializable]
public class ElementsContainer
{
    public ElementData[] elements;
}

public class Charging_box : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Dropdown targetDropdown;   // Now using TextMeshPro dropdown

    [Header("JSON Settings")]
    public TextAsset jsonFile;        // Drag your JSON file here

    void Start()
    {
        // Check if dropdown is assigned
        if (targetDropdown == null)
        {
            Debug.LogError("TMP_Dropdown reference is missing!");
            return;
        }

        // Load JSON text
        string jsonString = "";
        if (jsonFile != null)
        {
            jsonString = jsonFile.text;
        }
        else
        {
            TextAsset asset = Resources.Load<TextAsset>("config");
            if (asset != null) jsonString = asset.text;
        }

        if (string.IsNullOrEmpty(jsonString))
        {
            Debug.LogError("Failed to load JSON file.");
            return;
        }

        // Parse JSON
        ElementsContainer container = JsonUtility.FromJson<ElementsContainer>(jsonString);
        if (container == null || container.elements == null)
        {
            Debug.LogError("Invalid JSON structure.");
            return;
        }

        // Find the element with ID "Id_Right_Canva_Moving"
        ElementData rightMoving = Array.Find(container.elements, e => e.elementId == "Id_Right_Canva_Moving");
        if (rightMoving == null)
        {
            Debug.LogWarning("Element 'Id_Right_Canva_Moving' not found in JSON.");
            return;
        }

        // If isEnabled is false, set dropdown to the second option (index 1)
        if (!rightMoving.isEnabled)
        {
            if (targetDropdown.options.Count > 1)
            {
                targetDropdown.value = 1;   // 0?based index: 0 = first, 1 = second
                Debug.Log("Dropdown set to second option because Id_Right_Canva_Moving is false.");
            }
            else
            {
                Debug.LogWarning("Dropdown has fewer than 2 options. Cannot select second option.");
            }
        }
        else
        {
            Debug.Log("Id_Right_Canva_Moving is enabled. No dropdown change.");
        }
    }
}