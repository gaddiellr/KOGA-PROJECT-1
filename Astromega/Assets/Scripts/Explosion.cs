using UnityEngine;

public class Explosion : MonoBehaviour
{
    private ParticleSystem ps;
    public AudioSource audioSource;
    public AudioClip[] soundtracks;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        ps.Play();
        if (soundtracks.Length > 0)
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