using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AudioInstance;
    public Sonido[] musica;

    private void Awake()
    {
        if (AudioInstance == null)
        {
            AudioInstance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (Sonido s in musica)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volumen;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string nombre)
    {
        foreach (Sonido s in musica)
        {
            if (s.nombre == nombre)
            {
                Debug.Log("Now playing: " + nombre);
                s.source.Play();
                return;
            }

            Debug.Log("No sound dected");
        }
    }

    public void Stop(string nombre)
    {
        foreach (Sonido s in musica)
        {
            if (s.nombre == nombre)
            {
                Debug.Log("Now stoping: " + nombre);
                s.source.Stop();
                return;
            }

            Debug.Log("No sound dected");
        }
    }
}


