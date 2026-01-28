using UnityEngine;

public class Explosion : MonoBehaviour
{
    private ParticleSystem ps;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        ps.Play();
        float totalTime = ps.main.duration + ps.main.startLifetime.constantMax;
        Destroy(gameObject, totalTime);
    }
}