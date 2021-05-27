using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static SoundScript Instance;

    public AudioClip EsquiloMorte;

    void Awake()
    {
        Instance = this;
    }

    public void EsquiloMorteSound()
    {
        PlaySound(EsquiloMorte);
    }

    private void PlaySound(AudioClip Clip)
    {
        AudioSource.PlayClipAtPoint(Clip, transform.position);
    }
}
