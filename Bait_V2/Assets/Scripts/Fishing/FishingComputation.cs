﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingComputation : MonoBehaviour
{
    public Text FishcaughtSmall, FishcaughtMed, FishcaughtLarge;

    public Image NetStatus;
    float timeRatio;

    float fishCaught;
    float toAdd;

    float smallF, medF, largeF;

    float x;

    float catchResetTime, numOfFish;

    bool addedGlobal;

    // Start is called before the first frame update
    void Start()
    {
        fishCaught = 0;
        toAdd = 0;
        x = 0;
        AssignStats();

        smallF = 0;
        medF = 0;
        largeF = 0;

        addedGlobal = false;
    }

    // Update is called once per frame
    void Update()
    {
        FishcaughtSmall.text = smallF.ToString("00") + " kg";
        FishcaughtMed.text = medF.ToString("00") + " kg";
        FishcaughtLarge.text = largeF.ToString("00") + " kg";

        if (IsFishing())
        {            
            Compute();
        }

        if(GetComponent<FishingScene>().curStatus == FishingScene.FishingStatus.Done)
        {
            if(!addedGlobal)
            {
                //GlobalStats.Instance.FishKG += fishCaught;
                GlobalStats.Instance.smallKG += smallF;
                GlobalStats.Instance.medKG += medF;
                GlobalStats.Instance.largeKG += largeF;
                addedGlobal = true;
            }
            
        }

    }    
    
    void AssignStats()
    {
        switch(GlobalStats.Instance.BaitLevel)
        {
            case 1:
                catchResetTime = 8;
                break;

            case 2:
                catchResetTime = 6;
                break;

            case 3:
                catchResetTime = 3;
                break;
        }

        switch (GlobalStats.Instance.NetLevel)
        {
            case 1:
                numOfFish = 1;
                break;

            case 2:
                numOfFish = 2;
                break;

            case 3:
                numOfFish = 4;
                break;
        }
    }

    bool IsFishing()
    {
        if(GetComponent<FishingScene>().curStatus == FishingScene.FishingStatus.Fishing)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Compute()
    {         
        if(x <= catchResetTime)
        {
            x += Time.deltaTime;
            timeRatio = x / catchResetTime;
            NetStatus.fillAmount = timeRatio;
        }
        else
        {
            x = 0;
            CatchFish();
        }
    }

    void CatchFish()
    {
        //float f = 0;
        //switch(GlobalStats.Instance.SelectedLocation)
        //{
        //    case GlobalStats.FishingLocation.SandyShoals:
        //        f = .9f;
        //        break;

        //    case GlobalStats.FishingLocation.ExposedReef:
        //        f = 1.1f;
        //        break;

        //    case GlobalStats.FishingLocation.LonelyIsland:
        //        f = 1.5f;
        //        break;
        //}
        ////todo add weather

        //toAdd = f * numOfFish;
        //fishCaught += toAdd;  
        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.SandyShoals:
                switch(TypeofFish())
                {
                    case float x when (x < 75 && x >= 0):
                        CatchSmall();
                        break;

                    case float x when (x >= 75 && x < 95):
                        CatchMed();
                        break;

                    case float x when (x >= 95):
                        CatchLarge();
                        break;
                }
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                switch (TypeofFish())
                {
                    case float x when (x < 55 && x >= 0):
                        CatchSmall();
                        break;

                    case float x when (x >= 55 && x < 95):
                        CatchMed();
                        break;

                    case float x when (x >= 95):
                        CatchLarge();
                        break;
                }
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                switch (TypeofFish())
                {
                    case float x when (x < 75 && x >= 0):
                        CatchSmall();
                        break;

                    case float x when (x >= 75 && x < 85):
                        CatchMed();
                        break;

                    case float x when (x >= 85):
                        CatchLarge();
                        break;
                }
                break;
        }

    }

    float WeatherEffect()
    {
        float x = 0;

        switch(GlobalStats.Instance.Forecast)
        {
            case GlobalStats.Weather.Sunny:
                x = 1f;
                break;

            case GlobalStats.Weather.Overcast:
                x = 1.5f;
                break;

            case GlobalStats.Weather.Rainy:
                x = .8f;
                break;
        }

        return x;
    }

    void CatchSmall()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.SmallMinKG,
                            GlobalStats.Instance.SmallMaxKG);
        smallF += (fx * numOfFish) * WeatherEffect();
        Debug.Log("Small");
    }

    void CatchMed()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.MedMinKG,
                            GlobalStats.Instance.MedMaxKG);
        medF += (fx * numOfFish) * WeatherEffect();
        Debug.Log("Med");
    }

    void CatchLarge()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.LargeMinKG,
                            GlobalStats.Instance.LargeMaxKG);
        largeF += (fx * numOfFish) * WeatherEffect();
        Debug.Log("LARGE");
    }

    float TypeofFish()
    {
        return Random.Range(0, 100);
    }
}
