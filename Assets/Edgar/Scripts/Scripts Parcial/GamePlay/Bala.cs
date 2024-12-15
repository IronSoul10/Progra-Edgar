using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    ContadorBajas numeroBajas;

    private void Start()
    {
        numeroBajas = FindAnyObjectByType<ContadorBajas>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            numeroBajas.BajasActuales();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
