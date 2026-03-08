using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider_Value: MonoBehaviour
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

    private void Start()
    {
        // Obtener referencias si no están asignadas
        if (sizeSlider == null)
            sizeSlider = GetComponent<Slider>();

        if (targetRectTransform == null)
            Debug.LogError("Target RectTransform no está asignado!");
        else
        {
            // Guardar el tamaño original
            originalSize = targetRectTransform.sizeDelta;
            originalAspectRatio = originalSize.x / originalSize.y;

            // Calcular min y max basado en el tamaño original
            minSize = originalSize.y; // Usamos el alto como referencia
            maxSize = originalSize.y * 3f; // 5 veces el tamaño original

            // Configurar el slider
            ConfigureSlider();
        }
    }

    private void ConfigureSlider()
    {
        if (sizeSlider != null)
        {
            sizeSlider.minValue = 0f;
            sizeSlider.maxValue = 1f;
            sizeSlider.value = 0f; // Valor inicial en mínimo (tamaño original)
            sizeSlider.onValueChanged.AddListener(OnSizeChanged);

            // Aplicar el tamaño inicial
            OnSizeChanged(0f);
        }
    }

    public void OnSizeChanged(float value)
    {
        if (targetRectTransform == null) return;

        // Calcular el nuevo tamaño (desde original hasta 5x original)
        float newSize = Mathf.Lerp(minSize, maxSize, value);

        if (maintainAspectRatio)
        {
            // Mantener la proporción original
            targetRectTransform.sizeDelta = new Vector2(
                newSize * originalAspectRatio,
                newSize
            );
        }
        else
        {
            // Cambiar ambos lados por igual
            targetRectTransform.sizeDelta = new Vector2(newSize, newSize);
        }
    }

    private void OnDestroy()
    {
        if (sizeSlider != null)
            sizeSlider.onValueChanged.RemoveListener(OnSizeChanged);
    }
}
