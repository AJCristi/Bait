using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        FishTab.SetActive(false);
        BaitTab.SetActive(false);
        GearTab.SetActive(false);

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
}
