using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingComputation : MonoBehaviour
{
    public ChooseGear CG;
    public Text FishcaughtSmall, FishcaughtMed, FishcaughtLarge;

    public Text NoFish;
    bool nofish;

    public Image NetStatus;
    float timeRatio;

    public Text CaughtFishTxt, BaitUsedTxt;
    bool caughtFish, baitUsed;   

    float fishCaught;
    float toAdd;

    float smallF, medF, largeF;

    float x;
    float y;
    float z;


    float catchResetTime, numOfFish;

    bool addedGlobal;

    public Text BaitChosen, BaitRemain;
    public GameObject RanOutBait;
    bool hasBait;

    // Start is called before the first frame update
    void Start()
    {
        fishCaught = 0;
        toAdd = 0;

        x = 0;
        y = 0;
        z = 0;

        AssignStats();

        smallF = 0;
        medF = 0;
        largeF = 0;
        nofish = false;
        NoFish.enabled = false;
        addedGlobal = false;


        caughtFish = false;
        baitUsed = false;
        CaughtFishTxt.enabled = false;
        BaitUsedTxt.enabled = false;

        RanOutBait.SetActive(false);
        hasBait = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (smallF > 0)
        {
            FishcaughtSmall.enabled = true;
        }
        else
        {
            FishcaughtSmall.enabled = false;
        }

        if (medF > 0)
        {
            FishcaughtMed.enabled = true;
        }
        else
        {
            FishcaughtMed.enabled = false;
        }

        if (largeF > 0)
        {
            FishcaughtLarge.enabled = true;
        }
        else
        {
            FishcaughtLarge.enabled = false;
        }

        FishcaughtSmall.text = smallF.ToString("F2") + " kg";
        FishcaughtMed.text = medF.ToString("F2") + " kg";
        FishcaughtLarge.text = largeF.ToString("F2") + " kg";

        if (IsFishing())
        {            
            Compute();            
        }

        if (nofish)
        {
            y += Time.deltaTime;
            NoFish.enabled = true;
        }

        if(y > 2f)
        {
            nofish = false;
            NoFish.enabled = false;
            y = 0;
        }       

        if (caughtFish)
        {
            y += Time.deltaTime;
            CaughtFishTxt.text = "You caught " + numOfFish.ToString() + " fish";
            CaughtFishTxt.enabled = true;
        }

        if(y > 2)
        {
            caughtFish = false;
            CaughtFishTxt.enabled = false;
            y = 0;
        }

        if(baitUsed)
        {
            z += Time.deltaTime;
            switch(GlobalStats.Instance.CurrentNet)
            {
                case GlobalStats.NetType.Rod:
                    BaitUsedTxt.text = "You used 1 bait";
                    break;

                case GlobalStats.NetType.Cast:
                    BaitUsedTxt.text = "You used 5 bait";
                    break;

                case GlobalStats.NetType.Trawling:
                    BaitUsedTxt.text = "You used 10 bait";
                    break;
            }
            BaitUsedTxt.enabled = true;
        }

        if(z > 2)
        {
            baitUsed = false;
            BaitUsedTxt.enabled = false;
            z = 0;
        }

        if(!hasBait)
        {
            RanOutBait.SetActive(true);
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

        BaitChosen.text = GlobalStats.Instance.CurrentBait.ToString();
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                BaitRemain.text = GlobalStats.Instance.BreadAmt.ToString();
                break;

            case GlobalStats.BaitType.Insects:
                BaitRemain.text = GlobalStats.Instance.InsectAmt.ToString();
                break;

            case GlobalStats.BaitType.Worms:
                BaitRemain.text = GlobalStats.Instance.WormAmt.ToString();
                break;
        }

    }    
    
    void AssignStats()
    {
        //todo change to net level
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

        //switch (GlobalStats.Instance.NetLevel)
        //{
        //    case 1:
        //        numOfFish = 1;
        //        break;

        //    case 2:
        //        numOfFish = 2;
        //        break;

        //    case 3:
        //        numOfFish = 4;
        //        break;
        //}
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
            Bait();
            CatchFish();
        }
    }

    void CatchFish()
    {        
        //switch(GlobalStats.Instance.SelectedLocation)
        //{
        //    case GlobalStats.FishingLocation.SandyShoals:
        //        switch(Random100())
        //        {
        //            case float x when (x >= 0 && x < 40):
        //                Debug.Log(x);
        //                NoCatch();
        //                break;

        //            case float x when (x < 75 && x >= 40):
        //                Debug.Log(x);
        //                CatchSmall();
        //                break;

        //            case float x when (x >= 75 && x < 95):
        //                Debug.Log(x);
        //                CatchMed();
        //                break;

        //            case float x when (x >= 95):
        //                Debug.Log(x);
        //                CatchLarge();
        //                break;
                    
        //        }
        //        break;

        //    case GlobalStats.FishingLocation.ExposedReef:
        //        switch (Random100())
        //        {
        //            case float x when (x >= 0 && x < 40):
        //                NoCatch();
        //                break;

        //            case float x when (x < 55 && x >= 40):
        //                CatchSmall();
        //                break;

        //            case float x when (x >= 55 && x < 95):
        //                CatchMed();
        //                break;

        //            case float x when (x >= 95):
        //                CatchLarge();
        //                break;
        //        }
        //        break;

        //    case GlobalStats.FishingLocation.LonelyIsland:
        //        switch (Random100())
        //        {
        //            case float x when (x >= 0 && x < 40):
        //                NoCatch();
        //                break;

        //            case float x when (x < 75 && x >= 40):
        //                CatchSmall();
        //                break;

        //            case float x when (x >= 75 && x < 85):
        //                CatchMed();
        //                break;

        //            case float x when (x >= 85):
        //                CatchLarge();
        //                break;
        //        }
        //        break;
        //}
        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Rod:
                numOfFish = 1;
                break;

            case GlobalStats.NetType.Cast:
                numOfFish = Random.Range(1, 5);
                break;

            case GlobalStats.NetType.Trawling:
                numOfFish = Random.Range(1, 10);
                break;
        }

        if(hasBait)
        {
            if (Random100() <= CG.GalunggongChances)
            {
                CatchSmall();
                return;
            }

            if (Random100() <= CG.TilapiaChances)
            {
                CatchMed();
                return;
            }

            if (Random100() <= CG.LapuChances)
            {
                CatchLarge();
                return;
            }
        }      

        NoCatch();
    }

    void Bait()
    {
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Rod:
                SubtractBait(1);
                break;
            case GlobalStats.NetType.Cast:
                SubtractBait(5);
                break;
            case GlobalStats.NetType.Trawling:
                SubtractBait(10);
                break;
        }
    }

    void SubtractBait(int i)
    {
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                GlobalStats.Instance.BreadAmt -= i;
                if(GlobalStats.Instance.BreadAmt < 0)
                {
                    GlobalStats.Instance.BreadAmt = 0;
                    hasBait = false;
                }
                break;

            case GlobalStats.BaitType.Insects:
                GlobalStats.Instance.InsectAmt -= i;
                if (GlobalStats.Instance.InsectAmt < 0)
                {
                    GlobalStats.Instance.InsectAmt = 0;
                    hasBait = false;
                }
                break;

            case GlobalStats.BaitType.Worms:
                GlobalStats.Instance.WormAmt -= i;
                if (GlobalStats.Instance.WormAmt < 0)
                {
                    GlobalStats.Instance.WormAmt = 0;
                    hasBait = false;
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
        smallF += (fx * numOfFish);
        caughtFish = true;
        Debug.Log("Small");
    }

    void CatchMed()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.MedMinKG,
                            GlobalStats.Instance.MedMaxKG);
        medF += (fx * numOfFish);
        caughtFish = true;
        Debug.Log("Med");
    }

    void CatchLarge()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.LargeMinKG,
                            GlobalStats.Instance.LargeMaxKG);
        largeF += (fx * numOfFish);
        caughtFish = true;
        Debug.Log("LARGE");
    }

    void NoCatch()
    {
        nofish = true;
        Debug.Log("No fish");
    }

    float Random100()
    {
        return Random.Range(0, 100);
    }
}
