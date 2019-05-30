﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float Month, Day;

    public float PlayerSavings;

    public float FishKG;
    public float smallKG, medKG, largeKG;
    
    public float PhpPerKG;
    public float smallFishPerKG,medFishPerKG,largeFishPerKG;

    public enum FoodItems
    {
        Chicken, 
        Beef,
        Vegetables,
        Pork,
        None
    }
    public float ChickenHap, ChickenHung;
    public float BeefHap, BeefHung;
    public float VegetablesHap, VegetablesHung;
    public float PorkHap, PorkHung;

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

}
