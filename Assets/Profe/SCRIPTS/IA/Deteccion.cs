using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EJERCICIO/TAREA
/// 
/// Tienen que hacer que cuando se deje de detectar al objetivo después de X cantidad de tiempo, este regrese a el ultimo punto de patrullaje al que fue
/// 
/// </summary>
public class Deteccion : MonoBehaviour
{

    public float radioDeDetección;
    public LayerMask layer;

    private Patrullaje patrullador;
    private PerseguirObjetivo perseguir;

    private Vector3 puntoInterrumpido;
    float tiempoSinDetenccion; //
    float tiempoEspera = 2.0f; //

    private void Start()
    {
        patrullador = GetComponent<Patrullaje>();
        perseguir = GetComponent<PerseguirObjetivo>();
    }

    private void Update()
    {
        Detectar();
    }

    private void Detectar() 
    {
        if (Physics.CheckSphere(transform.position, radioDeDetección, layer))
        {
            patrullador.DejarDePatrullar();
            perseguir.Perseguir();
            tiempoSinDetenccion = 0;// reinicia el tiempo cuando no hay deteccion
        }
        else
        {
            tiempoSinDetenccion += Time.deltaTime;

            if (tiempoSinDetenccion >= tiempoEspera) // Si (el tiempo sin detección es mayor o igual al tiempo de espera)
            {
                puntoInterrumpido = transform.position; // Guarda la posición actual como punto interrumpido
                patrullador.ReanudarPatrulla(puntoInterrumpido); // reanuda la patrulla

            }
        }
        
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;    
        Gizmos.DrawWireSphere(transform.position, radioDeDetección);
    }


}
