using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetTab2 : MonoBehaviour
{
    public Text RodPriceText, CastPriceText, TrawlCastText;
    public float rodPrice, castPrice, trawlPrice;

    public Text RodLvlText, CastLvlText, TrawlLvlText;

    public Text RodBuyLvlText, CastBuyLvlText, TrawlBuyLvlText;

    [Range (1,5)]
    int rodBuyLvl, castBuyLvl, trawlBuyLvl;

    public Text RodCostText, CastCostText, TrawlCostText;
    float rodCost, castCost, trawlCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Prices();
        CheckLvl();



    }

    void Prices()
    {
        RodPriceText.text = rodPrice.ToString();
        CastPriceText.text = castPrice.ToString();
        TrawlCastText.text = trawlPrice.ToString();
    }

    void CheckLvl()
    {
        if(GlobalStats.Instance.AltRodLvl <= 0)
        {
            RodLvlText.text = "-";
        }
        else
        {
            RodLvlText.text = GlobalStats.Instance.AltRodLvl.ToString();
        }

        if (GlobalStats.Instance.AltCastLvl <= 0)
        {
            CastLvlText.text = "-";
        }
        else
        {
            CastLvlText.text = GlobalStats.Instance.AltCastLvl.ToString();
        }

        if (GlobalStats.Instance.AltTrawlLvl <= 0)
        {
            TrawlLvlText.text = "-";
        }
        else
        {
            TrawlLvlText.text = GlobalStats.Instance.AltTrawlLvl.ToString();
        }
    }

    void BuyLvl()
    {
        RodBuyLvlText.text = rodBuyLvl.ToString();
        CastBuyLvlText.text = castBuyLvl.ToString();
        TrawlBuyLvlText.text = trawlBuyLvl.ToString();
    }
}
