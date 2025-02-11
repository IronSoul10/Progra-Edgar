using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RendererUtils;

public class WeatherApi : MonoBehaviour
{
    private static WeatherData data;
    [SerializeField] float latitud = 37.566f;
    [SerializeField] float longitud = 126.9784f;
    private static readonly string apiKey = "7fe45acb4f5a69f83c45312aad97613a";

    private string url;
    private string json;

    private void Start()
    {
        url = $"https://api.openweathermap.org/data/2.5/onecall?lat={latitud}&lon={longitud}&appid={apiKey}";

    }
    IEnumerator GetWeatherData()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            json = request.downloadHandler.text;
            Debug.Log(json);
            
        }
    }
}
