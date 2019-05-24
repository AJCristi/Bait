using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketMenu : MonoBehaviour
{
    public Text Savings, FishKG;
    public Text ConversionRate,FishEarnings;

    public Text BoatSpeedLvlText;
    public Text BoatSpeedCostText;
    public GameObject SpeedObj;

    public float BoatSpdLv2Cost, BoatSpdLv3Cost;

    public Text NetLvlText;
    public Text NetCostText;
    public GameObject NetObj;

    public float NetLv2Cost, NetLv3Cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerStats();
        ShowConversion();
        BoatUpgrades();
    }

    void UpdatePlayerStats()
    {
        Savings.text = "PHP: " + GlobalStats.Instance.PlayerSavings.ToString();
        FishKG.text = "Kg's of fish: " + GlobalStats.Instance.FishKG.ToString();
    }

    void ShowConversion()
    {
        ConversionRate.text = "PHP/KG: " + GlobalStats.Instance.PhpPerKG.ToString();
        FishEarnings.text = "You will earn " + CalculateEarnings().ToString();
    }

    public void SellFish()
    {
        if(GlobalStats.Instance.FishKG > 0)
        {
            GlobalStats.Instance.PlayerSavings += CalculateEarnings();
            GlobalStats.Instance.FishKG = 0;
        }
    }

    float CalculateEarnings()
    {
        return GlobalStats.Instance.PhpPerKG * GlobalStats.Instance.FishKG;
    }

    void BoatUpgrades()
    {
        BoatSpeedLvlText.text = "Current Level " + GlobalStats.Instance.BoatSpdLvl.ToString();
        if(GlobalStats.Instance.BoatSpdLvl == 1)
        {
            BoatSpeedCostText.text = "PHP: " + BoatSpdLv2Cost.ToString();
        }

        else if (GlobalStats.Instance.BoatSpdLvl == 2)
        {
            BoatSpeedCostText.text = "PHP: " + BoatSpdLv3Cost.ToString();
        }
        else
        {
            BoatSpeedCostText.text = " xd";
            SpeedObj.SetActive(false);
        }

        NetLvlText.text = "Net Level " + GlobalStats.Instance.NetLevel.ToString();
        if (GlobalStats.Instance.NetLevel == 1)
        {
            NetCostText.text = "PHP: " + NetLv2Cost.ToString();
        }

        else if (GlobalStats.Instance.NetLevel == 2)
        {
            NetCostText.text = "PHP: " + NetLv3Cost.ToString();
        }
        else
        {
            NetCostText.text = " xd";
            NetObj.SetActive(false);
        }
    }

    public void UpgradeSpeed()
    {
        switch(GlobalStats.Instance.BoatSpdLvl)
        {
            case 1:
                if(GlobalStats.Instance.PlayerSavings >= BoatSpdLv2Cost)
                {
                    GlobalStats.Instance.BoatSpdLvl++;
                    GlobalStats.Instance.PlayerSavings -= BoatSpdLv2Cost;
                }
                break;

            case 2:
                if (GlobalStats.Instance.PlayerSavings >= BoatSpdLv3Cost)
                {
                    GlobalStats.Instance.BoatSpdLvl++;
                    GlobalStats.Instance.PlayerSavings -= BoatSpdLv3Cost;
                }
                break;

        }
    }

    public void UpgradeNet()
    {
        switch (GlobalStats.Instance.NetLevel)
        {
            case 1:
                if (GlobalStats.Instance.PlayerSavings >= NetLv2Cost)
                {
                    GlobalStats.Instance.NetLevel++;
                    GlobalStats.Instance.PlayerSavings -= NetLv2Cost;
                }
                break;

            case 2:
                if (GlobalStats.Instance.PlayerSavings >= NetLv3Cost)
                {
                    GlobalStats.Instance.NetLevel++;
                    GlobalStats.Instance.PlayerSavings -= NetLv3Cost;
                }
                break;

        }
    }
}
