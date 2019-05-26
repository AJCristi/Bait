using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingComputation : MonoBehaviour
{
    public Text FishCaughtDisplay;

    public Image NetStatus;
    float timeRatio;

    float fishCaught;
    float toAdd;

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

        addedGlobal = false;
    }

    // Update is called once per frame
    void Update()
    {
        FishCaughtDisplay.text = "Fish caught : " + fishCaught;

        if (IsFishing())
        {            
            Compute();
        }

        if(GetComponent<FishingScene>().curStatus == FishingScene.FishingStatus.Done)
        {
            if(!addedGlobal)
            {
                GlobalStats.Instance.FishKG += fishCaught;
                addedGlobal = true;
            }
            
        }

    }    
    
    void AssignStats()
    {
        switch(GlobalStats.Instance.BaitLevel)
        {
            case 1:
                catchResetTime = 10;
                break;

            case 2:
                catchResetTime = 7;
                break;

            case 3:
                catchResetTime = 5;
                break;
        }

        switch (GlobalStats.Instance.NetLevel)
        {
            case 1:
                numOfFish = 3;
                break;

            case 2:
                numOfFish = 6;
                break;

            case 3:
                numOfFish = 8;
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
        float f = 0;
        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.SandyShoals:
                f = .9f;
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                f = 1.1f;
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                f = 1.5f;
                break;
        }
        //todo add weather

        toAdd = f * numOfFish;
        fishCaught += toAdd;
    }
}
