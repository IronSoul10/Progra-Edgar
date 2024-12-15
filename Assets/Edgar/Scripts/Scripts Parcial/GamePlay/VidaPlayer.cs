using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField] int vida = 100;
    [SerializeField] Transform spawn;
    [SerializeField] TextMeshProUGUI vidaText;

    [SerializeField] CharacterController controller;
    [SerializeField] MuertePlayer player;



    private void Start()
    {
        ActualizarVidaText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
           QuitarVida();
        }
    }
    public void QuitarVida()
    {
        vida -= 10;
        ActualizarVidaText();
        StartCoroutine(player.Explocion());

        if (vida <= 0)
          {
            controller.enabled = false;
            transform.position = spawn.position;
            vida = 100;
            ActualizarVidaText();
            controller.enabled = true;

           }
    }

    void ActualizarVidaText()
    { 
       vidaText.text = "" + vida.ToString();
    }
}
