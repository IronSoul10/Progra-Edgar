using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerBalas : MonoBehaviour
{
    public TextMeshProUGUI contadorTexto;
    public int municionActual = 100;


    void Start()
    {
        ActualizarContador();
    }

    public void MunicionActual()
    {
        municionActual--;
        ActualizarContador();
    }

    public void MunicionAgregada()
    {
        municionActual = 100;
        contadorTexto.text = ("") + municionActual;
    }

    public void ActualizarContador()
    {
        contadorTexto.text = ("") + municionActual;
    }
}
