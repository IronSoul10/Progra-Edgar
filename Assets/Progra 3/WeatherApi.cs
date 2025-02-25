using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WeatherApi : MonoBehaviour
{
    private static WeatherData data; //Estructura de la data del clima
    [SerializeField] float latitud = 37.566f; //Latitud de la ciudad
    [SerializeField] float longitud = 126.9784f; //Longitud de la ciudad
    [SerializeField] private string countryName; // Nombre del país para mostrar en el inspector
    private static readonly string apiKey = "7fe45acb4f5a69f83c45312aad97613a"; //API Key

    private string url; //URL de la API
    private string json; //JSON

    [SerializeField] private VolumeProfile volumenProfile; //Perfil de volumen
    [SerializeField] private float bloomColorTransitionSpeed; //Velocidad de transicion de color
    private Color actualColor; //Color actual

    private void Start()
    {
        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={latitud}&lon={longitud}&appid={apiKey}&lang=sp&units=metric"; //URL de la API
        StartCoroutine(RetrieveWhwatherData()); //Obtiene la data del clima
    }

    IEnumerator RetrieveWhwatherData()
    {
        yield return new WaitForSecondsRealtime(5); //Espera 5 segundos

        UnityWebRequest request = new UnityWebRequest(url); //Crea un objeto de tipo UnityWebRequest
        request.downloadHandler = new DownloadHandlerBuffer(); //Descarga la data

        yield return request.SendWebRequest(); //Espera a que se descargue la data

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error); //Error
        }
        else
        {
            Debug.Log(request.downloadHandler.text); //JSON
            json = request.downloadHandler.text; // JSON
            DecodeJson(); //Decodifica el JSON
            yield return new WaitForSeconds(2); //Espera 2 segundos para que se cargue la data
            actualColor = GetColorByTemp(); //Obtiene el color segun la temperatura
            StartCoroutine(BloomColorTransition()); //Transicion de color
        }
    }

    private IEnumerator BloomColorTransition() //Transicion de color
    {
        yield return new WaitUntil(() => TransitionColor() == actualColor); //Espera a que la transicion de color termine
        Debug.Log("Color Cambiado");
    }

    private Color TransitionColor() //Transicion de color
    {
        volumenProfile.TryGet(out Bloom bloom); // Obtiene el bloom del perfil de volumen
        bloom.tint.value = Color.Lerp(bloom.tint.value, actualColor, bloomColorTransitionSpeed); //Transicion de color
        return bloom.tint.value; //Retorna el color
    }

    private Color GetColorByTemp() //Obtiene el color segun la temperatura
    {
        switch (data.actualTemp)
        {
            case var color when data.actualTemp <= 8: //Si la temperatura es menor o igual a 8
                {
                    actualColor = Color.cyan;
                    return actualColor;
                }

            case var color when data.actualTemp > 8 && data.actualTemp < 24:
                {
                    actualColor = new Color(176, 154, 0);
                    return actualColor;
                }

            case var color when data.actualTemp > 24 && data.actualTemp < 45:
                {
                    actualColor = new Color(255, 179, 0);
                    return actualColor;
                }

            case var color when data.actualTemp >= 45:
                {
                    actualColor = Color.red;
                    return actualColor;
                }

            default:
                {
                    return actualColor;
                }
        }
    }

    public void DecodeJson()
    {
        var weatherJson = JSON.Parse(json);
        Debug.Log("mostrar datos");

        data.timeZone = weatherJson["timezone"].Value; //Zona horaria
        data.actualTemp = float.Parse(weatherJson["current"]["temp"].Value); //Temperatura actual
        data.description = float.Parse(weatherJson["current"][0]["description"].Value); //Descripcion
        data.windSpeed = float.Parse(weatherJson["current"]["wind_speed"].Value); //Velocidad del viento
        data.country = weatherJson["current"]["sys"]["country"].Value; //Pais
        data.city = weatherJson["current"]["name"].Value; //Ciudad

        countryName = data.country; // Actualiza el nombre del país para mostrar en el inspector
    }
}
