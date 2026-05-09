using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_canvas : MonoBehaviour
{
    public RectTransform button;
    public RectTransform joystick;

    void ChangeHand(int value)
    {
        if (value == 0) // Right hand
        {
            button.anchorMin = new Vector2(1, 0);
            button.anchorMax = new Vector2(1, 0);
            joystick.anchorMin = new Vector2(0, 0);
            joystick.anchorMax = new Vector2(0, 0);
            button.anchoredPosition = new Vector2(-300, 300);
            joystick.anchoredPosition = new Vector2(300, 300);
        }
        else if (value == 1) // Southpaw (left hand)
        {
            button.anchorMin = new Vector2(0, 0);
            button.anchorMax = new Vector2(0, 0);
            joystick.anchorMin = new Vector2(1, 0);
            joystick.anchorMax = new Vector2(1, 0);
            button.anchoredPosition = new Vector2(300, 300);
            joystick.anchoredPosition = new Vector2(-300, 300);
        }
    }
}
