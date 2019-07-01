using System.Collections;
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
    bool FF;

    public Button Done;

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

        Done.interactable = false;
        catchResetTime = 0;
        SetCatchResetTime();
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
                        catchResetTime = 8;
                        break;

                    case 2:
                        catchResetTime = 7.5f;
                        break;

                    case 3:
                        catchResetTime = 7;
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
                        catchResetTime = 5;
                        break;

                    case 2:
                        catchResetTime = 4.5f;
                        break;

                    case 3:
                        catchResetTime = 3;
                        break;

                    case 4:
                        catchResetTime = 2;
                        break;

                    case 5:
                        catchResetTime = 1;
                        break;
                }
                break;

            case GlobalStats.NetType.Trawling:
                switch (GlobalStats.Instance.TrawlingNetLevel)
                {
                    case 1:
                        catchResetTime = 10;
                        break;

                    case 2:
                        catchResetTime = 8;
                        break;

                    case 3:
                        catchResetTime = 7;
                        break;

                    case 4:
                        catchResetTime = 6;
                        break;

                    case 5:
                        catchResetTime = 4;
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
            Done.interactable = true;

            if (!addedGlobal)
            {
                //GlobalStats.Instance.FishKG += fishCaught;
                GlobalStats.Instance.smallKG += galunggongAmt;
                GlobalStats.Instance.medKG += tilapiaAmt;
                GlobalStats.Instance.largeKG += lapu2Amt;
                addedGlobal = true;
            }
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
            NoFish.enabled = true;
            NoFish.text = "Ran out of Bait";
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
            Bait();
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
                return;
            }

            if (Random100() <= P.TilapiaChances)
            {
                CatchTilapia();
                return;
            }

            if (Random100() <= P.LapuChances)
            {
                CatchLL();
                return;
            }
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
        Debug.Log("GG");
        GlobalStats.Instance.GGPieces += numOfFish;

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
        Debug.Log("Med");
        GlobalStats.Instance.TilaPieces += numOfFish;

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
        Debug.Log("LARGE");
        GlobalStats.Instance.LapuPieces += numOfFish;


        SubtractGear();
        gameObject.GetComponent<Notifs>().ActivateFish(3, numOfFish);
    }

    void NoCatch()
    {

        nofish = true;
        Debug.Log("No fish");
        gameObject.GetComponent<Notifs>().NoCatch();
    }

    float Random100()
    {
        return Random.Range(0, 100);
    }

    public void DoneFishing()
    {
        SceneManager.LoadScene("1_MapSelector");
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

            switch(GlobalStats.Instance.CurrentNet)
            {
                case GlobalStats.NetType.Rod:
                    GlobalStats.Instance.RodPieces--;
                    if (GlobalStats.Instance.RodPieces < 0)
                    {
                        GlobalStats.Instance.RodPieces = 0;
                    }
                    break;

                case GlobalStats.NetType.Cast:
                    GlobalStats.Instance.CastPieces--;
                    if (GlobalStats.Instance.CastPieces < 0)
                    {
                        GlobalStats.Instance.CastPieces = 0;
                    }
                    break;

                case GlobalStats.NetType.Trawling:
                    GlobalStats.Instance.TrawlPieces--;
                    if (GlobalStats.Instance.TrawlPieces < 0)
                    {
                        GlobalStats.Instance.TrawlPieces = 0;
                    }
                    break;
            }
        }
    }

}
