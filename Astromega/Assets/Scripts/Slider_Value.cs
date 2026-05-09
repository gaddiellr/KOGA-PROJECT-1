using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Value : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider sizeSlider;
    [SerializeField] private RectTransform targetRectTransform;

    [Header("Size Settings")]
    [SerializeField] private bool maintainAspectRatio = true;

    private Vector2 originalSize;
    private float originalAspectRatio;
    private float minSize;
    private float maxSize;

    // Flag para evitar recursi�n
    private bool isLoadingFromJSON = false;

    private void Awake()
    {
        // Guardar configuraci�n original
        if (targetRectTransform != null)
        {
            originalSize = targetRectTransform.sizeDelta;
            originalAspectRatio = originalSize.x / originalSize.y;
            minSize = originalSize.y; // Alto original
            maxSize = originalSize.y * 3f; // 3x el tama�o original
        }
    }

    private void Start()
    {
        if (sizeSlider == null)
            sizeSlider = GetComponent<Slider>();

        if (targetRectTransform == null)
        {
            Debug.LogError("Target RectTransform no est� asignado!");
            return;
        }

        // Configurar el slider SOLO si NO estamos cargando desde JSON
        if (!isLoadingFromJSON)
        {
            ConfigureSlider();
        }
    }

    private void ConfigureSlider()
    {
        if (sizeSlider != null)
        {
            sizeSlider.minValue = 0f;
            sizeSlider.maxValue = 1f;

            // Limpiar listeners viejos
            sizeSlider.onValueChanged.RemoveAllListeners();

            // Agregar nuevo listener
            sizeSlider.onValueChanged.AddListener(OnSizeChanged);

            // Calcular valor basado en el tama�o actual
            float currentHeight = targetRectTransform.sizeDelta.y;
            float normalizedValue = Mathf.InverseLerp(minSize, maxSize, currentHeight);
            sizeSlider.value = normalizedValue;
        }
    }

    // M�todo p�blico para actualizar desde JSON sin sobrescribir
    void UpdateFromJSON(float newHeight, float newWidth)
    {
        if (targetRectTransform == null) return;

        Debug.Log($"?? Slider_Value: Actualizando desde JSON - Altura={newHeight}, Ancho={newWidth}");

        isLoadingFromJSON = true;

        // Cambiar el tama�o del target
        if (maintainAspectRatio)
        {
            targetRectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        }
        else
        {
            targetRectTransform.sizeDelta = new Vector2(newHeight, newHeight);
        }

        // Actualizar slider sin disparar eventos
        if (sizeSlider != null)
        {
            float normalizedValue = Mathf.InverseLerp(minSize, maxSize, newHeight);
            sizeSlider.SetValueWithoutNotify(normalizedValue);
            Debug.Log($"?? Slider actualizado a: {normalizedValue} (sin notificar)");
        }

        isLoadingFromJSON = false;
    }

    void OnSizeChanged(float value)
    {
        // Ignorar si estamos cargando desde JSON
        if (isLoadingFromJSON)
        {
            Debug.Log("?? Ignorando OnSizeChanged durante carga JSON");
            return;
        }

        if (targetRectTransform == null) return;

        Debug.Log($"??? Slider cambi� a: {value}");

        float newHeight = Mathf.Lerp(minSize, maxSize, value);

        if (maintainAspectRatio)
        {
            float newWidth = newHeight * originalAspectRatio;
            targetRectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        }
        else
        {
            targetRectTransform.sizeDelta = new Vector2(newHeight, newHeight);
        }
    }

    private void OnDestroy()
    {
        if (sizeSlider != null)
            sizeSlider.onValueChanged.RemoveListener(OnSizeChanged);
    }
}