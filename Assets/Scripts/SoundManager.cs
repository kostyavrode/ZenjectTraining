using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SoundManager : MonoBehaviour
{
    public TMP_Text soundText;
    private bool isSoundEnabled;
    public AudioSource audioSourcePrefab;
    private AudioSource audioSource;
    private void OnEnable()
    {
        isSoundEnabled = true;

        if (audioSource == null)
        {
            try
            {
                audioSource = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();

            }
            catch
            {
                audioSource = Instantiate(audioSourcePrefab);
                CheckSound();
            }

        }
        DontDestroyOnLoad(audioSource);

    }
    private void CheckSound()
    {
        if (isSoundEnabled)
        {
            audioSource.Play();
            soundText.text = "On";
        }
        else
        {
            audioSource.Pause();
            soundText.text = "Off";
        }
    }
    public void AudioButton()
    {
        isSoundEnabled = !isSoundEnabled;
        CheckSound();
    }
}
