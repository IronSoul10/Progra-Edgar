using TMPro;
using UnityEngine;

public class ManagerBalas : MonoBehaviour
{
    public TextMeshProUGUI contadorTextoArma1;
    public TextMeshProUGUI contadorTextoArma2;
    public int municionActualArma1 = 100;
    public int municionActualArma2 = 100;

    private void Start()
    {
        ActualizarContadores(); // Actualizar los contadores al inicio
    }

    public void DispararArma1()
    {
        if (municionActualArma1 > 0)
        {
            municionActualArma1--;
            ActualizarContadores();
        }
    }

    public void DispararArma2()
    {
        if (municionActualArma2 > 0)
        {
            municionActualArma2--;
            ActualizarContadores();
        }
    }

    public void RecargarArma1()
    {
        municionActualArma1 = 100;
        ActualizarContadores();
    }

    public void RecargarArma2()
    {
        municionActualArma2 = 100;
        ActualizarContadores();
    }

    public void ActualizarContadorArma1(int cantidad)
    {
        municionActualArma1 = cantidad;
        contadorTextoArma1.text = " " + municionActualArma1;
    }

    public void ActualizarContadorArma2(int cantidad)
    {
        municionActualArma2 = cantidad;
        contadorTextoArma2.text = " " + municionActualArma2;
    }

    private void ActualizarContadores()
    {
        contadorTextoArma1.text = " " + municionActualArma1;
        contadorTextoArma2.text = " " + municionActualArma2;
    }
}
