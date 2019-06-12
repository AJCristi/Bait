using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayStart : MonoBehaviour
{
    public Text Month, Day;    

    public Text FishSmallDis, FishMedDis, FishLargeDis;

    public Text SmallPrice, MedPrice, LargePrice;

    public Text WeatherForecastToday;

    public Text BreadBait, InsectBait, WormBait;

    public Text RodNet, CastNet, TrawlNet;

    public GameObject GearTab, FoodTab, MarketTab;

    enum SelectedTab
    {
        Gear,
        Food,
        Market
    }
    SelectedTab ST;
   
    // Start is called before the first frame update
    void Start()
    {
        ST = SelectedTab.Gear;

        Month.text = GlobalStats.Instance.Month.ToString();
        Day.text = GlobalStats.Instance.Day.ToString();

        BreadBait.text = GlobalStats.Instance.BreadAmt.ToString();
        InsectBait.text = GlobalStats.Instance.InsectAmt.ToString();
        WormBait.text = GlobalStats.Instance.WormAmt.ToString();

        RodNet.text = GlobalStats.Instance.RodNetLevel.ToString();
        CastNet.text = GlobalStats.Instance.RodNetLevel.ToString();
        TrawlNet.text = GlobalStats.Instance.RodNetLevel.ToString();

        if (GlobalStats.Instance.smallKG > 0)
        {
            FishSmallDis.enabled = true;
        }
        else
        {
            FishSmallDis.enabled = false;
        }

        if (GlobalStats.Instance.medKG > 0)
        {
            FishMedDis.enabled = true;
        }
        else
        {
            FishMedDis.enabled = false;
        }

        if (GlobalStats.Instance.largeKG > 0)
        {
            FishLargeDis.enabled = true;
        }
        else
        {
            FishLargeDis.enabled = false;
        }

        FishSmallDis.text = GlobalStats.Instance.smallKG.ToString() + " Kgs";
        FishMedDis.text = GlobalStats.Instance.medKG.ToString() + " Kgs";
        FishLargeDis.text = GlobalStats.Instance.largeKG.ToString() + " Kgs";

        SmallPrice.text = "PHP " + GlobalStats.Instance.smallFishPerKG.ToString() + " /kg";
        MedPrice.text = "PHP " + GlobalStats.Instance.medFishPerKG.ToString() + " /kg";
        LargePrice.text = "PHP " + GlobalStats.Instance.largeFishPerKG.ToString() + " /kg";

        AssignWeatherToday();
        WeatherForecastToday.text = GlobalStats.Instance.Forecast.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        switch(ST)
        {
            case SelectedTab.Food:
                GearTab.SetActive(false);
                FoodTab.SetActive(true);
                MarketTab.SetActive(false);
                break;

            case SelectedTab.Gear:
                GearTab.SetActive(true);
                FoodTab.SetActive(false);
                MarketTab.SetActive(false);
                break;

            case SelectedTab.Market:
                GearTab.SetActive(false);
                FoodTab.SetActive(false);
                MarketTab.SetActive(true);
                break;
        }
    }

    public void SelectFood()
    {
        ST = SelectedTab.Food;
    }

    public void SelectGear()
    {
        ST = SelectedTab.Gear;
    }

    public void SelectMarket()
    {
        ST = SelectedTab.Market;
    }

    void AssignWeatherToday()
    {
        float x = Random.Range(1, 100);
        Debug.Log(x);
        if (x < 40)
        {
            GlobalStats.Instance.Forecast = GlobalStats.Weather.Sunny;
        }
        else if (x >= 40 && x < 80)
        {
            GlobalStats.Instance.Forecast = GlobalStats.Weather.Overcast;
        }
        else
        {
            GlobalStats.Instance.Forecast = GlobalStats.Weather.Rainy;
        }

    }
   
}
