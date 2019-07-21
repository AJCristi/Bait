using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaitTab2 : MonoBehaviour
{
    public Text BreadPrice, InsectPrice, WormPrice;
    public float breadprice, insectprice, wormprice;

    public Text BreadAmt, InsectAmt, WormAmt;

    public Text BreadAmtToBuy, InsectAmtToBuy, WormAmtToBuy;
    int breadtobuy, insecttobuy, wormtobuy;

    public Text BreadCostToBuy, InsectCostToBuy, WormCostToBuy;
    float breadcost, insectcost, wormcost;
    float totalcost;

    public Text TotalPrice;

    public Button BuyBtn;

    public AudioClip Next, BuySFX;
    // Start is called before the first frame update
    void Start()
    {
        breadtobuy = 0;
        insecttobuy = 0;
        wormtobuy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BreadPrice.text = breadprice.ToString();
        InsectPrice.text = insectprice.ToString();
        WormPrice.text = wormprice.ToString();

        BreadAmt.text = GlobalStats.Instance.BreadAmt.ToString();
        InsectAmt.text = GlobalStats.Instance.InsectAmt.ToString();
        WormAmt.text = GlobalStats.Instance.WormAmt.ToString();

        BreadAmtToBuy.text = breadtobuy.ToString();
        InsectAmtToBuy.text = insecttobuy.ToString();
        WormAmtToBuy.text = wormtobuy.ToString();

        if(totalcost > GlobalStats.Instance.PlayerSavings || totalcost == 0)
        {
            BuyBtn.interactable = false;
        }
        else
        {               
            BuyBtn.interactable = true;
        }
        TotalPrice.text = totalcost.ToString();
        ComputeCost();
    }

    void ComputeCost()
    {
        breadcost = breadtobuy * breadprice;
        insectcost = insecttobuy * insectprice;
        wormcost = wormtobuy * wormprice;

        totalcost = breadcost + insectcost + wormcost;

        BreadCostToBuy.text = breadcost.ToString();
        InsectCostToBuy.text = insectcost.ToString();
        WormCostToBuy.text = wormcost.ToString();
    }

    public void PlusBread()
    {
        SFXcontroller.instance.PlaySingle(Next);
        breadtobuy++;
    }
    public void MinusBread()
    {
        SFXcontroller.instance.PlaySingle(Next);
        if (breadtobuy > 0)
        {
            breadtobuy--;
        }
        else
        {
            breadtobuy = 0;
        }
    }

    public void PlusInsect()
    {
        SFXcontroller.instance.PlaySingle(Next);
        insecttobuy++;
    }
    public void MinusInsect()
    {
        SFXcontroller.instance.PlaySingle(Next);
        if (insecttobuy > 0)
        {
            insecttobuy--;
        }
        else
        {
            insecttobuy = 0;
        }
    }

    public void PlusWorm()
    {
        SFXcontroller.instance.PlaySingle(Next);
        wormtobuy++;
    }
    public void MinusWorm()
    {
        SFXcontroller.instance.PlaySingle(Next);
        if (wormtobuy > 0)
        {
            wormtobuy--;
        }
        else
        {
            wormtobuy = 0;
        }
    }

    public void Buy()
    {
        SFXcontroller.instance.PlaySingle(BuySFX);
        GlobalStats.Instance.PlayerSavings -= totalcost;

        GlobalStats.Instance.BreadAmt += breadtobuy;
        GlobalStats.Instance.InsectAmt += insecttobuy;
        GlobalStats.Instance.WormAmt += wormtobuy;
    }
}
