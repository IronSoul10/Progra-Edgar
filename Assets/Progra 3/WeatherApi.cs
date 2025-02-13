using SimpleJSON;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WeatherApi : MonoBehaviour
{
    private static WeatherData data;
    [SerializeField] float latitud = 37.566f;
    [SerializeField] float longitud = 126.9784f;
    private static readonly string apiKey = "7fe45acb4f5a69f83c45312aad97613a";

    private string url;
    private string json;

    [SerializeField] private VolumeProfile volumenProfile;
    [SerializeField] private float bloomColorTransitionSpeed;
    private Color actualColor;

    private void Start()
    {
        url = $"https://api.openweathermap.org/data/3.0/onecall?lat={latitud}&lon={longitud}&appid={apiKey}&lang=sp&units=metric";
        StartCoroutine(RetrieveWhwatherData());

    }
    IEnumerator RetrieveWhwatherData()
    {
        yield return new WaitForSecondsRealtime(5);

        UnityWebRequest request = new UnityWebRequest(url);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            json = request.downloadHandler.text;
            //DecodeJson();
            yield return new WaitForSeconds(2);
            actualColor = GetColorByTemp();
            StartCoroutine(BloomColorTransition());
        }
    }
    private IEnumerator BloomColorTransition()
    {
        yield return new WaitUntil(() => TransitionColor() == actualColor);
        Debug.Log("Color Cambiado");
    }
    private Color TransitionColor()
    {
        volumenProfile.TryGet(out Bloom bloom);
        bloom.tint.value = Color.Lerp(bloom.tint.value, actualColor, bloomColorTransitionSpeed);
        return bloom.tint.value;
    }
    private Color GetColorByTemp()
    {
        switch (data.actualTemp)
        {
            case var color when data.actualTemp <= 8:
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
    private void DecodeJson()
    {
        var weatherJson = JSON.Parse(json);

        data.timeZone = weatherJson["timezone"].Value;
        data.actualTemp = float.Parse(weatherJson["current"]["temp"].Value);
        data.description = float.Parse(weatherJson["current"][0]["description"].Value);
        data.windSpeed = float.Parse(weatherJson["current"]["wind_speed"].Value);


    }
}
