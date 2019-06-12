using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketMenu : MonoBehaviour
{
    public Text Savings;
    
    public Text NetLvlText;
    public Text NetCostText;
    public GameObject NetObj;

    //public float NetLv2Cost, NetLv3Cost;
    public float TrawlingLv2Cost, TrawlingLv3Cost, TrawlingLv4Cost, TrawlingLv5Cost;
    public float CastLv2Cost, CastLv3Cost, CastLv4Cost, CastLv5Cost;
    public float RodLv2Cost, RodLv3Cost, RodLv4Cost, RodLv5Cost;


    //public Text BaitLvlText;
    //public Text BaitCostText;
    //public GameObject BaitObj;

    //public float BaitLv2Cost, BaitLv3Cost;


    public Text CurBaitTxt;
    public Text CurBaitAmtTxt;
    public Text BuyBaitTxt;
    public Text BaitPriceTxt;

    float baitPrice;

    public Text NetTypeText;

    public int buyBaitAmt;

    // Start is called before the first frame update
    void Start()
    {
        buyBaitAmt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerStats();
        BaitUpgrades();
        BoatUpgrades();
    }

    void UpdatePlayerStats()
    {
        Savings.text = "PHP: " + GlobalStats.Instance.PlayerSavings.ToString();
        
    }

    void BoatUpgrades()
    {
        NetTypeText.text = GlobalStats.Instance.CurrentNet.ToString();

        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Trawling:
                NetLvlText.text = "Net Level -- " + GlobalStats.Instance.TrawlingNetLevel.ToString();  
                switch(GlobalStats.Instance.TrawlingNetLevel)
                {
                    case 1:
                        NetCostText.text = "PHP: " + TrawlingLv2Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 2:
                        NetCostText.text = "PHP: " + TrawlingLv3Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 3:
                        NetCostText.text = "PHP: " + TrawlingLv4Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 4:
                        NetCostText.text = "PHP: " + TrawlingLv5Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;

                    case 5:
                        NetObj.GetComponent<Button>().interactable = false;
                        Debug.Log("BROKE1");
                        break;
                }
                break;

            case GlobalStats.NetType.Cast:
                NetLvlText.text = "Net Level -- " + GlobalStats.Instance.CastNetLevel.ToString();
                switch (GlobalStats.Instance.CastNetLevel)
                {
                    case 1:
                        NetCostText.text = "PHP: " + CastLv2Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 2:
                        NetCostText.text = "PHP: " + CastLv3Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 3:
                        NetCostText.text = "PHP: " + CastLv4Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 4:
                        NetCostText.text = "PHP: " + CastLv5Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;

                    case 5:
                        NetObj.GetComponent<Button>().interactable = false;
                        Debug.Log("BROKE2");
                        break;
                }
                break;

            case GlobalStats.NetType.Rod:
                NetLvlText.text = "Net Level -- " + GlobalStats.Instance.RodNetLevel.ToString();
                switch (GlobalStats.Instance.RodNetLevel)
                {
                    case 1:
                        NetCostText.text = "PHP: " + RodLv2Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 2:
                        NetCostText.text = "PHP: " + RodLv3Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 3:
                        NetCostText.text = "PHP: " + RodLv4Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;
                    case 4:
                        NetCostText.text = "PHP: " + RodLv5Cost.ToString();
                        NetObj.GetComponent<Button>().interactable = true;
                        break;

                    case 5:
                        NetObj.GetComponent<Button>().interactable = false;
                        Debug.Log("BROKE3");
                        break;
                }
                break;

        }

        //BaitLvlText.text = "Bait Level " + GlobalStats.Instance.BaitLevel.ToString();
        //if (GlobalStats.Instance.BaitLevel == 1)
        //{
        //    BaitCostText.text = "PHP: " + BaitLv2Cost.ToString();
        //}

        //else if (GlobalStats.Instance.BaitLevel == 2)
        //{
        //    BaitCostText.text = "PHP: " + BaitLv3Cost.ToString();
        //}
        //else
        //{
        //    BaitCostText.text = " xd";
        //    BaitObj.SetActive(false);
        //}
    }

    void BaitUpgrades()
    {
        CurBaitTxt.text = GlobalStats.Instance.CurrentBait.ToString();
        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                CurBaitAmtTxt.text = GlobalStats.Instance.BreadAmt.ToString();
                break;

            case GlobalStats.BaitType.Insects:
                CurBaitAmtTxt.text = GlobalStats.Instance.InsectAmt.ToString();
                break;

            case GlobalStats.BaitType.Worms:
                CurBaitAmtTxt.text = GlobalStats.Instance.WormAmt.ToString();
                break;
        }

        BuyBaitTxt.text = buyBaitAmt.ToString();

        ComputePrice(GlobalStats.Instance.CurrentBait);
        BaitPriceTxt.text = "Php : " + baitPrice.ToString("F2");
    }

    void ComputePrice(GlobalStats.BaitType bt)
    {
        switch(bt)
        {
            case GlobalStats.BaitType.Bread:
                baitPrice = buyBaitAmt * 3;
                break;

            case GlobalStats.BaitType.Insects:
                baitPrice = buyBaitAmt * 5;
                break;

            case GlobalStats.BaitType.Worms:
                baitPrice = buyBaitAmt * 7;
                break;
        }

    }

    public void UpgradeNet()
    {       
        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                switch(GlobalStats.Instance.CastNetLevel)
                {
                    case 1:
                        if(GlobalStats.Instance.PlayerSavings >= CastLv2Cost)
                        {
                            GlobalStats.Instance.CastNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= CastLv2Cost;
                        }
                        break;

                    case 2:
                        if (GlobalStats.Instance.PlayerSavings >= CastLv3Cost)
                        {
                            GlobalStats.Instance.CastNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= CastLv3Cost;
                        }
                        break;

                    case 3:
                        if (GlobalStats.Instance.PlayerSavings >= CastLv4Cost)
                        {
                            GlobalStats.Instance.CastNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= CastLv4Cost;
                        }
                        break;

                    case 4:
                        if (GlobalStats.Instance.PlayerSavings >= CastLv5Cost)
                        {
                            GlobalStats.Instance.CastNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= CastLv5Cost;
                        }
                        break;
                }
                break;

            case GlobalStats.NetType.Rod:
                switch (GlobalStats.Instance.RodNetLevel)
                {
                    case 1:
                        if (GlobalStats.Instance.PlayerSavings >= RodLv2Cost)
                        {
                            GlobalStats.Instance.RodNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= RodLv2Cost;
                        }
                        break;

                    case 2:
                        if (GlobalStats.Instance.PlayerSavings >= RodLv3Cost)
                        {
                            GlobalStats.Instance.RodNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= RodLv3Cost;
                        }
                        break;

                    case 3:
                        if (GlobalStats.Instance.PlayerSavings >= RodLv4Cost)
                        {
                            GlobalStats.Instance.RodNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= RodLv4Cost;
                        }
                        break;

                    case 4:
                        if (GlobalStats.Instance.PlayerSavings >= RodLv5Cost)
                        {
                            GlobalStats.Instance.RodNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= RodLv5Cost;
                        }
                        break;
                }
                break;
                

            case GlobalStats.NetType.Trawling:
                switch (GlobalStats.Instance.TrawlingNetLevel)
                {
                    case 1:
                        if (GlobalStats.Instance.PlayerSavings >= TrawlingLv2Cost)
                        {
                            GlobalStats.Instance.TrawlingNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= TrawlingLv2Cost;
                        }
                        break;

                    case 2:
                        if (GlobalStats.Instance.PlayerSavings >= TrawlingLv3Cost)
                        {
                            GlobalStats.Instance.TrawlingNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= TrawlingLv3Cost;
                        }
                        break;

                    case 3:
                        if (GlobalStats.Instance.PlayerSavings >= TrawlingLv4Cost)
                        {
                            GlobalStats.Instance.TrawlingNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= TrawlingLv4Cost;
                        }
                        break;

                    case 4:
                        if (GlobalStats.Instance.PlayerSavings >= TrawlingLv5Cost)
                        {
                            GlobalStats.Instance.TrawlingNetLevel++;
                            GlobalStats.Instance.PlayerSavings -= TrawlingLv5Cost;
                        }
                        break;
                }
                break;


        }
    }

    public void ChangeNetType()
    {
        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Trawling:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Cast;
                break;

            case GlobalStats.NetType.Cast:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Rod;
                break;

            case GlobalStats.NetType.Rod:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Trawling;
                break;
        }
    }

    public void ChangeBaitType()
    {
        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Insects;
                break;

            case GlobalStats.BaitType.Insects:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Worms;
                break;

            case GlobalStats.BaitType.Worms:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Bread;
                break;

        }
    }

    public void IncreaseBuyBaitAmt()
    {
        buyBaitAmt++;
        if (buyBaitAmt > 10)
        {
            buyBaitAmt = 10;
        }        
    }

    public void DecreaseBuyBaitAmt()
    {
        buyBaitAmt--;
        if(buyBaitAmt < 0)
        {
            buyBaitAmt = 0;
        }
    }

    public void BuyBait()
    {
        if(GlobalStats.Instance.PlayerSavings >= baitPrice)
        {
            switch(GlobalStats.Instance.CurrentBait)
            {
                case GlobalStats.BaitType.Bread:
                    GlobalStats.Instance.BreadAmt += buyBaitAmt;
                    break;

                case GlobalStats.BaitType.Insects:
                    GlobalStats.Instance.InsectAmt += buyBaitAmt;
                    break;

                case GlobalStats.BaitType.Worms:
                    GlobalStats.Instance.WormAmt += buyBaitAmt;
                    break;
            }
            GlobalStats.Instance.PlayerSavings -= baitPrice;
        }
    }
}
