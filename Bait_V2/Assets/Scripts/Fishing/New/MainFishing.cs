﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainFishing : MonoBehaviour
{
    public Predictions P;

    public bool Started;

    public Text TimerTxt;
    public Image TimerImage;

    public float TimeLeft;
    float timeRatio, timeRemaining;

    public Text CaughtFishTxt, BaitUsedTxt;
    bool caughtFish, baitUsed;

    string minutes;
    string seconds;

    float x;
    float y;
    float z;
    float zz;
    bool FF;

    //public Button Done;
    public GameObject DoneNotif; 

    public Text FishcaughtGG, FishcaughtTila, FishcaughtLL;

    float catchResetTime;
    int numOfFish;

    public Text NoFish;
    bool nofish;
    bool hasBait;

    bool addedGlobal;

    float galunggongAmt, tilapiaAmt, lapu2Amt;

    public Text CurNet, CurBait;

    public Text FFtext;

    public bool hasGear;

    public AudioClip CaughtFish, NoFishSFX, Broken, Done;

    public GameObject RanOutBait, RanOutGear;

    // Start is called before the first frame update
    void Start()
    {
        Started = false;
        addedGlobal = false;
        timeRemaining = TimeLeft;
        FF = false;
        x = 0;
        y = 0;
        z = 0;

        zz = 0;

        caughtFish = false;
        baitUsed = false;

        galunggongAmt = 0;
        tilapiaAmt = 0;
        lapu2Amt = 0;

        nofish = false;
        NoFish.enabled = false;

        hasGear = true;

        hasBait = true;
        CaughtFishTxt.enabled = false;
        BaitUsedTxt.enabled = false;

        DoneNotif.SetActive(false);
        catchResetTime = 0;

        RanOutBait.SetActive(false);
        RanOutGear.SetActive(false);


    }

    public void FastForward()
    {
        FF = !FF;
    }

    void SetCatchResetTime()
    {        
        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                switch(GlobalStats.Instance.CastNetLevel)
                {
                    case 1:
                        catchResetTime = 11;
                        break;

                    case 2:
                        catchResetTime = 10f;
                        break;

                    case 3:
                        catchResetTime = 8;
                        break;

                    case 4:
                        catchResetTime = 6.5f;
                        break;

                    case 5:
                        catchResetTime = 5;
                        break;
                }
                break;

            case GlobalStats.NetType.Rod:
                switch (GlobalStats.Instance.RodNetLevel)
                {
                    case 1:
                        catchResetTime = 15;
                        break;

                    case 2:
                        catchResetTime = 13f;
                        break;

                    case 3:
                        catchResetTime = 11;
                        break;

                    case 4:
                        catchResetTime = 9;
                        break;

                    case 5:
                        catchResetTime = 6;
                        break;
                }
                break;

            case GlobalStats.NetType.Trawling:
                switch (GlobalStats.Instance.TrawlingNetLevel)
                {
                    case 1:
                        catchResetTime = 20;                        
                        break;

                    case 2:
                        catchResetTime = 18;
                        break;

                    case 3:
                        catchResetTime = 15;
                        break;

                    case 4:
                        catchResetTime = 13;
                        break;

                    case 5:
                        catchResetTime = 10;
                        break;
                }
                break;
        }
    }

    void SetCurrentTimeUI()
    {
        timeRemaining -= Time.deltaTime;
        minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
        seconds = (timeRemaining % 60).ToString("00");
        TimerTxt.text = minutes.ToString() + ":" + seconds.ToString();
    }

    void UpdateCurGear()
    {
        
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                CurNet.text = GlobalStats.Instance.CastPieces.ToString() + " pieces";
                break;

            case GlobalStats.NetType.Rod:
                CurNet.text = GlobalStats.Instance.RodPieces.ToString() + " pieces"; ;
                break;

            case GlobalStats.NetType.Trawling:
                CurNet.text = GlobalStats.Instance.TrawlPieces.ToString() + " pieces"; ;
                break;
        }


        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                CurBait.text = GlobalStats.Instance.CurrentBait.ToString()
                    + " -- " + GlobalStats.Instance.BreadAmt.ToString();
                break;

            case GlobalStats.BaitType.Insects:
                CurBait.text = GlobalStats.Instance.CurrentBait.ToString()
                    + " -- " + GlobalStats.Instance.InsectAmt.ToString();
                break;

            case GlobalStats.BaitType.Worms:
                CurBait.text = GlobalStats.Instance.CurrentBait.ToString()
                    + " -- " + GlobalStats.Instance.WormAmt.ToString();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FF)
        {
            FFtext.text = "10x";
        }
        else
        {
            FFtext.text = "1x";
        }

        FishUI();
        UpdateCurGear();
        CheckGear();

        if (Started)
        {
            SetCatchResetTime();
            StartFishing();

            if (FF)
            {
                Time.timeScale = 10;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        else
        {
            TimerTxt.text = "0:00";
            Time.timeScale = 1;
            DoneNotif.SetActive(true);

            if (!addedGlobal)
            {
                //GlobalStats.Instance.FishKG += fishCaught;
                GlobalStats.Instance.smallKG += galunggongAmt;
                GlobalStats.Instance.medKG += tilapiaAmt;
                GlobalStats.Instance.largeKG += lapu2Amt;
                GetComponent<EndNotif>().TotalKGAdd(galunggongAmt, tilapiaAmt, lapu2Amt);
                SFXcontroller.instance.PlaySingle(Done);
                addedGlobal = true;
            }
        }

        if(GetComponent<GraphicChanger>().CurrentFState != GraphicChanger.FishingState.Default)
        {
            zz += Time.deltaTime;
        }

        else
        {
            zz = 0;
            GetComponent<GraphicChanger>().Default();
        }

        if(zz > 2f)
        {
            Debug.Log("Default");
            GetComponent<GraphicChanger>().Default();
        }


        if (nofish)
        {
            y += Time.deltaTime;
            NoFish.enabled = true;
            NoFish.text = "No caught fish";
        }

        if (y > 2f)
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

        if (y > 2)
        {
            caughtFish = false;
            CaughtFishTxt.enabled = false;
            
            y = 0;
        }

        if (baitUsed)
        {
            z += Time.deltaTime;
            switch (GlobalStats.Instance.CurrentNet)
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

        if (z > 2)
        {
            baitUsed = false;
            BaitUsedTxt.enabled = false;
            z = 0;
        }

        if (!hasBait)
        {
            //NoFish.enabled = true;
            //NoFish.text = "Ran out of Bait";
            RanOutBait.SetActive(true);
        }

        if(!hasGear)
        {
            RanOutGear.SetActive(true);
        }

    }

    void StartFishing()
    {
        timeRatio = timeRemaining / TimeLeft;
        TimerImage.fillAmount = timeRatio;

        SetCurrentTimeUI();
        Debug.Log(catchResetTime);
        Compute();

        if (timeRemaining <= 0)
        {
            Started = false;
        }

    }

    void Compute()
    {
        if (x <= catchResetTime)
        {
            x += Time.deltaTime;
            timeRatio = x / catchResetTime;            
            //add 
        }
        else
        {
            x = 0;
            Debug.Log("compute");
            
            CatchFish();
        }
    }

    void FishUI()
    {
        if(galunggongAmt > 0)
        {
            FishcaughtGG.enabled = true;
            FishcaughtGG.text = galunggongAmt.ToString("F2") + " kg";
        }
        else
        {
            FishcaughtGG.enabled = false;
        }

        if (tilapiaAmt > 0)
        {
            FishcaughtTila.enabled = true;
            FishcaughtTila.text = tilapiaAmt.ToString("F2") + " kg";
        }
        else
        {
            FishcaughtTila.enabled = false;
        }

        if (lapu2Amt > 0)
        {
            FishcaughtLL.enabled = true;
            FishcaughtLL.text = lapu2Amt.ToString("F2") + " kg";
        }
        else
        {
            FishcaughtLL.enabled = false;
        }       

    }

    void Bait()
    {
        
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Rod:
                SubtractBait(1);
                GetComponent<EndNotif>().AddBait(1);
                break;
            case GlobalStats.NetType.Cast:
                SubtractBait(5);
                GetComponent<EndNotif>().AddBait(5);
                break;
            case GlobalStats.NetType.Trawling:
                SubtractBait(10);
                GetComponent<EndNotif>().AddBait(10);
                break;
        }
    }

    void SubtractBait(int i)
    {
        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                GlobalStats.Instance.BreadAmt -= i;
                if (GlobalStats.Instance.BreadAmt < 0)
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

    void CatchFish()
    {

        switch (GlobalStats.Instance.CurrentNet)
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

        if (hasBait && hasGear)
        {
            gameObject.GetComponent<Notifs>().ActivateBait();
            if (Random100() <= P.GalunggongChances)
            {
                CatchGG();
                Bait();
                return;
            }

            if (Random100() <= P.TilapiaChances)
            {
                CatchTilapia();
                Bait();
                return;
            }

            if (Random100() <= P.LapuChances)
            {
                CatchLL();
                Bait();
                return;
            }

            else
            {
                NoCatch();
            }
            Bait();

        }
        else
        {
            NoCatch();
        }

        
    }

    void CatchGG()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.SmallMinKG,
                            GlobalStats.Instance.SmallMaxKG);
        galunggongAmt += (fx * numOfFish);
        GlobalStats.Instance.TotalFishCaught += galunggongAmt;
        caughtFish = true;        
        GlobalStats.Instance.GGPieces += numOfFish;

        Debug.Log("CaughtGraphic");
        GetComponent<GraphicChanger>().Caught();
        SFXcontroller.instance.PlaySingle(CaughtFish);
        SubtractGear();
        gameObject.GetComponent<Notifs>().ActivateFish(1, numOfFish);
    }

    void CatchTilapia()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.MedMinKG,
                            GlobalStats.Instance.MedMaxKG);
        tilapiaAmt += (fx * numOfFish);
        GlobalStats.Instance.TotalFishCaught += tilapiaAmt;
        caughtFish = true;        
        GlobalStats.Instance.TilaPieces += numOfFish;

        Debug.Log("CaughtGraphic");
        GetComponent<GraphicChanger>().Caught();
        SFXcontroller.instance.PlaySingle(CaughtFish);
        SubtractGear();
        gameObject.GetComponent<Notifs>().ActivateFish(2, numOfFish);
    }

    void CatchLL()
    {
        float fx = 0;
        fx = Random.Range(GlobalStats.Instance.LargeMinKG,
                            GlobalStats.Instance.LargeMaxKG);
        lapu2Amt += (fx * numOfFish);
        GlobalStats.Instance.TotalFishCaught += lapu2Amt;
        caughtFish = true;        
        GlobalStats.Instance.LapuPieces += numOfFish;

        Debug.Log("CaughtGraphic");
        GetComponent<GraphicChanger>().Caught();
        SFXcontroller.instance.PlaySingle(CaughtFish);
        SubtractGear();
        gameObject.GetComponent<Notifs>().ActivateFish(3, numOfFish);
    }

    void NoCatch()
    {
        GetComponent<GraphicChanger>().None();
        nofish = true;
        SFXcontroller.instance.PlaySingle(NoFishSFX);
        Debug.Log("NoneGraphic");
        gameObject.GetComponent<Notifs>().NoCatch();
    }

    float Random100()
    {
        return Random.Range(0, 100);
    }

    public void DoneFishing()
    {
        SFXcontroller.instance.PlaySingle(Done);
        LoadingScreen.Instance.LoadScene("1_MapSelector");
        //ceneManager.LoadScene("1_MapSelector");
    }

    void CheckGear()
    {    
        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Rod:
                if(GlobalStats.Instance.RodPieces > 0)
                {
                    hasGear = true;
                }
                else
                {
                    hasGear = false;                    
                }
                break;

            case GlobalStats.NetType.Cast:
                if (GlobalStats.Instance.CastPieces > 0)
                {
                    hasGear = true;
                }
                else
                {
                    hasGear = false;
                }
                break;

            case GlobalStats.NetType.Trawling:
                if (GlobalStats.Instance.TrawlPieces > 0)
                {
                    hasGear = true;
                }
                else
                {
                    hasGear = false;
                }
                break;
        }
    }

    

    void SubtractGear()
    {
        if(Random100() < 10)
        {
            gameObject.GetComponent<Notifs>().ActivateGear();
            SFXcontroller.instance.PlaySingle(Broken);
            switch (GlobalStats.Instance.CurrentNet)
            {
                case GlobalStats.NetType.Rod:
                    GlobalStats.Instance.RodPieces--;
                    GetComponent<EndNotif>().LostGear(1);
                    if (GlobalStats.Instance.RodPieces < 0)
                    {
                        GlobalStats.Instance.RodPieces = 0;
                    }
                    break;

                case GlobalStats.NetType.Cast:
                    GlobalStats.Instance.CastPieces--;
                    GetComponent<EndNotif>().LostGear(1);
                    if (GlobalStats.Instance.CastPieces < 0)
                    {
                        GlobalStats.Instance.CastPieces = 0;
                    }
                    break;

                case GlobalStats.NetType.Trawling:
                    GlobalStats.Instance.TrawlPieces--;
                    GetComponent<EndNotif>().LostGear(1);
                    if (GlobalStats.Instance.TrawlPieces < 0)
                    {
                        GlobalStats.Instance.TrawlPieces = 0;
                    }
                    break;
            }
        }
    }

}

