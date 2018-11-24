using System;
using UnityEngine;

/// <summary>
/// Generic script for playing sounds
/// <remarks>
/// Plays sound from location of containing gameobject
/// </remarks>
/// </summary>
public class AudioPlayer : MonoBehaviour
{
    public AudioClip SoundFile;

    [Header("Sound Settings")]
    public bool Loop;
    public bool PlayOnAwake;

    public float DelayInSeconds;

    [Range(0, 100)]
    [Tooltip("Percentage of the volume")]
    public int Volume = 100;

    [Range(0, 256)]
    [Tooltip("Sound priority in relation to other active sounds")]
    public int Priority = 128;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = SoundFile;
        audioSource.volume = Volume / 100;
        audioSource.loop = Loop;

        if (PlayOnAwake)
            Play();
    }

    public void Play()
    {
        if (DelayInSeconds > 0)
            audioSource.PlayDelayed(DelayInSeconds);
        else
            audioSource.Play();
    }
}
