using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundtracks;
    private ParticleSystem ps;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        ps.Play();
        if (audioSource && soundtracks.Length > 0)
        {
            PlayRandomTrack();
        }
        float totalTime = ps.main.duration + ps.main.startLifetime.constantMax;
        Destroy(gameObject, totalTime);
    }
    
    void PlayRandomTrack()
    {
        if (soundtracks.Length == 0) return;
        int randomIndex= Random.Range(0, soundtracks.Length);
        audioSource.clip = soundtracks[randomIndex];
        audioSource.Play();
    }
}