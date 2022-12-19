using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip audioClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.clip = audioClip;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}