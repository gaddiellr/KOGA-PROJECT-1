using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowEquation : MonoBehaviour
{
    public AstSpawner spawner;
    public TextMeshProUGUI equation;

    void Update()
    {
        if (spawner == null || equation == null)
        {
            return;
        }
        if (spawner.B >= 0)
        {
            equation.text = "Equation: " + spawner.A.ToString() + "x + " + spawner.B.ToString() + " = " + spawner.R.ToString();
        }
        else
        {
            equation.text = "Equation: " + spawner.A.ToString() + "x - " + (-1 * spawner.B).ToString() + " = " + spawner.R.ToString();
        }
    }
}
