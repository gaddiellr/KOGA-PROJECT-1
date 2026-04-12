using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class UIData_1
{
    public List<UIElementData> elements = new List<UIElementData>();

    [System.Serializable]
    public class UIElementData
    {
        public string elementId;
        public float width;
        public float height;
        public bool isEnabled;

        public UIElementData() { }

        public UIElementData(string id, float w, float h, bool enabled)
        {
            elementId = id;
            width = w;
            height = h;
            isEnabled = enabled;
        }
    }
}

public class Load_settings : MonoBehaviour
{
    [Header("Configuración de archivo")]
    [SerializeField] private string fileName = "user_config.json";
    [SerializeField] private bool loadOnStart = true;

    [Header("Elementos UI a cargar")]
    [SerializeField] private UIElementConfig[] uiElements;

    [Header("Opciones de carga")]
    [SerializeField] private bool loadSize = false;   // Si es false, ignora width/height del JSON
    [SerializeField] private bool loadEnabled = true; // Si es true, aplica isEnabled

    [System.Serializable]
    public class UIElementConfig
    {
        public string elementId;
        public GameObject targetObject;
        public RectTransform rectTransform; // Solo necesario si loadSize = true

        public void ApplyData(UIData_1.UIElementData data, bool applySize, bool applyEnabled)
        {
            if (targetObject == null) return;

            if (applyEnabled)
                targetObject.SetActive(data.isEnabled);

            if (applySize && rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(data.width, data.height);
                LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            }
        }
    }

    private string filePath;

    private void Awake()
    {
        SetFilePath();
        Debug.Log($"Ruta del archivo: {filePath}");
    }

    private void Start()
    {
        if (loadOnStart)
            LoadFromJSON();
    }

    private void SetFilePath()
    {
        string folderPath = Path.Combine(Application.dataPath, "Config");
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        filePath = Path.Combine(folderPath, fileName);
    }

    public void LoadFromJSON()
    {
        Debug.Log("Cargando configuración desde JSON...");

        if (!File.Exists(filePath))
        {
            Debug.Log("No se encontró archivo de configuración. Se usan valores actuales.");
            return;
        }

        try
        {
            string json = File.ReadAllText(filePath);
            UIData_1 loadedData = JsonUtility.FromJson<UIData_1>(json);

            if (loadedData == null || loadedData.elements == null)
            {
                Debug.LogError("Error: JSON inválido o sin elementos.");
                return;
            }

            int appliedCount = 0;
            foreach (var element in uiElements)
            {
                if (element == null || element.targetObject == null)
                {
                    Debug.LogWarning($"Elemento nulo o sin targetObject: {element?.elementId}");
                    continue;
                }

                var elementData = loadedData.elements.Find(d => d.elementId == element.elementId);
                if (elementData != null)
                {
                    element.ApplyData(elementData, loadSize, loadEnabled);
                    appliedCount++;
                    Debug.Log($"Aplicado a '{element.elementId}': isEnabled={elementData.isEnabled}, size={(loadSize ? elementData.width + "x" + elementData.height : "ignorado")}");
                }
                else
                {
                    Debug.Log($"No hay datos para '{element.elementId}' en el JSON.");
                }
            }

            Debug.Log($"Carga completada. Elementos actualizados: {appliedCount} de {uiElements.Length}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error al cargar JSON: {e.Message}");
        }
    }

    // Método público para recargar manualmente (opcional)
    public void ReloadConfig()
    {
        LoadFromJSON();
    }

    // Método para mostrar la ruta del archivo (útil para depuración)
    public void PrintFilePath()
    {
        SetFilePath();
        Debug.Log($"Ruta del archivo de configuración: {filePath}");
    }

    // Método para ver el contenido del JSON (depuración)
    public void PrintJSONContent()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log($"Contenido del JSON:\n{json}");
        }
        else
        {
            Debug.Log("El archivo JSON no existe.");
        }
    }
}