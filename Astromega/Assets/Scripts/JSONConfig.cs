using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class UIData
{
    public List<UIElementData> elements = new List<UIElementData>();

    [System.Serializable]
    public class UIElementData
    {
        public string elementId;
        public float width;
        public float height;
        public bool isEnabled;
        public float sliderValue;

        public UIElementData() { }

        public UIElementData(string id, float w, float h, bool enabled, float sliderVal = 0)
        {
            elementId = id;
            width = w;
            height = h;
            isEnabled = enabled;
            sliderValue = sliderVal;
        }
    }
}

public class JSONConfig : MonoBehaviour
{
    [Header("?? CONFIGURACIÓN DE ARCHIVO")]
    [SerializeField] private string fileName = "user_config.json";
    [SerializeField] private bool loadOnStart = true;
    [SerializeField] private bool saveOnDestroy = false;

    [Header("?? ELEMENTOS UI A GUARDAR")]
    [SerializeField] private UIElementConfig[] uiElements;

    [Header("?? REFERENCIAS OPCIONALES")]
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Text feedbackText;

    [System.Serializable]
    public class UIElementConfig
    {
        public string elementId;
        public GameObject targetObject;
        public RectTransform rectTransform;
        public Slider controlSlider;
        public bool saveEnabled = true;
        public bool saveSize = true;
        public bool saveSliderValue = true;

        public UIData.UIElementData GetCurrentData()
        {
            float width = rectTransform != null ? rectTransform.sizeDelta.x : 0;
            float height = rectTransform != null ? rectTransform.sizeDelta.y : 0;
            bool enabled = targetObject != null ? targetObject.activeSelf : false;
            float sliderVal = controlSlider != null ? controlSlider.value : 0;

            return new UIData.UIElementData(elementId, width, height, enabled, sliderVal);
        }

        public void ApplyData(UIData.UIElementData data)
        {
            Debug.Log($"?? ApplyData - {elementId}: Slider={data.sliderValue}, Size={data.width}x{data.height}");

            // Activar/Desactivar GameObject
            if (targetObject != null && saveEnabled)
                targetObject.SetActive(data.isEnabled);

            // Cambiar tamaño del RectTransform
            if (rectTransform != null && saveSize)
            {
                Debug.Log($"?? Cambiando tamaño de {elementId} de {rectTransform.sizeDelta} a {data.width}x{data.height}");
                rectTransform.sizeDelta = new Vector2(data.width, data.height);

                // Buscar el script Slider_Value en el objeto
                Slider_Value sliderValueScript = targetObject.GetComponent<Slider_Value>();
                if (sliderValueScript != null)
                {
                    // Usar el método especial del slider
                    sliderValueScript.UpdateFromJSON(data.height, data.width);
                }

                LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            }

            // Actualizar valor del slider (solo si no hay Slider_Value)
            if (controlSlider != null && saveSliderValue &&
                targetObject.GetComponent<Slider_Value>() == null)
            {
                float clampedValue = Mathf.Clamp(data.sliderValue,
                                                 controlSlider.minValue,
                                                 controlSlider.maxValue);

                Debug.Log($"??? Slider {elementId}: {controlSlider.value} -> {clampedValue}");
                controlSlider.value = clampedValue;
                controlSlider.onValueChanged.Invoke(clampedValue);
            }
        }
    }

    private string filePath;
    private UIData currentData = new UIData();

    private void Awake()
    {
        SetFilePath();
        Debug.Log($"?? Ruta del archivo: {filePath}");
    }

    private void SetFilePath()
    {
        string folderPath = Path.Combine(Application.dataPath, "Config");

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log($"?? Carpeta creada: {folderPath}");
        }

