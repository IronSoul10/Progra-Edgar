using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI cronometroTexto; // Referencia al componente de texto en el canvas
    public float tiempoInicial = 60f; // Tiempo inicial en segundos
    private float tiempoRestante;
    [SerializeField] private bool enMarcha;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiempoRestante = tiempoInicial;
        enMarcha = false;
        ActualizarCronometro(tiempoRestante);
    }

    // Update is called once per frame
    void Update()
    {
        if (enMarcha)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                enMarcha = false;
                //  realizar cuando el tiempo llegue a cero
            }
            ActualizarCronometro(tiempoRestante);
        }
    }

    public void IniciarCronometro()
    {
        enMarcha = true;
    }

    public void DetenerCronometro()
    {
        enMarcha = false;
    }

    public void ReiniciarCronometro()
    {
        enMarcha = false;
        tiempoRestante = tiempoInicial;
        ActualizarCronometro(tiempoRestante);
    }

    private void ActualizarCronometro(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60F);
        int segundos = Mathf.FloorToInt(tiempo % 60F);
        int milisegundos = Mathf.FloorToInt((tiempo * 100F) % 100F);
        cronometroTexto.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }
}
