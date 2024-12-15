using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// /// EJERCICIO/TAREA
/// 
/// Hacer que deje de perseguir al objetivo
/// </summary>
public class PerseguirObjetivo : MonoBehaviour
{


    public Transform objetivo;
    public float velocidad;
    private Deteccion deteccion;

    private NavMeshAgent agent;

    private void Start()
    {
        deteccion = GetComponent<Deteccion>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        DejarDePerseguir();
    }

    public void Perseguir()
    {
        agent.speed = velocidad;
        agent.destination = objetivo.position;
    }

    public void DejarDePerseguir()
    {
        if (agent == null)
        {
          agent.destination = transform.position;
        }
    }
}
