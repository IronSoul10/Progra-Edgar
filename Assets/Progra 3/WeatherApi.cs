using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class Country // Hice que la clase Country sea serializable para que pueda ser vista en el inspector
{
    public string name; //Nombre del país
    public float latitude; //Latitud
    public float longitude; //Longitud
}
public class WeatherApi : MonoBehaviour
{
    [SerializeField] private WeatherData data; //Estructura de la data del clima
    [SerializeField] private Country[] countries = new Country[10] ; //Paises

    private static readonly string apiKey = "7fe45acb4f5a69f83c45312aad97613a"; //API Key

    private string json; //JSON

    [SerializeField] private VolumeProfile volumenProfile; //Perfil de volumen
    [SerializeField] private float bloomColorTransitionSpeed; //Velocidad de transicion de color
    private Color actualColor; //Color actual

    private void Start()
    {
        StartCoroutine(RetrieveWhwatherData()); //Obtiene la data del clima
    }

    IEnumerator RetrieveWhwatherData()
    {
        yield return new WaitForSecondsRealtime(5); //Espera 5 segundos

        UnityWebRequest request = new UnityWebRequest(CountryURL()); //Crea un objeto de tipo UnityWebRequest con la URL del país
        request.downloadHandler = new DownloadHandlerBuffer(); //Descarga la data

        yield return request.SendWebRequest(); //Espera a que se descargue la data

        if (request.result != UnityWebRequest.Result.Success) //Si hay un error
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

    }
    string CountryURL() //URL del pais
    {
        Country country = RandomCountry(); // Obtiene un país aleatorio
                                             
        string url = $"https://api.openweathermap.org/data/3.0/onecall?lat={country.latitude}&lon={country.longitude}&appid={apiKey}&lang=sp&units=metric";  // Construye la URL de la API usando la latitud y longitud del país aleatorio
        return url; // Retorna la URL
    }

    Country RandomCountry() // Obtiene un país aleatorio
    {
        int randomIndex = Random.Range(0, countries.Length); // Genera un índice aleatorio
        return countries[randomIndex]; // Retorna el país en el índice aleatorio
    }
}
