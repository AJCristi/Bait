﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public Text Savings, Date, Time;

    public Image WeatherForecast;

    public Sprite Sunny, Overcast, Rainy;

    // Start is called before the first frame update
    void Start()
    {
        //GlobalStats.Instance.CurTime = 8;
    }

    // Update is called once per frame
    void Update()
    {
        Savings.text = GlobalStats.Instance.PlayerSavings.ToString("F2");
        //Date.text = GlobalStats.Instance.Month.ToString() + "/" + 
            GlobalStats.Instance.Day.ToString();

        Date.text = "Day " + GlobalStats.Instance.DisplayDay.ToString();

        switch(GlobalStats.Instance.Forecast)
        {
            case GlobalStats.Weather.Overcast:
                WeatherForecast.sprite = Overcast;
                break;

            case GlobalStats.Weather.Sunny:
                WeatherForecast.sprite = Sunny;
                break;

            case GlobalStats.Weather.Rainy:
                WeatherForecast.sprite = Rainy;
                break;
        }

        Time.text = GlobalStats.Instance.CurTime.ToString() + ":00";


        if (GlobalStats.Instance.PlayerSavings < 0)
        {
            Savings.color = Color.red;
        }
        else
        {
            Savings.color = Color.white;
        }

    }
}
