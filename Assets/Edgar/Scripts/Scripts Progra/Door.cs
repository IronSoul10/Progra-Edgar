
using UnityEngine;

// Tipos de puerta: Automatica, Normal, DeLlave, Evento, MultiplesLlaves
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private TipoDePuerta tipoDePuerta;

    //Evento
    [SerializeField] private bool eventoActivado;

    // Llave
    [SerializeField] private SOItem key;

    // MultiplesLlaves
    [SerializeField] private SOItem[] keys;

    [SerializeField] LayerMask layer;


    private InventoryHandler1 inventoryHandler;

    private void Awake()
    {
        inventoryHandler = FindObjectOfType<InventoryHandler1>();
    }

    public void Interact()
    {

        switch (tipoDePuerta)
        {
            case TipoDePuerta.Automatica:
                {
                    Automatica();
                    Debug.Log("Se abre automaticamente");
                    break;
                }

            case TipoDePuerta.Normal:
                {
                    Normal();
                    Debug.Log("Se abre");
                    break;
                }

            case TipoDePuerta.DeLlave:
                {
                    DeLlave();
                    Debug.Log("Se abre con llave");
                    break;
                }

            case TipoDePuerta.Evento:
                {
                    Evento();
                    Debug.Log("Se abre con evento");
                    break;
                }

            case TipoDePuerta.MultiplesLlaves:
                {
                    MultiplesLlaves();
                    Debug.Log("Se abre con multiples llaves");
                    break;
                }
        }


    }


    private void Automatica()
    {
       if(Touch())
        {
            Debug.Log("Se abre automaticamente");
        }
    }

    private void Normal()
    {

    }

    private void Evento()
    {

    }

    private void MultiplesLlaves()
    {
        bool allKeysPresent = true;
        foreach (var key in keys)
        {
            if (!inventoryHandler.inventory.Contains(key))
            {
                allKeysPresent = false;
                break;
            }
        }

        if (allKeysPresent)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes las multiples llaves");
        }
    }


    private void DeLlave()
    {
        if (inventoryHandler.inventory.Contains(key))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes la llave");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador entrando");
        }
    }

    bool Touch()
    {
        return Physics.CheckSphere(transform.position, 5f, layer);
    }

}


public enum TipoDePuerta
{
    Automatica, Normal, DeLlave, Evento, MultiplesLlaves
}
