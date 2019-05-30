using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayStart : MonoBehaviour
{
    public Text Month, Day;

    public Text FuelLvl, MotorLvl, BaitLvl, NetLvl;

    public Text FishAmt;

    public Text SmallPrice, MedPrice, LargePrice;

    public Text WeatherForecastToday;
    //todo add foodstorage

    // Start is called before the first frame update
    void Start()
    {
        Month.text = GlobalStats.Instance.Month.ToString();
        Day.text = GlobalStats.Instance.Day.ToString();

        FuelLvl.text = GlobalStats.Instance.FuelTankLevel.ToString();
        MotorLvl.text = GlobalStats.Instance.BoatSpdLvl.ToString();
        BaitLvl.text = GlobalStats.Instance.BaitLevel.ToString();
        NetLvl.text = GlobalStats.Instance.NetLevel.ToString();

        FishAmt.text = GlobalStats.Instance.FishKG.ToString() + " Kgs";

        SmallPrice.text = "PHP " + GlobalStats.Instance.smallFishPerKG.ToString() + " /kg";
        MedPrice.text = "PHP " + GlobalStats.Instance.medFishPerKG.ToString() + " /kg";
        LargePrice.text = "PHP " + GlobalStats.Instance.largeFishPerKG.ToString() + " /kg";

        WeatherForecastToday.text = GlobalStats.Instance.Forecast.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
