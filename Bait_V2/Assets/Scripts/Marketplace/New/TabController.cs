using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TabController : MonoBehaviour
{
    enum Tabs
    {
        Fish, 
        Bait,
        Gear
    }

    Tabs ActiveTab;

    public GameObject FishTab, BaitTab, GearTab;

    public Text MarketPrices;

    // Start is called before the first frame update
    void Start()
    {
        FishTab.SetActive(false);
        BaitTab.SetActive(false);
        GearTab.SetActive(false);

        switch (GlobalStats.Instance.PricesToday)
        {
            case GlobalStats.MarketPrices.Normal:
                MarketPrices.text = "Market Prices are normal today";
                break;

            case GlobalStats.MarketPrices.Higher:
                MarketPrices.text = "Market Prices are higher today";
                break;

            case GlobalStats.MarketPrices.Lower:
                MarketPrices.text = "Market Prices are lower today";
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        switch(ActiveTab)
        {
            case Tabs.Bait:
                FishTab.SetActive(false);
                BaitTab.SetActive(true);
                GearTab.SetActive(false);
                break;

            case Tabs.Fish:
                FishTab.SetActive(true);
                BaitTab.SetActive(false);
                GearTab.SetActive(false);
                break;

            case Tabs.Gear:
                FishTab.SetActive(false);
                BaitTab.SetActive(false);
                GearTab.SetActive(true);
                break;
        }
    }

    public void SelectFish()
    {
        ActiveTab = Tabs.Fish;
    }
    public void SelectBait()
    {
        ActiveTab = Tabs.Bait;
    }
    public void SelectGear()
    {
        ActiveTab = Tabs.Gear;
    }

    public void ReturnBack()
    {
        SceneManager.LoadScene("1_MapSelector");
    }
}
