using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketMenu : MonoBehaviour
{
    public Text Savings;    

    public Text BoatSpeedLvlText;
    public Text BoatSpeedCostText;
    public GameObject SpeedObj;

    public float BoatSpdLv2Cost, BoatSpdLv3Cost;

    public Text BoatFuelLvlText;
    public Text BoatFuelCostText;
    public GameObject FuelObj;

    public float BoatFuelLv2Cost, BoatFuelLv3Cost;

    public Text NetLvlText;
    public Text NetCostText;
    public GameObject NetObj;

    public float NetLv2Cost, NetLv3Cost;

    public Text BaitLvlText;
    public Text BaitCostText;
    public GameObject BaitObj;

    public float BaitLv2Cost, BaitLv3Cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerStats();
        
        BoatUpgrades();
    }

    void UpdatePlayerStats()
    {
        Savings.text = "PHP: " + GlobalStats.Instance.PlayerSavings.ToString();
        
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

        BoatFuelLvlText.text = "Current Level " + GlobalStats.Instance.FuelTankLevel.ToString();
        if (GlobalStats.Instance.FuelTankLevel == 1)
        {
            BoatFuelCostText.text = "PHP: " + BoatFuelLv2Cost.ToString();
        }

        else if (GlobalStats.Instance.FuelTankLevel == 2)
        {
            BoatFuelCostText.text = "PHP: " + BoatFuelLv3Cost.ToString();
        }
        else
        {
            BoatFuelCostText.text = " xd";
            FuelObj.SetActive(false);
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

        BaitLvlText.text = "Bait Level " + GlobalStats.Instance.BaitLevel.ToString();
        if (GlobalStats.Instance.BaitLevel == 1)
        {
            BaitCostText.text = "PHP: " + BaitLv2Cost.ToString();
        }

        else if (GlobalStats.Instance.BaitLevel == 2)
        {
            BaitCostText.text = "PHP: " + BaitLv3Cost.ToString();
        }
        else
        {
            BaitCostText.text = " xd";
            BaitObj.SetActive(false);
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

    public void UpgradeFuel()
    {
        switch (GlobalStats.Instance.FuelTankLevel)
        {
            case 1:
                if (GlobalStats.Instance.PlayerSavings >= BoatFuelLv2Cost)
                {
                    GlobalStats.Instance.FuelTankLevel++;
                    GlobalStats.Instance.PlayerSavings -= BoatFuelLv2Cost;
                }
                break;

            case 2:
                if (GlobalStats.Instance.PlayerSavings >= BoatFuelLv3Cost)
                {
                    GlobalStats.Instance.FuelTankLevel++;
                    GlobalStats.Instance.PlayerSavings -= BoatFuelLv3Cost;
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

    public void UpgradeBait()
    {
        switch (GlobalStats.Instance.BaitLevel)
        {
            case 1:
                if (GlobalStats.Instance.PlayerSavings >= BaitLv2Cost)
                {
                    GlobalStats.Instance.BaitLevel++;
                    GlobalStats.Instance.PlayerSavings -= BaitLv2Cost;
                }
                break;

            case 2:
                if (GlobalStats.Instance.PlayerSavings >= BaitLv3Cost)
                {
                    GlobalStats.Instance.BaitLevel++;
                    GlobalStats.Instance.PlayerSavings -= BaitLv3Cost;
                }
                break;

        }
    }
}
