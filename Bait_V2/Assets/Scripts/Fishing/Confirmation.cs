using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Confirmation : MonoBehaviour
{
    public Text DisplayNetLvl,DisplaySpdLvl,DisplayBaitLvl,DisplayFuelLvl;

    public Text SelectedLoc,LocDescript;

    public string LocSSDescription, LocERDescription, LocLIDescription;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayBoatStats();
        DisplayLocation();
    }

    void DisplayBoatStats()
    {
        DisplayNetLvl.text = GlobalStats.Instance.NetLevel.ToString();
        DisplayBaitLvl.text = GlobalStats.Instance.BaitLevel.ToString();
        DisplaySpdLvl.text = GlobalStats.Instance.BoatSpdLvl.ToString();
    }

    void DisplayLocation()
    {
        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.ExposedReef:
                SelectedLoc.text = "Exposed Reef";
                LocDescript.text = LocERDescription;
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                SelectedLoc.text = "Lonely Island";
                LocDescript.text = LocLIDescription;
                break;

            case GlobalStats.FishingLocation.SandyShoals:
                SelectedLoc.text = "Sandy Shoals";
                LocDescript.text = LocSSDescription;
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