        filePath = Path.Combine(folderPath, fileName);
    }

    private void Start()
    {
        if (saveButton != null)
            saveButton.onClick.AddListener(SaveToJSON);

        if (loadButton != null)
            loadButton.onClick.AddListener(LoadFromJSON);

        if (resetButton != null)
            resetButton.onClick.AddListener(ResetToCurrentState);

        if (loadOnStart)
        {
            LoadFromJSON();
        }
    }

    private void OnDestroy()
    {
        if (saveOnDestroy)
        {
            SaveToJSON();
        }
    }

    public void SaveToJSON()
    {
        Debug.Log("?? GUARDANDO CONFIGURACIÓN EN JSON...");

        currentData.elements.Clear();

        foreach (var element in uiElements)
        {
            if (element == null || element.targetObject == null) continue;

            var data = element.GetCurrentData();
            currentData.elements.Add(data);

            Debug.Log($"  ?? {data.elementId}: " +
                     $"Enable={data.isEnabled}, " +
                     $"Size={data.width:F0}x{data.height:F0}, " +
                     $"Slider={data.sliderValue:F2}");
        }

        string json = JsonUtility.ToJson(currentData, true);

        try
        {
            SetFilePath();
            File.WriteAllText(filePath, json);
            Debug.Log($"? Configuración guardada en: {filePath}");
            ShowFeedback("? Configuración guardada!", Color.green);
            Debug.Log($"?? JSON:\n{json}");

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        }
        catch (System.Exception e)
        {
            Debug.LogError($"? Error al guardar: {e.Message}");
            ShowFeedback("? Error al guardar", Color.red);
        }
    }

    public void LoadFromJSON()
    {
        Debug.Log("?? CARGANDO CONFIGURACIÓN DESDE JSON...");
        SetFilePath();

        if (!File.Exists(filePath))
        {
            Debug.Log("?? No hay archivo de configuración. Usando valores por defecto.");
            ShowFeedback("?? No hay configuración guardada", Color.yellow);
            return;
        }

        try
        {
            string json = File.ReadAllText(filePath);
            Debug.Log($"?? JSON cargado:\n{json}");

            UIData loadedData = JsonUtility.FromJson<UIData>(json);

            if (loadedData == null || loadedData.elements == null)
            {
                Debug.LogError("? Error: Datos JSON inválidos");
                return;
            }

            // DEBUG: Mostrar todos los elementos cargados
            Debug.Log($"?? Elementos encontrados en JSON ({loadedData.elements.Count}):");
            foreach (var data in loadedData.elements)
            {
                Debug.Log($"  - ID: '{data.elementId}', Slider: {data.sliderValue}");
            }

            int appliedCount = 0;
            foreach (var element in uiElements)
            {
                if (element == null || element.targetObject == null)
                {
                    Debug.LogWarning($"?? Elemento nulo en uiElements");
                    continue;
                }

                // Buscar datos para este elemento
                var elementData = loadedData.elements.Find(d => d.elementId == element.elementId);

                if (elementData != null)
                {
                    Debug.Log($"?? Aplicando a '{element.elementId}':");
                    Debug.Log($"   - Slider guardado: {elementData.sliderValue}");
                    Debug.Log($"   - Slider actual: {(element.controlSlider != null ? element.controlSlider.value.ToString() : "null")}");
                    Debug.Log($"   - saveSliderValue: {element.saveSliderValue}");

                    // Crear datos a aplicar
                    UIData.UIElementData dataToApply = new UIData.UIElementData
                    {
                        elementId = elementData.elementId,
                        isEnabled = element.saveEnabled ? elementData.isEnabled : (element.targetObject != null ? element.targetObject.activeSelf : true),
                        width = element.saveSize ? elementData.width : (element.rectTransform?.sizeDelta.x ?? 0),
                        height = element.saveSize ? elementData.height : (element.rectTransform?.sizeDelta.y ?? 0),
                        sliderValue = element.saveSliderValue ? elementData.sliderValue : (element.controlSlider?.value ?? 0)
                    };

                    // Aplicar los datos
                    element.ApplyData(dataToApply);
                    appliedCount++;

                    // Verificar que se aplicó correctamente
                    if (element.controlSlider != null)
                    {
                        Debug.Log($"? Slider '{element.elementId}' después de aplicar: {element.controlSlider.value}");
                    }
                }
                else
                {
                    Debug.Log($"?? No hay datos guardados para: '{element.elementId}'");
                }
            }

            Debug.Log($"? Configuración cargada! ({appliedCount} elementos actualizados)");
            ShowFeedback("?? Configuración cargada!", Color.blue);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"? Error al cargar: {e.Message}");
            ShowFeedback("? Error al cargar", Color.red);
        }
    }

    // Método para guardar un elemento específico
    public void SaveElement(string elementId)
    {
        var element = System.Array.Find(uiElements, e => e.elementId == elementId);
        if (element != null)
        {
            var data = element.GetCurrentData();

            UIData tempData = LoadDataFromFile();
            if (tempData == null) tempData = new UIData();

            int index = tempData.elements.FindIndex(d => d.elementId == elementId);
            if (index >= 0)
                tempData.elements[index] = data;
            else
                tempData.elements.Add(data);

            string json = JsonUtility.ToJson(tempData, true);
            File.WriteAllText(filePath, json);

            Debug.Log($"? Elemento {elementId} guardado");

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        }
    }

    // Método para cargar un elemento específico
    public void LoadElement(string elementId)
    {
        UIData tempData = LoadDataFromFile();
        if (tempData != null)
        {
            var elementData = tempData.elements.Find(d => d.elementId == elementId);
            if (elementData != null)
            {
                var element = System.Array.Find(uiElements, e => e.elementId == elementId);
                if (element != null)
                {
                    element.ApplyData(elementData);
                    Debug.Log($"? Elemento {elementId} cargado");
                }
            }
        }
    }

    public void ResetToCurrentState()
    {
        SaveToJSON();
        ShowFeedback("?? Resetado a estado actual", Color.yellow);
    }

    public void DeleteConfigFile()
    {
        SetFilePath();

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("??? Archivo de configuración eliminado");
            ShowFeedback("??? Configuración eliminada", Color.red);

#if UNITY_EDITOR
            UnityEditor.AssetDatabase.Refresh();
#endif
        }
    }

    private UIData LoadDataFromFile()
    {
        SetFilePath();

        if (!File.Exists(filePath))
            return null;

        string json = File.ReadAllText(filePath);
        return JsonUtility.FromJson<UIData>(json);
    }

    private void ShowFeedback(string message, Color color)
    {
        Debug.Log(message);

        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
            feedbackText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideFeedback));
            Invoke(nameof(HideFeedback), 2f);
        }
    }

    private void HideFeedback()
    {
        if (feedbackText != null)
            feedbackText.gameObject.SetActive(false);
    }

    public void PrintFilePath()
    {
        SetFilePath();
        Debug.Log($"?? Config file path: {filePath}");
    }

    public void PrintJSONContent()
    {
        SetFilePath();

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log($"?? JSON Content:\n{json}");
        }
        else
        {
            Debug.Log("?? No JSON file yet");
        }
    }

    public void OpenConfigFolder()
    {
        SetFilePath();
        string folderPath = Path.GetDirectoryName(filePath);

#if UNITY_EDITOR
        UnityEditor.EditorUtility.RevealInFinder(folderPath);
#endif
    }

    [ContextMenu("Test Sliders")]
    public void TestSliders()
    {
        Debug.Log("=== TEST DE SLIDERS ===");

        foreach (var element in uiElements)
        {
            if (element.controlSlider != null)
            {
                Debug.Log($"Slider '{element.elementId}': {element.controlSlider.value}");
            }
            else
            {
                Debug.Log($"Elemento '{element.elementId}': No tiene slider asignado");
            }
        }

        Debug.Log($"Archivo existe: {File.Exists(filePath)}");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Debug.Log($"JSON actual:\n{json}");
        }
    }

    [ContextMenu("Force Save Test")]
    public void ForceSaveTest()
    {
        Debug.Log("=== GUARDADO FORZADO ===");
        SaveToJSON();
    }

    [ContextMenu("Force Load Test")]
    public void ForceLoadTest()
    {
        Debug.Log("=== CARGA FORZADA ===");
        LoadFromJSON();
    }
}