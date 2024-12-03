using System;
using UnityEngine;


/// Nombramineto de Scripts
/// Nomenclatura Pascal Case <summary>
/// Nombramineto de Scripts
/// </summary>
public class Notas : MonoBehaviour
{
    /// Nombramiento de carpetas
    /// Todas las letras en Mayusculas

    /// Nombramiento de variables
    /// Se usa la nomenclatura Camel Case, la cual indica que la primera letra de la primera palabra en el nombre de la variable
    /// se escribe en minuscula, 

    [SerializeField] private int vidaMaxima; // Este es el nombramiento tipico de variables

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


    /// <summary>
    /// CLASES ABSTRACTAS
    /// 
    /// Nos permiten heredar codigo y lógica. Ya sea que la lógica pueda ser con definición 
    /// o no. Tambien puede ser que queramos o no heredar dicha lógica.
    /// 
    /// METODOS ABSTRACTOS
    /// 
    /// Los metodos abstractos son metodos no contienen una definición o lógica de que es lo que hacen
    /// sino que le damos forma hasta que llegue el momento de la herencia
    /// 
    /// El metodo abstracto lo declaras cuando quieres que cada miembro de la herencia tenga una
    /// funcion diferente
    /// 
    /// El metodo abstracto es obligatorio implementarlo, aun si este tenga o no lógica
    /// 
    /// METODO VIRTUAL
    /// 
    /// Los metodos virtuales son metodos que pueden o no tener una definicion o lógica de que es lo que hacen.
    /// Podemos darle forma desde antes de la herencia y escoger si queremos heredar esa lógica
    /// o darle una nueva
    /// 
    /// El metodo virtual puedo o no implementarlo
    /// 
    /// INTERFACE
    /// 
    /// Es para darle una funcion a un objeto
    /// 
    /// </summary>
    /// 

}
