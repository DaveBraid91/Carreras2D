using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip[] audioFX;
    // Start is called before the first frame update
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void CrashAudioFX()
    {
        audioS.loop = false;
        audioS.clip = audioFX[0];
        audioS.Play();
    }

    public void GameOverMusic()
    {
        audioS.loop = true;
        audioS.clip = audioFX[1];
        audioS.Play();
    }
}
