using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirmation : MonoBehaviour
{
    public Text DisplayNetLvl,DisplaySpdLvl,DisplayBaitLvl,DisplayFuelLvl;

    public Text SelectedLoc,LocDescript,FishDescript;

    public string LocSSDescription, LocERDescription, LocLIDescription;
    public string FishSSDescription, FishERDescription, FishLIDescription;

    public Text Weather, WDescription;

    public string SunnyDes, OverDes, RainDes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayBoatStats();
        DisplayLocation();
        DisplayWeather();


    }

    void DisplayBoatStats()
    {
        DisplayNetLvl.text = GlobalStats.Instance.NetLevel.ToString();
        DisplayFuelLvl.text = GlobalStats.Instance.FuelTankLevel.ToString();
        DisplayBaitLvl.text = GlobalStats.Instance.BaitLevel.ToString();
        DisplaySpdLvl.text = GlobalStats.Instance.BoatSpdLvl.ToString();
    }

    void DisplayWeather()
    {
        Weather.text = GlobalStats.Instance.Forecast.ToString();
        switch (GlobalStats.Instance.Forecast)
        {
            case GlobalStats.Weather.Overcast:
                WDescription.text = OverDes;
                break;

            case GlobalStats.Weather.Sunny:
                WDescription.text = SunnyDes;
                break;

            case GlobalStats.Weather.Rainy:
                WDescription.text = RainDes;
                break;
        }
    }

    void DisplayLocation()
    {
        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.ExposedReef:
                SelectedLoc.text = "Exposed Reef";
                LocDescript.text = LocERDescription;
                FishDescript.text = FishERDescription;
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                SelectedLoc.text = "Lonely Island";
                LocDescript.text = LocLIDescription;
                FishDescript.text = FishLIDescription;
                break;

            case GlobalStats.FishingLocation.SandyShoals:
                SelectedLoc.text = "Sandy Shoals";
                LocDescript.text = LocSSDescription;
                FishDescript.text = FishSSDescription;
                break;
        }
    }

    public void ChangeLocation()
    {
        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.ExposedReef:
                GlobalStats.Instance.SelectedLocation =
                    GlobalStats.FishingLocation.LonelyIsland;
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                GlobalStats.Instance.SelectedLocation =
                    GlobalStats.FishingLocation.SandyShoals;
                break;

            case GlobalStats.FishingLocation.SandyShoals:
                GlobalStats.Instance.SelectedLocation =
                    GlobalStats.FishingLocation.ExposedReef;
                break;
        }
    }

    public void HeadOut()
    {
        GameObject.Find("FishingMain").GetComponent<FishingScene>().Started();
    }

}
