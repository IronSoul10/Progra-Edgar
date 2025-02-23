using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamaraSeguridad : MonoBehaviour
{
    [SerializeField] private Camera secondaryCamera; // C�mara secundaria
    [SerializeField] private RawImage secondaryCameraView; // Vista de la c�mara secundaria

    private void Start()
    {
        secondaryCamera.enabled = true; // Inicialmente, la c�mara secundaria est� desactivada
        secondaryCameraView.enabled = true; // Inicialmente, la vista de la c�mara secundaria est� desactivada
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        secondaryCamera.enabled = true; // Activar la c�mara secundaria
    //        secondaryCameraView.enabled = true; // Mostrar la vista de la c�mara secundaria
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        secondaryCamera.enabled = false; // Desactivar la c�mara secundaria
    //        secondaryCameraView.enabled = false; // Ocultar la vista de la c�mara secundaria
    //    }
    //}
}


