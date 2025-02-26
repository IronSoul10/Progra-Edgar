using UnityEditor;
using UnityEngine;
using Weather;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

[CustomEditor(typeof(WeatherApi))]
public class WeatherEditor : Editor
{
    private bool[] foldouts; // Array para manejar los foldouts de cada país

    private void OnEnable()
    {
        // Inicializa el array de foldouts con el tamaño del array de países
        WeatherApi weatherApi = (WeatherApi)target;
        foldouts = new bool[weatherApi.countries.Length];
    }

    public override void OnInspectorGUI()
    {
        // Obtiene la referencia al script WeatherApi
        WeatherApi weatherApi = (WeatherApi)target;

        // Dibuja el campo de países
        EditorGUILayout.LabelField("Countries", EditorStyles.boldLabel);
        SerializedProperty countries = serializedObject.FindProperty("countries");
        for (int i = 0; i < countries.arraySize; i++)
        {
            SerializedProperty country = countries.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(country.FindPropertyRelative("name"), new GUIContent("Name"));
            EditorGUILayout.PropertyField(country.FindPropertyRelative("latitude"), new GUIContent("Latitude"));
            EditorGUILayout.PropertyField(country.FindPropertyRelative("longitude"), new GUIContent("Longitude"));

            // Crea un foldout para cada país
            foldouts[i] = EditorGUILayout.Foldout(foldouts[i], "Weather Data");
            if (foldouts[i])
            {
                // Verifica si este país es el actual
                if (i == weatherApi.currentCountryIndex)
                {
                    EditorGUILayout.LabelField("Time Zone", weatherApi.data.name);
                    EditorGUILayout.LabelField("Actual Temperature", weatherApi.data.actualTemp.ToString());
                    EditorGUILayout.LabelField("Wind Speed", weatherApi.data.windSpeed.ToString());
                    EditorGUILayout.LabelField("Humidity", weatherApi.data.humidity.ToString());
                }
                else
                {
                    EditorGUILayout.LabelField("Weather data not available for this country.");
                }
            }
        }

        // Aplica los cambios
        serializedObject.ApplyModifiedProperties();
    }
}
