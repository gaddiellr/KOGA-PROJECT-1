using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_canvas : MonoBehaviour
{
    public GameObject leftCanvas;
    public GameObject rightCanvas;

    public void ChangeHand(int value)
    {
        if (value == 0) // Right hand
        {
            rightCanvas.SetActive(true);
            leftCanvas.SetActive(false);
        }
        else if (value == 1) // Southpaw (left hand)
        {
            rightCanvas.SetActive(false);
            leftCanvas.SetActive(true);
        }
    }
}
