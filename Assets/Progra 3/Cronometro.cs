using TMPro;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    [SerializeField] private bool enMarcha;
    public TextMeshProUGUI cronometroTexto; // Referencia al componente de texto en el canvas
    public float tiempoInicial = 60f; // Tiempo inicial en segundos
    private float tiempoRestante;
    [SerializeField] private GameObject CanvasLeaderBoard;


    void Start()
    {
        tiempoRestante = tiempoInicial;
        enMarcha = true;
        ActualizarCronometro(tiempoRestante);
        Cursor.lockState = CursorLockMode.Locked;
    }

  
    void Update()
    {
        if (enMarcha)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                enMarcha = false;
                CanvasLeaderBoard.SetActive(true); //realizar cuando el tiempo llegue a cero
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            ActualizarCronometro(tiempoRestante);
        }
    }

    public void ReiniciarCronometro()
    {
        enMarcha = false;
        tiempoRestante = tiempoInicial;
        ActualizarCronometro(tiempoRestante);
    }

    private void ActualizarCronometro(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60F); // Dividir el tiempo en minutos
        int segundos = Mathf.FloorToInt(tiempo % 60F); 
        int milisegundos = Mathf.FloorToInt((tiempo * 100F) % 100F);
        cronometroTexto.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos); 
    }
}
