using UnityEngine;

[System.Serializable]

public struct WeatherData
{
    [SerializeField] public string country;
    [SerializeField] public string timeZone;
    [SerializeField] public float actualTemp;
    [SerializeField] public float description;
    [SerializeField] public float windSpeed;
    [SerializeField] public string city;
}

