
using System.Collections;
using UnityEngine;

// Tipos de puerta: Automatica, Normal, DeLlave, Evento, MultiplesLlaves
public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] public TipoDePuerta tipoDePuerta;
    [SerializeField] public bool eventoActivado;
    [SerializeField] public SOItem key;
    [SerializeField] public SOItem[] keys;

    private InventoryHandler1 inventoryHandler;

    private void Awake()
    {
        inventoryHandler = FindObjectOfType<InventoryHandler1>();
    }
    private void Update()
    {
        Automatica();
    }

    public void Interact()
    {
        switch (tipoDePuerta)
        {
            case TipoDePuerta.Normal:
                {
                    Normal();
                    break;
                }

            case TipoDePuerta.DeLlave:
                {
                    DeLlave();
                    break;
                }

            case TipoDePuerta.Evento:
                {
                    Evento();
                    break;
                }

            case TipoDePuerta.MultiplesLlaves:
                {
                    MultiplesLlaves();
                    break;
                }
        }


    }

    private void Automatica()
    {
        if (tipoDePuerta == TipoDePuerta.Automatica && Touch())
        {
            StartCoroutine(OpenDoorAutomatic());
        }
    }
    private void Normal()
    {
        Debug.Log("Se abre");
        StartCoroutine(NormalOpen());
    }
    private void Evento()
    {
        if (eventoActivado)
        {
            Debug.Log("Se ha activado el evento");
            StartCoroutine(NormalOpen());
        }
        else
        {
            Debug.Log("No se ha activado el evento");
        }
    }
    private void MultiplesLlaves()
    {
        foreach (SOItem item in keys)
        {
            if (inventoryHandler.inventory.Contains(item))
            {
                Debug.Log("Se abrio con multiples llaves");
                StartCoroutine(NormalOpen());
            }
            else
            {
                Debug.Log("No tienes las llaves");
            }
        }
    }
    private void DeLlave()
    {
        if (inventoryHandler.inventory.Contains(key))
        {
            Debug.Log("Se abrio con 1 llave");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes la llave");
        }
    }



    bool Touch()
    {
        return Physics.CheckSphere(transform.position, 4f, LayerMask.GetMask("Player"));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }
    IEnumerator OpenDoorAutomatic()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * 2f, 2f);
        Debug.Log("Se abre automaticamente");
        yield return new WaitForSeconds(2f);
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.down * 2f, 2f);

    }
    IEnumerator NormalOpen()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * 2f, 2f);
        yield return new WaitForSeconds(2f);
    }
}

public enum TipoDePuerta
{
    Automatica, Normal, DeLlave, Evento, MultiplesLlaves
}

