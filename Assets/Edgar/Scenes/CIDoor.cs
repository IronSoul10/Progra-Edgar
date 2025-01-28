using UnityEditor; // Contiene todo lo que necesitamos para modificar el editor de unity

#if UNITY_EDITOR // Indica que solo se compila si estas en el editor de unity

[CustomEditor(typeof(Door))] // Este script es de custom editor, y modificara los scripts de tipo Door
public class CIDoor : Editor
{

    private Door _door; // Esta referencia la vamos a usar para nosotros poder escribir las variables que existen en el script de puerta
    SerializedProperty keysProperty;
    private string descripcion;


    private void OnEnable() // OnEnable se ejecuta cuando se activa un objeto en la escena // Se activa, al tener ese script en el inspector, exclusivamente de el objeto seleccionado
    {
        _door = (Door)target;
    }

    public override void OnInspectorGUI() // Este metodo sobreescribe TODOS los valores de el inspector 
    {
        EditorGUILayout.LabelField(descripcion);
        _door.tipoDePuerta = (TipoDePuerta)EditorGUILayout.EnumPopup("Door Type", _door.tipoDePuerta);

        switch (_door.tipoDePuerta)
        {

            case TipoDePuerta.DeLlave:
                {
                    _door.key = (SOItem)EditorGUILayout.ObjectField("Llave", _door.key, typeof(SOItem), false) as SOItem;
                    descripcion = "Esta puerta requiere de una llave para abrirse. Arrastra un objeto de tipo Item al campo";
                    break;
                }

            case TipoDePuerta.Evento:
                {
                    descripcion = "Esta puerta requiere que se cumpla un evento para poderse abrir";
                    _door.eventoActivado = EditorGUILayout.Toggle("Se puede abrir?", _door.eventoActivado);
                    break;
                }

            case TipoDePuerta.MultiplesLlaves:
                {
                    keysProperty = serializedObject.FindProperty("keys");
                    EditorGUILayout.PropertyField(keysProperty, true);
                    descripcion = "Esta puerta requiere de multiples llaves para abrirse. Indica en el arreglo cuantas llaves necesita y cuales";
                    serializedObject.ApplyModifiedProperties();
                    break;
                }

            case TipoDePuerta.Automatica:
                {
                    descripcion = "Esta puerta se abre cuando te acercas";
                    break;
                }

            case TipoDePuerta.Normal:
                {
                    descripcion = "Esta puerta se abre manualmente";
                    break;
                }

        }

    }

}

#endif