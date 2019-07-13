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

    public float PerDayEarning;
    public float YesterdayEarning;

    public float HighestEarnings;

    public void CheckHighestEarnings()
    {
        if (PerDayEarning >= HighestEarnings)
        {
            HighestEarnings = PerDayEarning;
        }
    }

    public void UpdateRate()
    {
        YesterdayEarning = 0;
        YesterdayEarning = PerDayEarning;
    }

    public int TotalDaysPassed;

    private void Update()
    {        
        //if(PlayerSavings < 0)
        //{
        //    PlayerSavings = 0;
        //}
        
    }

    public int Month, Day;

    public int EndMonth, EndDay;

    public void CheckWin()
    {
        if(EndDay <= Day)
        {
            Debug.Log("xx");
            SceneManager.LoadScene("5_Credits");
        }
    }


    public void AdvanceDay()
    {
        if (Day < 30)
        {
            Day++;
        }
        else if(Day == 31)
        {
            Day = 1;
            Month++;
        }
        TotalDaysPassed++;
        CheckWin();
    }

    [Range (5,24)]
    public int CurTime;

    public void AdvanceTime(int x)
    {
        CurTime += x;
    }

    public float PlayerSavings;

    //public float FishKG;

    //Small -- Galunggong
    //Medium -- Tilapia
    //Large -- Lapu-Lapu

    public float smallKG, medKG, largeKG;


    public float SmallMinKG, SmallMaxKG;
    public float MedMinKG, MedMaxKG;
    public float LargeMinKG, LargeMaxKG;
    
    public float PhpPerKG;
    public float smallFishPerKG,medFishPerKG,largeFishPerKG;

    public int GGPieces, TilaPieces, LapuPieces;

    public int RodPieces, CastPieces, TrawlPieces;

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
    public int SSHours, ERHours, LIHours;

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

    public List<DataEvent> EventsList = new List<DataEvent>();
    public DataEvent ActiveEvent;

    public void ResetAllEvents()
    {
        foreach(DataEvent data in EventsList)
        {
            data.ResetDates();
            data.Completed = false;
        }
    }

    public void EventMinusDay()
    {
        if(ActiveEvent != null)
            ActiveEvent.DaysRemaining--;
    }

    public void RandomForecast()
    {
        float x = Random.Range(1, 100);
                   
        if(x >= 0 && x < 33)
        {
            Forecast = Weather.Sunny;
        }
        else if(x >= 33 && x < 66)
        {
            Forecast = Weather.Overcast;
        }
        else
        {
            Forecast = Weather.Rainy;
        }
    }

    public enum MarketPrices
    {
        Lower,
        Normal,
        Higher
    }
    public MarketPrices PricesToday;

    public float NewsmallFishPerKG, NewmedFishPerKG, NewlargeFishPerKG;

    public void MarketDecide()
    {
        NewsmallFishPerKG = smallFishPerKG;
        NewmedFishPerKG = medFishPerKG;
        NewlargeFishPerKG = largeFishPerKG;

        float x = Random.Range(1, 100);

        if (x >= 0 && x < 40)
        {
            PricesToday = MarketPrices.Normal;
        }
        else if (x >= 40 && x < 75)
        {
            PricesToday = MarketPrices.Lower;
        }
        else
        {
            PricesToday = MarketPrices.Higher;
        }
        float y = 0;
        switch (PricesToday)
        {            
            case MarketPrices.Normal:
                //unchanged
                break;

            case MarketPrices.Lower:
                y = Random.Range(1, 15);
                NewsmallFishPerKG -= y;
                NewmedFishPerKG -= y;
                NewlargeFishPerKG -= y;
                break;

            case MarketPrices.Higher:
                y = Random.Range(1, 15);
                NewsmallFishPerKG += y;
                NewmedFishPerKG += y;
                NewlargeFishPerKG += y;
                break;
        }

    }

    public enum MapTutorialStage
    {
        S1,
        S2,
        S3
    }

    public MapTutorialStage CurStage;
}
