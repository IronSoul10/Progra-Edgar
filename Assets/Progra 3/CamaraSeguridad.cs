using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamaraSeguridad : MonoBehaviour
{
    [SerializeField] private Camera secondaryCamera; // Cámara secundaria
    [SerializeField] private RawImage secondaryCameraView; // Vista de la cámara secundaria

    private void Start()
    {
        secondaryCamera.enabled = true; // Inicialmente, la cámara secundaria está desactivada
        secondaryCameraView.enabled = true; // Inicialmente, la vista de la cámara secundaria está desactivada
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        secondaryCamera.enabled = true; // Activar la cámara secundaria
    //        secondaryCameraView.enabled = true; // Mostrar la vista de la cámara secundaria
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        secondaryCamera.enabled = false; // Desactivar la cámara secundaria
    //        secondaryCameraView.enabled = false; // Ocultar la vista de la cámara secundaria
    //    }
    //}
}


