using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestDisplay : MonoBehaviour
{
    public GameObject Quest;

    public GameObject SmallBox, LargeBox;

    public Text SmallboxDays, SmallboxMoney;
    public Text Desc, LargeboxDays, LargeboxMoney;

    public Text Prices;

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalStats.Instance.ActiveEvent == null)
        {
            Quest.SetActive(false);
        }
        else
        {
            Quest.SetActive(true);
            DisplayQInfo();
        }
        
        LargeBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SmallBox.GetComponent<QuestSmallBox>().OnHover)
        {
            LargeBox.SetActive(true);
        }
        else
        {
            LargeBox.SetActive(false);
        }

        switch (GlobalStats.Instance.PricesToday)
        {
            case GlobalStats.MarketPrices.Normal:
                Prices.text = "Prices normal";
                break;

            case GlobalStats.MarketPrices.Higher:
                Prices.text = "Prices higher";
                break;

            case GlobalStats.MarketPrices.Lower:
                Prices.text = "Prices lower";
                break;
        }
    }

    void DisplayQInfo()
    {
        SmallboxDays.text = GlobalStats.Instance.ActiveEvent.DaysRemaining.ToString();
        SmallboxMoney.text = GlobalStats.Instance.ActiveEvent.MoneyRequirement.ToString();
        Desc.text = GlobalStats.Instance.ActiveEvent.Description;

        LargeboxDays.text = GlobalStats.Instance.ActiveEvent.DaysRemaining.ToString();
        LargeboxMoney.text = GlobalStats.Instance.ActiveEvent.MoneyRequirement.ToString();

    }
}
