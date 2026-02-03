using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundtracks;

    private int lastIndex;

    void Start()
    {
        lastIndex = Random.Range(0, 3);
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        PlayRandomTrack();
    }

    void Update()
    {
        if (!audioSource.isPlaying && soundtracks.Length > 0)
        {
            PlayRandomTrack();
        }
    }

    void PlayRandomTrack()
    {
        if (soundtracks.Length == 0) return;

        int randomIndex;

        do
        {
            randomIndex = Random.Range(0, soundtracks.Length);
        }
        while (randomIndex == lastIndex && soundtracks.Length > 1);

        lastIndex = randomIndex;

        audioSource.clip = soundtracks[randomIndex];
        audioSource.Play();
    }
}
