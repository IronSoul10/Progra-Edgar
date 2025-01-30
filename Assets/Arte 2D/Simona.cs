using System.Collections;
using UnityEngine;

public class Simona : MonoBehaviour 
{
    [Header("Arrastrar Particulas del Puzzle 1 Aqui (Acendente)")]
    public ParticleSystem[] smoke; // sistemas de partículas para el humo.

    [Header("Orden de Activacion de Humo")]
    [SerializeField] int[] order1; // Array de enteros para el orden de activación del humo en la secuencia.
    [SerializeField] int[] order2;
    [SerializeField] int[] order3;
    [SerializeField] int[] order4; 

    public void Sequence1() // Método para iniciar la secuencia 1.
    {
        if (order1.Length == 0) // Verifica si el array order1 está vacío.
        {
            order1 = new int[smoke.Length]; // Inicializa el array order1 con la misma longitud que el array smoke.
            for (int i = 0; i < order1.Length; i++) // Itera sobre el array order1.
            {
                order1[i] = i; // Asigna el valor del índice a cada elemento del array order1.
            }
        }
        StartCoroutine(PlaySequence1(order1)); // Inicia la corrutina PlaySequence1 con el array order1.
        Debug.Log("Secuencia humo 0 terminada, turno del Player");
    }
    public void Sequence2()
    {
        if (order2.Length == 0)
        {
            order2 = new int[smoke.Length];
            for (int i = 0; i < order2.Length; i++)
            {
                order2[i] = i;
            }
        }
        StartCoroutine(PlaySequence2(order2));
        Debug.Log("Secuencia humo 1 terminada Turno del Player");
    }
    public void Sequence3()
    {
        if (order3.Length == 0) 
        {
            order3 = new int[smoke.Length];
            for (int i = 0; i < order3.Length; i++) 
            {
                order3[i] = i;
            }
        }
        StartCoroutine(PlaySequence3(order3));
        Debug.Log("Secuencia 2 humo terminada Turno del Player");
    }
    public void Sequence4() 
    {
        if (order4.Length == 0)
        {
            order4 = new int[smoke.Length];
            for (int i = 0; i < order4.Length; i++)
            {
                order4[i] = i; 
            }
        }
        StartCoroutine(PlaySequence4(order4)); 
        Debug.Log("Secuencia humo 3 terminada Turno del Player");
    }


    IEnumerator PlaySequence1(int[] order1) // Corrutina para reproducir la secuencia 1.
    {
        foreach (int number in order1) // Itera sobre cada número en el array order1.
        {
            smoke[number].Play(); // Reproduce el sistema de partículas correspondiente al número.
            yield return new WaitForSeconds(1f); 
            smoke[number].Stop(); // Detiene el sistema de partículas correspondiente al número.
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator PlaySequence2(int[] order2)
    {
        foreach (int number in order2)
        {
            smoke[number].Play(); 
            yield return new WaitForSeconds(1f);
            smoke[number].Stop(); 
            yield return new WaitForSeconds(0.5f); 
        }
    }
    IEnumerator PlaySequence3(int[] order3) 
    {
        foreach (int number in order3)
        {
            smoke[number].Play();
            yield return new WaitForSeconds(1f);
            smoke[number].Stop(); 
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator PlaySequence4(int[] order3P1)
    {
        foreach (int number in order3P1)
        {
            smoke[number].Play();
            yield return new WaitForSeconds(1f);
            smoke[number].Stop();
            yield return new WaitForSeconds(0.5f);
        }
    }
}

