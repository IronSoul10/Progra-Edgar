using UnityEngine;


/// Nombramineto de Scripts
/// Nomenclatura Pascal Case
public class Notas : MonoBehaviour
{
    /// Nombramiento de carpetas
    /// Todas las letras en Mayusculas

    /// Nombramiento de variables
    /// Se usa la nomenclatura Camel Case, la cual indica que la primera letra de la primera palabra en el nombre de la variable
    /// se escribe en minuscula, 

    private int vidaMaxima; // Este es el nombramiento tipico de variables

    /// Nombramiento de metodos
    /// Se usa la nomenclatura Pascal Case, la cual indica que la primera letra de cada palabra en el nombre de la variable empieza en Mayuscula

    private void MetodoChido()
    {

    }

    /// <summary>
    /// Es el primer metodo que se ejecuta independientemente de si el script
    /// estaba activo o no
    /// </summary>
    private void Awake()
    {
        Debug.Log("1");
    }

    /// <summary>
    /// Es el metodo o funciona que se ejecuta primero al activarse el script
    /// 
    /// Esto se suele usar para dar una configuracion inicial al objeto
    /// </summary>
    private void Start()
    {
        Debug.Log("2");
    }

    /// <summary>
    /// OnEnable sucede al prender el script y sucede primero que el start pero despues del awake
    /// </summary>
    private void OnEnable()
    {
        Debug.Log("Se prende el script");
    }

    /// OnEnable sucede al apagar el script
    private void OnDisable()
    {
        Debug.Log("Se apaga el script");
    }

    public bool pausarTiempo;

    /// <summary>
    /// Ejecuta lo que tenga dentro al momento de realizar un cambio en el inspector
    /// </summary>
    private void OnValidate()
    {
        if (pausarTiempo)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public float speed;
    public bool tiempoEscalado;

    /// <summary>
    /// Se ejecuta cada frame
    /// </summary>
    private void Update()
    {
        if (tiempoEscalado)
        {
            transform.position += Vector3.one * Time.deltaTime * speed;
        }
        else
        {
            transform.position += Vector3.one * Time.unscaledDeltaTime * speed;
        }
    }

    /// <summary>
    /// Se ejecuta a un frame rate especifico
    /// </summary>
    private void FixedUpdate()
    {

    }
}
