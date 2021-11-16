using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocheObstaculo : MonoBehaviour
{
    public Cronometro cronometroSC;
    public AudioFX audioFXSC;

    private void Start()
    {
        Inicio();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Coche>() != null)
        {
            audioFXSC.CrashAudioFX();
            cronometroSC.time -= 20;
            Destroy(gameObject);
        }
    }

    void Inicio()
    {
        cronometroSC = GameObject.FindObjectOfType<Cronometro>();
        audioFXSC = GameObject.FindObjectOfType<AudioFX>();
    }
}
