using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ForecastManager : MonoBehaviour
{
    public ForecastInfo forecast;

    [Header("Здесь инициализируются поля для настроек")]

    [SerializeField] private Text _geoIDField;
    [SerializeField] private Toggle _curentTogle, _todayTogle;

    [Header("Здесь инициализируются поля для отображения погоды")]

    [SerializeField] private SimpleHelvetica _temperatureText;
    [SerializeField] private Text _dateAndTimeText, _cityText, _weatherConditionText
        , _pressureText, _windSpeedText, _windDirectionText;

    [SerializeField] private SpawnerWeatherPrefab _spawnerWeatherPrefab;

    private string _geoIDname = "geoid";    
    private string _yandexKeyName = "X-Yandex-API-Key";
    private string _yandexKeyValue = "f2383851-5885-4827-8967-b7d3481531fa";

    private string _yandexForecastURL = "https://api.weather.yandex.ru/v1/forecast?";
    private URIBuilder _yandexForecastURIBuilder;

    private bool curent => _curentTogle.isOn;
    private bool today => _todayTogle.isOn;
    private string periodOfDayName;

    private void Start()
    {
        _yandexForecastURIBuilder = new URIBuilder(_yandexForecastURL);
    }

    public void GetForecast()
    {
        _yandexForecastURIBuilder.SetParameter(_geoIDname, _geoIDField.text);
        _yandexForecastURIBuilder.SetParameter("limit", 2); //we get info for today and tomorrow
        _yandexForecastURIBuilder.SetParameter("hours", false); //we get info about day periods(not about every hour)
        using (UnityWebRequest request = UnityWebRequest.Get(_yandexForecastURIBuilder.GetURI()))
        {
            request.SetRequestHeader(_yandexKeyName, _yandexKeyValue);

            request.SendWebRequest();

            while(!request.isDone){
            }

            if (!request.isNetworkError & !request.isHttpError)
            {
                forecast = JsonConvert.DeserializeObject<ForecastInfo>(request.downloadHandler.text);
                ShowForecast();
            }
            else
            {
                _cityText.text = request.error;
            }
        }
    }

    public void SetPeriod(string period)
    {
        periodOfDayName = period;
    }

    public void ShowForecast()
    {
        try
        {
            _cityText.text = forecast.info.slug.ToUpper();
            var dataPeriod = forecast.fact;
            if (!curent)
            {
                var day = forecast.forecasts[0];
                if (!today)
                    day = forecast.forecasts[1];

                Day periodOfDay = day.parts.night;

                if (periodOfDayName.Equals("morning"))
                    periodOfDay = day.parts.morning;
                else if (periodOfDayName.Equals("afternoon"))
                    periodOfDay = day.parts.day;
                else if (periodOfDayName.Equals("evening"))
                    periodOfDay = day.parts.evening;

                _dateAndTimeText.text = day.date + " " + periodOfDayName;
                _temperatureText.Text = (periodOfDay.temp_avg > 0 ? "+" : "") + periodOfDay.temp_avg;
                _temperatureText.GenerateText();
                _weatherConditionText.text = periodOfDay.condition.Replace('-', ' ');
                _windDirectionText.text = "Direction: " + periodOfDay.wind_dir.ToString();
                _windSpeedText.text = "Speed [m/s]: " + periodOfDay.wind_speed.ToString();
                _pressureText.text = "Pressure [mm]: " + periodOfDay.pressure_mm.ToString();
            }
            else
            {
                _dateAndTimeText.text = forecast.now_dt.ToLocalTime().ToString();
                _temperatureText.Text = (dataPeriod.temp > 0 ? "+" : "") + dataPeriod.temp.ToString();
                _temperatureText.GenerateText();
                _weatherConditionText.text = dataPeriod.condition.Replace('-', ' ');
                _windDirectionText.text = "Direction: " + dataPeriod.wind_dir.ToString();
                _windSpeedText.text = "Speed [m/s]: " + dataPeriod.wind_speed.ToString();
                _pressureText.text = "Pressure [mm]: " + dataPeriod.pressure_mm.ToString();
            }

            _spawnerWeatherPrefab.InstantiateClouds();
        }catch(Exception e)
        {
            _cityText.text = e.Message;
        }
        

    }
}
