using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
    public static EffectSound instance;
    public AudioSource audioSource;
    private void Awake()
    {
        instance = this;
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
}
