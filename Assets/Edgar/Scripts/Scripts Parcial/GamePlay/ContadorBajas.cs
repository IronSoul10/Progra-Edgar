
using TMPro;
using UnityEngine;

public class ContadorBajas : MonoBehaviour
{
    [SerializeField] int objetivoBajas;
    public TextMeshProUGUI Bajas;
    public int numeroBajas;

    [SerializeField] GameObject openDoor;
    [SerializeField] GameObject closeDoor;

    private void Start()
    {
        ActualizarContador();
        
    }

    private void Update()
    {
        Salida();
      
    }
   
   
    public void BajasActuales()
    {
        numeroBajas++;
        ActualizarContador();
    }
    public void ActualizarContador()
    {
        Bajas.text = ("") + numeroBajas;
    }

   public void Salida()
    {
        if (numeroBajas >= objetivoBajas) 
        {
            Debug.Log("Se Acabo");
            openDoor.SetActive(true);
            closeDoor.SetActive(false);
            
        }
    }

    

}
