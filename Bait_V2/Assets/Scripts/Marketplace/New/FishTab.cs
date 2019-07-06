﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishTab : MonoBehaviour
{
    public Text GalungPerKG, TilaPerKg, LapuPerKG;

    public Text PlayerGalungKG, PlayerTilaPerKG, PlayerLapuPerKG;

    public Text PlayerGalungKGChoose, 
        PlayerTilaPerKGChoose, 
        PlayerLapuPerKGChoose;

    float PGalung, PTilapia, PLapu;

    public Text Earnings;
    float totalearning;

    public Image GGprice, Tilaprice, Lapuprice;
    public Sprite UpPrice, DownPrice;

    // Start is called before the first frame update
    void Start()
    {
        PGalung = 0;
        PTilapia = 0;
        PLapu = 0;

        GalungPerKG.text = GlobalStats.Instance.NewsmallFishPerKG.ToString() + "/KG";
        TilaPerKg.text = GlobalStats.Instance.NewmedFishPerKG.ToString() + "/KG";
        LapuPerKG.text = GlobalStats.Instance.NewlargeFishPerKG.ToString() + "/KG";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHaul();
        CheckOwnSelling();
        Compute();

        switch(GlobalStats.Instance.PricesToday)
        {
            case GlobalStats.MarketPrices.Higher:
                GGprice.enabled = true;
                Tilaprice.enabled = true;
                Lapuprice.enabled = true;

                GGprice.sprite = UpPrice;
                Tilaprice.sprite = UpPrice;
                Lapuprice.sprite = UpPrice;
                break;

            case GlobalStats.MarketPrices.Lower:
                GGprice.enabled = true;
                Tilaprice.enabled = true;
                Lapuprice.enabled = true;

                GGprice.sprite = DownPrice;
                Tilaprice.sprite = DownPrice;
                Lapuprice.sprite = DownPrice;
                break;

            case GlobalStats.MarketPrices.Normal:
                GGprice.enabled = false;
                Tilaprice.enabled = false;
                Lapuprice.enabled = false;
                break;
        }
    }

    void PlayerHaul()
    {
        PlayerGalungKG.text = GlobalStats.Instance.smallKG.ToString("F2") + " kgs";
        PlayerTilaPerKG.text = GlobalStats.Instance.medKG.ToString("F2") + " kgs";
        PlayerLapuPerKG.text = GlobalStats.Instance.largeKG.ToString("F2") + " kgs";
    }

    void Compute()
    {
        float x;
        float y;
        float z;

        x = PGalung * GlobalStats.Instance.NewsmallFishPerKG;
        y = PTilapia * GlobalStats.Instance.NewmedFishPerKG;
        z = PLapu * GlobalStats.Instance.NewlargeFishPerKG;

        totalearning = x + y + z;
        Earnings.text = totalearning.ToString("F2");
    }

    public void Sell()
    {
        GlobalStats.Instance.smallKG -= PGalung;
        GlobalStats.Instance.medKG -= PTilapia;
        GlobalStats.Instance.largeKG -= PLapu;

        GlobalStats.Instance.PlayerSavings += totalearning;
        GlobalStats.Instance.PerDayEarning += totalearning;
        GlobalStats.Instance.TotalMoneyEarned += totalearning;
    }

    void CheckOwnSelling()
    {
        if(GlobalStats.Instance.smallKG > 0)
        {
            PlayerGalungKGChoose.gameObject.SetActive(true);
            PlayerGalungKGChoose.text = PGalung.ToString() + "/Kg";
        }
        else
        {
            PlayerGalungKGChoose.gameObject.SetActive(false);
            PGalung = 0;
        }

        if(GlobalStats.Instance.medKG > 0)
        {
            PlayerTilaPerKGChoose.gameObject.SetActive(true);
            PlayerTilaPerKGChoose.text = PTilapia.ToString() + "/Kg"; ;
        }
        else
        {
            PlayerTilaPerKGChoose.gameObject.SetActive(false);
            PTilapia = 0;
        }

        if (GlobalStats.Instance.largeKG > 0)
        {
            PlayerLapuPerKGChoose.gameObject.SetActive(true);
            PlayerLapuPerKGChoose.text = PLapu.ToString() + "/Kg"; ;
        }
        else
        {
            PlayerLapuPerKGChoose.gameObject.SetActive(false);
            PLapu = 0;
        }
        
        if (PGalung > GlobalStats.Instance.smallKG)
        {
            PGalung = GlobalStats.Instance.smallKG;
        }
       
    }

    public void IncreaseGG()
    {
        if(PGalung >= GlobalStats.Instance.smallKG)
        {
            PGalung = GlobalStats.Instance.smallKG;
        }
        else
        {
            PGalung += .5f;
        }
    }

    public void DecreaseGG()
    {
        if(PGalung <= 0)
        {
            PGalung = 0;
        }
        else
        {
            PGalung -= .5f;
        }
    }

    public void IncreaseTila()
    {
        if (PTilapia >= GlobalStats.Instance.medKG)
        {
            PTilapia = GlobalStats.Instance.medKG;
        }
        else
        {
            PTilapia += .5f;
        }
    }

    public void DecreaseTila()
    {
        if (PTilapia <= 0)
        {
            PTilapia = 0;
        }
        else
        {
            PTilapia -= .5f;
        }
    }

    public void IncreaseLL()
    {
        if (PLapu >= GlobalStats.Instance.largeKG)
        {
            PLapu = GlobalStats.Instance.largeKG;
        }
        else
        {
            PLapu += .5f;
        }
    }   

    public void DecreaseLL()
    {
        if (PLapu <= 0)
        {
            PLapu = 0;
        }
        else
        {
            PLapu -= .5f;
        }
    }
}