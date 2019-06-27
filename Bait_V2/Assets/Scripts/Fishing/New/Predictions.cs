using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Predictions : MonoBehaviour
{
    public Image CurWeather;
    public Text WeatherTitle, WeatherDesc;

    public Text GalunChanceDis, TilaChanceDis, LapuChanceDis;

    public Sprite Sunny, Overcast, Rainy;

    public float GalunggongChances, TilapiaChances, LapuChances;
    // Start is called before the first frame update
    void Start()
    {
        UpdateChances();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWeather();

        GalunChanceDis.text = GalunggongChances.ToString() + " %";
        TilaChanceDis.text = TilapiaChances.ToString() + " %";
        LapuChanceDis.text = LapuChances.ToString() + " %";
    }

    void UpdateWeather()
    {
        WeatherTitle.text = GlobalStats.Instance.Forecast.ToString();

        switch (GlobalStats.Instance.Forecast)
        {
            case GlobalStats.Weather.Overcast:
                CurWeather.sprite = Overcast;
                WeatherDesc.text = "More fish today";
                break;

            case GlobalStats.Weather.Sunny:
                CurWeather.sprite = Sunny;
                WeatherDesc.text = "No bonus";
                break;

            case GlobalStats.Weather.Rainy:
                CurWeather.sprite = Rainy;
                WeatherDesc.text = "Less fish today";
                break;
        }
    }    

    public void UpdateChances()
    {
        GalunggongChances = 40;
        TilapiaChances = 25;
        LapuChances = 10;

        switch (GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.SandyShoals:
                GalunggongChances += 10;
                TilapiaChances -= 5;
                LapuChances -= 5;
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                GalunggongChances -= 5;
                TilapiaChances += 10;
                LapuChances -= 5;
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                GalunggongChances -= 5;
                TilapiaChances -= 5;
                LapuChances += 10;
                break;
        }

        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                GalunggongChances += 5;
                TilapiaChances -= 5;
                LapuChances -= 5;
                break;

            case GlobalStats.BaitType.Insects:
                GalunggongChances -= 5;
                TilapiaChances += 5;
                LapuChances -= 5;
                break;

            case GlobalStats.BaitType.Worms:
                GalunggongChances -= 5;
                TilapiaChances -= 5;
                LapuChances += 5;
                break;
        }

        switch (GlobalStats.Instance.Forecast)
        {
            case GlobalStats.Weather.Overcast:
                GalunggongChances += 5;
                TilapiaChances += 5;
                LapuChances += 5;
                break;

            case GlobalStats.Weather.Sunny:
                GalunggongChances += 0;
                TilapiaChances += 0;
                LapuChances += 0;
                break;

            case GlobalStats.Weather.Rainy:
                GalunggongChances -= 10;
                TilapiaChances -= 10;
                LapuChances -= 10;
                break;
        }

        if (GalunggongChances < 0)
        {
            GalunggongChances = 0;
        }

        if (TilapiaChances < 0)
        {
            TilapiaChances = 0;
        }

        if (LapuChances < 0)
        {
            LapuChances = 0;
        }
    }
}
