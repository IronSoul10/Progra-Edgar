using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma1 : MonoBehaviour
{
    public float velocidadBala;
    public GameObject balaPrefab;
    public Transform puntoTiro;

    public int municionActual = 100;
    public int capacidadMaxima = 100;

    private ManagerBalas contador;


    private void Start()
    {
        contador = FindAnyObjectByType<ManagerBalas>();
    }

    void Update()
    {
        AccionarArma();
    }
    void AccionarArma()
    {
        if (JalaGatillo())
        {
            Disparar();
        }
    }
    bool JalaGatillo()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    void Disparar()
    {
        if (JalaGatillo() && municionActual > 0)
        {
            GameObject clone = Instantiate(balaPrefab, puntoTiro.position, puntoTiro.rotation);
            Rigidbody rb = clone.GetComponent<Rigidbody>();
            rb.AddForce(puntoTiro.forward * velocidadBala, ForceMode.Impulse);
            Destroy(clone, 3);
            municionActual--;
            ActualizarHUD();
        }
    }

    public void MunicionActualEnArma()
    {
        municionActual = 100;

    }
    public void ActualizarHUD()
    {
        contador.MunicionActual();
    }

}
