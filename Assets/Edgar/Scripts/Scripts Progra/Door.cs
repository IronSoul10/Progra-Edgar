
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

   [SerializeField] Animation anim;


    private InventoryHandler1 inventoryHandler;

    private void Awake()
    {
        inventoryHandler = FindObjectOfType<InventoryHandler1>();
    }
    private void Start()
    {
        anim.Stop();
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
            anim.Play();
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


   bool Touch()
    {
        return Physics.CheckSphere(transform.position, 4f, LayerMask.GetMask("Player"));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4f);
    }

}


public enum TipoDePuerta
{
    Automatica, Normal, DeLlave, Evento, MultiplesLlaves
}

