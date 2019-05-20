using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradesHome : MonoBehaviour
{
    public Text SavingsAmount;
    public GameObject Menu;

    public Text SpeedLvl,RudderLvl;
    public Text SpeedCostTxt, RudderCostTxt;

    public float SpeedLvl1Cost, SpeedLvl2Cost, SpeedLvl3Cost;
    public float RudderLvl1Cost, RudderLvl2Cost, RudderLvl3Cost;

    public GameObject TrawlNet;
    public float TrawlNetCost;

    public GameObject CastNet;
    public float CastNetCost;

    public GameObject HandheldNetUpgrade;
    public float HandheldLvl1Cost, HandheldLvl2Cost, HandheldLvl3Cost;

    public GameObject TrawlNetUpgrade;
    public float TrawlLvl1Cost, TrawlLvl2Cost, TrawlLvl3Cost;

    public GameObject CastNetUpgrade;
    public float CastLvl1Cost, CastLvl2Cost, CastLvl3Cost;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        SavingsAmount.text = "Savings -- PHP: " + GlobalStats.Instance.Savings.ToString();
        AssignText();
        CheckNetStatus();
    }

    void AssignText()
    {
        SpeedLvl.text = GlobalStats.Instance.GetSpeedLvl();
        SpeedCostTxt.text = "PHP: " + SpeedCost().ToString();

        RudderLvl.text = GlobalStats.Instance.GetRudderLevel();
        RudderCostTxt.text = "PHP: " + RudderCost().ToString();

        HandheldNetUpgrade.transform.GetChild(1).GetComponent<Text>().text = GlobalStats.Instance.GetHandLvl().ToString();
        TrawlNetUpgrade.transform.GetChild(1).GetComponent<Text>().text = GlobalStats.Instance.GetTrawlLvl().ToString();
        CastNetUpgrade.transform.GetChild(1).GetComponent<Text>().text = GlobalStats.Instance.GetCastLvl().ToString();
    }

    public void OpenMenu()
    {
        Menu.SetActive(true);
    }

    public void ReturnBtn()
    {
        Menu.SetActive(false);
    }

    public void UpgradeSpd()
    {
        switch(GlobalStats.Instance.CurSpeedLvl)
        {
            case GlobalStats.Speed.P1:
                if (CanBuy(SpeedLvl1Cost))
                {
                    GlobalStats.Instance.UpgradeSpd();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.Speed.P2:
                if (CanBuy(SpeedLvl2Cost))
                {
                    GlobalStats.Instance.UpgradeSpd();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.Speed.P3:
                Debug.Log("Max");
                break;
        }
        
    }

    public void UpgradeRudder()
    {
        switch (GlobalStats.Instance.CurRudderLvl)
        {
            case GlobalStats.Rudder.P1:
                if (CanBuy(RudderLvl1Cost))
                {
                    GlobalStats.Instance.UpgradeRudder();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.Rudder.P2:
                if (CanBuy(RudderLvl2Cost))
                {
                    GlobalStats.Instance.UpgradeRudder();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.Rudder.P3:
                Debug.Log("Max");
                break;
        }        
    }

    public void UpgradeHandheld()
    {
        switch (GlobalStats.Instance.CurHandLvl)
        {
            case GlobalStats.HandheldNetLvl.L1:
                if (CanBuy(HandheldLvl1Cost))
                {
                    GlobalStats.Instance.UpgradeHand();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.HandheldNetLvl.L2:
                if (CanBuy(HandheldLvl2Cost))
                {
                    GlobalStats.Instance.UpgradeHand();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.HandheldNetLvl.L3:
                Debug.Log("Max");
                break;
        }
       
    }

    public void UpgradeTrawl()
    {
        switch (GlobalStats.Instance.CurTrawlLvl)
        {
            case GlobalStats.TrawlNetLvl.L1:
                if (CanBuy(TrawlLvl1Cost))
                {
                    GlobalStats.Instance.UpgradeTrawl();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.TrawlNetLvl.L2:
                if (CanBuy(TrawlLvl2Cost))
                {
                    GlobalStats.Instance.UpgradeTrawl();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.TrawlNetLvl.L3:
                Debug.Log("Max");
                break;
        }       
    }

    public void UpgradeCast()
    {
        switch (GlobalStats.Instance.CurCastLvl)
        {
            case GlobalStats.CastNetLvl.L1:
                if (CanBuy(CastLvl1Cost))
                {
                    GlobalStats.Instance.UpgradeCast();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.CastNetLvl.L2:
                if (CanBuy(CastLvl2Cost))
                {
                    GlobalStats.Instance.UpgradeCast();
                }
                else
                {
                    Debug.Log("Can't");
                }
                break;

            case GlobalStats.CastNetLvl.L3:
                Debug.Log("Max");
                break;
        }        
    }

    void CheckNetStatus()
    {

        HandheldNetUpgrade.transform.GetChild(0).GetComponent<Text>().text = "PHP: " + HandheldUpCost().ToString();

        if (GlobalStats.Instance.TrawlUnlocked == false)
        {
            TrawlNet.transform.GetChild(0).GetComponent<Text>().text = "PHP: " + TrawlNetCost.ToString();
            TrawlNetUpgrade.SetActive(false);
        }
        else
        {            
            TrawlNet.SetActive(false);
            TrawlNetUpgrade.SetActive(true);
            TrawlNetUpgrade.transform.GetChild(0).GetComponent<Text>().text = "PHP: " + TrawlUpCost().ToString();            
        }

        if (GlobalStats.Instance.CastUnlocked == false)
        {
            CastNet.transform.GetChild(0).GetComponent<Text>().text = "PHP: " + CastNetCost.ToString();
            CastNetUpgrade.SetActive(false);
        }
        else
        {            
            CastNet.SetActive(false);
            CastNetUpgrade.SetActive(true);
            CastNetUpgrade.transform.GetChild(0).GetComponent<Text>().text = "PHP: " + CastUpCost().ToString();
        }
    }

    public void UnlockTrawl()
    {
        if (CanBuy(TrawlNetCost))        
            GlobalStats.Instance.UnlockTrawl();  
    }

    public void UnlockCast()
    {
        if (CanBuy(TrawlNetCost))
            GlobalStats.Instance.UnlockCast();
    }

    float SpeedCost()
    {
        switch(GlobalStats.Instance.CurSpeedLvl)
        {
            case GlobalStats.Speed.P1:
                return SpeedLvl1Cost;

            case GlobalStats.Speed.P2:
                return SpeedLvl2Cost;

            case GlobalStats.Speed.P3:
                return SpeedLvl3Cost;                
        }

        return 999;
    }

    float RudderCost()
    {
        switch (GlobalStats.Instance.CurRudderLvl)
        {
            case GlobalStats.Rudder.P1:
                return RudderLvl1Cost;

            case GlobalStats.Rudder.P2:
                return RudderLvl2Cost;

            case GlobalStats.Rudder.P3:
                return RudderLvl3Cost;
        }

        return 999;
    }

    float HandheldUpCost()
    {
        switch (GlobalStats.Instance.CurHandLvl)
        {
            case GlobalStats.HandheldNetLvl.L1:
                return HandheldLvl1Cost;

            case GlobalStats.HandheldNetLvl.L2:
                return HandheldLvl2Cost;

            case GlobalStats.HandheldNetLvl.L3:
                return HandheldLvl3Cost;
        }
        return 999;
    }

    float TrawlUpCost()
    {
        switch (GlobalStats.Instance.CurTrawlLvl)
        {
            case GlobalStats.TrawlNetLvl.L1:
                return TrawlLvl1Cost;

            case GlobalStats.TrawlNetLvl.L2:
                return TrawlLvl2Cost;

            case GlobalStats.TrawlNetLvl.L3:
                return TrawlLvl3Cost;
        }
        return 999;
    }

    float CastUpCost()
    {
        switch (GlobalStats.Instance.CurCastLvl)
        {
            case GlobalStats.CastNetLvl.L1:
                return CastLvl1Cost;

            case GlobalStats.CastNetLvl.L2:
                return CastLvl2Cost;

            case GlobalStats.CastNetLvl.L3:
                return CastLvl3Cost;
        }
        return 999;
    }

    bool CanBuy(float Price)
    {
        if (GlobalStats.Instance.Savings >= Price)
        {
            GlobalStats.Instance.Savings -= Price;
            return true;
        }
        else
        {
            return false;
        }
    }

}
