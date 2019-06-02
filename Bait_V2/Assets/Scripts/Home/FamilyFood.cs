using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyFood : MonoBehaviour
{
    public Image WifeHappiness, DaughterHappiness;
    public Image HungerMeter;

    bool statsUp;
    public GameObject HappinessIndicator, HungerIndicator;
    bool poppedInd;
    float x;

    

    public Button storeButton;
    public Button GetFromHaul;

    public GameObject FoodPanel;
    public Text ToolTipsFood;

    public Text Description;
    
    float happinessCalc;
    float hungerCalc;    

    bool Change;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        poppedInd = false;
       

        HappinessIndicator.SetActive(false);
        HungerIndicator.SetActive(false);
        Change = true;

        happinessCalc = 0;
        hungerCalc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Change)
        {
            case true:
                HappinessIndicator.GetComponent<Text>().text = "Happiness++";
                HungerIndicator.GetComponent<Text>().text = "Hunger++";
                break;

            case false:
                HappinessIndicator.GetComponent<Text>().text = "Happiness--";
                HungerIndicator.GetComponent<Text>().text = "Hunger--";
                break;
        }

        if (GlobalStats.Instance.CurFood == GlobalStats.FoodItems.None
            || GlobalStats.Instance.CurFood == GlobalStats.FoodItems.Fish || !GlobalStats.Instance.BoughtFood)
        {
            storeButton.interactable = false;
        }
        else
        {
            storeButton.interactable = true;
        }

        if (GlobalStats.Instance.CurFood == GlobalStats.FoodItems.Fish)
        {
            GetFromHaul.interactable = true;
        }
        else
        {
            GetFromHaul.interactable = false;
        }

        if (poppedInd)
        {

            if (x <= 3)
            {
                HappinessIndicator.SetActive(true);
                HungerIndicator.SetActive(true);
                x += Time.deltaTime;
            }
            else
            {
                HappinessIndicator.SetActive(false);
                HungerIndicator.SetActive(false);
                poppedInd = false;
                x = 0;
            }
            GetComponent<Home>().FoodDone = true;
        }

        switch(GlobalStats.Instance.CurFood)
        {
            case GlobalStats.FoodItems.Beef:
                Description.text = "You bought beef!";
                break;

            case GlobalStats.FoodItems.Chicken:
                Description.text = "You bought chicken!";
                break;

            case GlobalStats.FoodItems.Fish:
                Description.text = "You got fish from your catch!";
                break;

            case GlobalStats.FoodItems.None:
                Description.text = "You bdidn't buy anything";
                break;

            case GlobalStats.FoodItems.Pork:
                Description.text = "You bought pork!";
                break;

            case GlobalStats.FoodItems.Vegetables:
                Description.text = "You bought vegetables!";
                break;

        }

        UpdateStats();
    }

    public void SkipDinner()
    {
        GlobalStats.Instance.Hunger -= 10;
        GlobalStats.Instance.DaughterHappiness -= 10;
        GlobalStats.Instance.WifeHappiness -= 10;

        FoodPanel.SetActive(false);

        Change = false;
        poppedInd = true;
    }

    public void FromHaul()
    {
        if (GlobalStats.Instance.BoughtFood && GlobalStats.Instance.CurFood == GlobalStats.FoodItems.Fish)
        {
            GlobalStats.Instance.WifeHappiness += GlobalStats.Instance.FishHap;
            GlobalStats.Instance.DaughterHappiness += GlobalStats.Instance.FishHap;
            GlobalStats.Instance.Hunger += GlobalStats.Instance.FishHung;

            GlobalStats.Instance.BoughtFood = false;
            GlobalStats.Instance.PrevFood = GlobalStats.Instance.CurFood;
            GlobalStats.Instance.CurFood = GlobalStats.FoodItems.None;

            FoodPanel.SetActive(false);
            Change = true;
            poppedInd = true;
        }
    }

    public void ConsumeBoughtFood()
    {
        if (GlobalStats.Instance.BoughtFood && GlobalStats.Instance.CurFood != GlobalStats.FoodItems.Fish)
        {
            switch (GlobalStats.Instance.CurFood)
            {
                case GlobalStats.FoodItems.Chicken:
                    GlobalStats.Instance.WifeHappiness +=
                        GlobalStats.Instance.ChickenHap;

                    GlobalStats.Instance.DaughterHappiness +=
                        GlobalStats.Instance.ChickenHap;

                    GlobalStats.Instance.Hunger +=
                        GlobalStats.Instance.ChickenHung;
                    break;

                case GlobalStats.FoodItems.Beef:
                    GlobalStats.Instance.WifeHappiness +=
                        GlobalStats.Instance.BeefHap;

                    GlobalStats.Instance.DaughterHappiness +=
                        GlobalStats.Instance.BeefHap;

                    GlobalStats.Instance.Hunger +=
                        GlobalStats.Instance.BeefHung;
                    break;

                case GlobalStats.FoodItems.Vegetables:
                    GlobalStats.Instance.WifeHappiness +=
                        GlobalStats.Instance.VegetablesHap;

                    GlobalStats.Instance.DaughterHappiness +=
                        GlobalStats.Instance.VegetablesHap;

                    GlobalStats.Instance.Hunger +=
                        GlobalStats.Instance.VegetablesHung;
                    break;

                case GlobalStats.FoodItems.Pork:
                    GlobalStats.Instance.WifeHappiness +=
                        GlobalStats.Instance.PorkHap;

                    GlobalStats.Instance.DaughterHappiness +=
                        GlobalStats.Instance.PorkHap;

                    GlobalStats.Instance.Hunger +=
                        GlobalStats.Instance.PorkHung;
                    break;

                case GlobalStats.FoodItems.None:
                    Debug.Log("thefuck??");
                    break;

                case GlobalStats.FoodItems.Fish:
                    goto case GlobalStats.FoodItems.None;

            }

            GlobalStats.Instance.BoughtFood = false;
            GlobalStats.Instance.PrevFood = GlobalStats.Instance.CurFood;
            GlobalStats.Instance.CurFood = GlobalStats.FoodItems.None;

            FoodPanel.SetActive(false);
            Change = true;
            poppedInd = true;
        }
    }

    void UpdateStats()
    {
        WifeHappiness.fillAmount = GlobalStats.Instance.WifeHappiness / 100;
        HungerMeter.fillAmount = GlobalStats.Instance.Hunger / 100;
        DaughterHappiness.fillAmount = GlobalStats.Instance.DaughterHappiness / 100;
    }
}
