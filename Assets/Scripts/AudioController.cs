using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] sonsEfeitos;
    public AudioClip[] sonsBackground;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void tocarAudio(AudioClip music, float tamanho = 1)
    {
        audioSource.PlayOneShot(music, tamanho);
    }

    public bool vericarSeAudioEstaTocando()
    {
        return true ? audioSource.isPlaying : false;
    }
}
