using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TabController : MonoBehaviour
{
    public enum Tabs
    {
        Fish, 
        Bait,
        Gear
    }

    public Tabs ActiveTab;

    public GameObject FishTab, BaitTab, GearTab;

    public AudioClip TabSwitch;
    //public Text MarketPrices;

    // Start is called before the first frame update
    void Start()
    {
        ActiveTab = Tabs.Bait;
        FishTab.SetActive(false);
        BaitTab.SetActive(false);
        GearTab.SetActive(false);

        //switch (GlobalStats.Instance.PricesToday)
        //{
        //    case GlobalStats.MarketPrices.Normal:
        //        MarketPrices.text = "Market Prices are normal today";
        //        break;

        //    case GlobalStats.MarketPrices.Higher:
        //        MarketPrices.text = "Market Prices are higher today";
        //        break;

        //    case GlobalStats.MarketPrices.Lower:
        //        MarketPrices.text = "Market Prices are lower today";
        //        break;
        //}

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
        SFXcontroller.instance.PlaySingle(TabSwitch);
    }
    public void SelectBait()
    {
        ActiveTab = Tabs.Bait;
        SFXcontroller.instance.PlaySingle(TabSwitch);
    }
    public void SelectGear()
    {
        ActiveTab = Tabs.Gear;
        SFXcontroller.instance.PlaySingle(TabSwitch);
    }

    public void ReturnBack()
    {
        LoadingScreen.Instance.LoadScene("1_MapSelector");
        //SceneManager.LoadScene("1_MapSelector");
    }
}
