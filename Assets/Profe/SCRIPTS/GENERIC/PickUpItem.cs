using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{

    public ParticleSystem pickUpParticles;
    public AudioSource pickUpAudio;

    public void Interact()
    {
        gameObject.SetActive(false);
        //pickUpAudio.Play();
    }

}
