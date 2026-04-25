using UnityEngine;

public class ColorSet : MonoBehaviour
{
    public ParticleSystem ps;
    private Color[] a = {new Color(216f/255f, 0f, 1f, 15f/255f), new Color(1f, 0f, 0f, 15f/255f), new Color(0f, 1f, 0f, 15f/255f), new Color(0f, 0.8f, 1f, 15f/255f)};
    private Color[] b = {new Color(1f, 147f/255f, 0f, 15f/255f), new Color(0f, 0f, 1f, 15f/255f), new Color(0f, 1f, 1f, 15f/255f), new Color(1f, 1f, 1f, 15f/255f)};

    void Start()
    {
        var part = ps.main;
        int x = Random.Range(0, 4);
        part.startColor = new ParticleSystem.MinMaxGradient(a[x], b[x]);
    }
}