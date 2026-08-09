using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSet : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        int i = 0;
        foreach (Material mat in material) i++;
        int x = Random.Range(-1, i);
        if (x > -1) rend.sharedMaterial = material[x];
    }
}
