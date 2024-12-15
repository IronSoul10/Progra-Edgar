using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// EJERCICIO/TAREA
/// 
/// Al regresar a patrullar debe de ir al ultimo punto a donde se dirigia antes de detectar al objetivo. Y regresar a su velocidad de patrullaje.
/// Y continuar patrullando
/// 
/// </summary>
public class Patrullaje : MonoBehaviour
{

    public Transform[] puntosDePatrullaje;
    public float tiempoDeVigilancia;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Patrullar());
    }

    public IEnumerator Patrullar()
    {
        Transform randomPos = RandomPos();

        agent.destination = randomPos.position;

        yield return new WaitUntil(() => Vector3.Distance(transform.position,randomPos.position) < 2);

        Debug.Log("Ya llegó al punto");

        yield return new WaitForSeconds(tiempoDeVigilancia);

        StartCoroutine(Patrullar());
    }
    public void DejarDePatrullar()
    {
        StopAllCoroutines();
    }

    public void ReanudarPatrulla(Vector3 puntoInterrumpido)
    {
        StartCoroutine(ReanudarDesdePunto(puntoInterrumpido)); // Inicia la corrutina para reanudar desde el punto interrumpido
    }
    private IEnumerator ReanudarDesdePunto(Vector3 puntoInterrumpido)
    {
        agent.destination = puntoInterrumpido;  // Asigno el punto interrumpido como destino
        yield return new WaitUntil(() => Vector3.Distance(transform.position, puntoInterrumpido) < 2);
        StartCoroutine(Patrullar()); // Reanudar la patrulla una vez que se alcanza el punto interrumpido
    }
    private Transform RandomPos()
    {
        int randomPoint = Random.Range(0,puntosDePatrullaje.Length);
        return puntosDePatrullaje[randomPoint];
    }

}
