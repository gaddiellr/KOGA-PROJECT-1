using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathMove : MonoBehaviour
{
    /*  
    public float breathSpeed = 1f;     // Slow = calm breathing
    public float moveAmount = 10f;     // Pixels up/down

    private RectTransform rectTransform;
    private Vector2 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * breathSpeed) * moveAmount;
        rectTransform.anchoredPosition = startPos + new Vector2(0, offset);
    }
    */
[Header("Breathing")]
    public float breathSpeed = 0.8f;
    public float breathAmount = 8f;

    [Header("Joystick Movement")]
    public float moveSpeed = 300f;
    public float deadZone = 0.15f;

    [Header("Return To Center")]
    public float returnSpeed = 5f;

    [Header("Movement Limits (UI units)")]
    public Vector2 minLimit = new Vector2(-300, -200);
    public Vector2 maxLimit = new Vector2(300, 200);

    public FixedJoystick joystick; // or your joystick

    private RectTransform rectTransform;
    private Vector2 originalPos;   // center position
    private Vector2 basePos;       // controlled position

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        basePos = originalPos;
    }

    void Update()
    {
        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);

        // 🕹️ Move with joystick
        if (input.magnitude > deadZone)
        {
            basePos += input * moveSpeed * Time.deltaTime;
        }
        // 🔁 Return to original position when released
        else
        {
            basePos = Vector2.Lerp(basePos, originalPos, returnSpeed * Time.deltaTime);
        }

        // 🔒 Clamp inside limits
        basePos.x = Mathf.Clamp(basePos.x, minLimit.x, maxLimit.x);
        basePos.y = Mathf.Clamp(basePos.y, minLimit.y, maxLimit.y);

        // 🌬️ Breathing (cosmetic only)
        float breathOffset = Mathf.Sin(Time.time * breathSpeed) * breathAmount;

        // ✅ Final position
        rectTransform.anchoredPosition = basePos + new Vector2(0, breathOffset);
    }
}