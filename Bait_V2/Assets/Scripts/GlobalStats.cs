using System.Collections;
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

    public float PlayerSavings;
    public float FishKG;

    public float PhpPerKG;

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

    [Range(1, 3)]
    public int BoatSpdLvl;
    //decrease travel time

    [Range(1, 3)]
    public int NetLevel;
    //increase # of fish per catch

    [Range(1, 3)]
    public int BaitLevel;
    //increase catch per second

    public enum Weather
    {
        Sunny,
        Overcast,
        Weather 
    }

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

}
