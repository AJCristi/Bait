using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool EndSavings;

    public float TotalMoneyEarned;
    public float TotalFishCaught;

    private void Update()
    {
        if (EndSavings)
        {
            SceneManager.LoadScene("4_GameOver");   
        }
    }

    public int Month, Day;

    public void AdvanceDay()
    {
        if(Month < 12)
        {
            Month++;
        }
        else if (Month == 12)
        {
            Month = 1;
        }

        if (Day < 30)
        {
            Day++;
        }
        else if(Day == 31)
        {
            Day = 1;
        }

    }

    [Range (5,20)]
    public int CurTime;

    public float PlayerSavings;

    //public float FishKG;

    //Small -- Galunggong
    //Medium -- Tilapia
    //Large -- Lapu-Lapu

    public float smallKG, medKG, largeKG;


    public float SmallMinKG, SmallMaxKG;
    public float MedMinKG, MedMaxKG;
    public float LargeMinKG, LargeMaxKG;

    public float setAsideFishAmt;

    public float PhpPerKG;
    public float smallFishPerKG,medFishPerKG,largeFishPerKG;

    public enum FoodItems
    {
        Chicken, 
        Beef,
        Vegetables,
        Pork,
        Fish,
        None
    }
    public float ChickenHap, ChickenHung;
    public float BeefHap, BeefHung;
    public float VegetablesHap, VegetablesHung;
    public float PorkHap, PorkHung;
    public float FishHap, FishHung;

    public FoodItems PrevFood = FoodItems.None;
    public FoodItems CurFood;
    public bool BoughtFood;

    //BOAT STATS
    [Range(1, 3)]
    public int BoatSpdLvl;
    //decrease travel time

    [Range(1, 3)]
    public int NetLevel;
    //increase # of fish per catch

    [Range(1, 3)]
    public int BaitLevel;
    //increase catch per second
    
    [Range(1, 3)]
    public int FuelTankLevel;
    //increase Time on station

    public enum NetType
    {
        Trawling,
        Cast,
        Rod
    }
    public NetType CurrentNet;

    public enum BaitType
    {
        Bread,
        Insects,
        Worms
    }
    public BaitType CurrentBait;

    public int BreadAmt, InsectAmt, WormAmt;

    // faster net reset
    [Range(1, 5)]
    public int TrawlingNetLevel;

    [Range(1, 5)]
    public int CastNetLevel;

    [Range(1, 5)]
    public int RodNetLevel;


    public enum Weather
    {
        Sunny,
        Overcast,
        Rainy 
    }
    public Weather Forecast;

    public enum FishingLocation
    {
        SandyShoals,
        ExposedReef,
        LonelyIsland
    }
    public FishingLocation SelectedLocation;

    public float ElectricityCost, WaterCost;

    [Range(1, 100)]
    public float WifeHappiness, DaughterHappiness,Hunger;

    public enum Activity
    {
        Market,
        Fishing,
        None
    }

    public Activity TS1, TS2, TS3, TS4;

    [Range(1, 5)]
    public int CurrentTime;

    public List<EventData> EventsList = new List<EventData>();
    public EventData ActiveEvent;

}
