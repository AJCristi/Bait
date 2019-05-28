using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Family : MonoBehaviour
{
    public Image WifeHappiness, DaughterHappiness;
    public Image HungerMeter;

    public GameObject StatsPanel;
    bool statsUp;

    public GameObject HappinessIndicator, HungerIndicator;
    bool poppedInd;
    float x;

    Vector3 startingPos;
    public GameObject NextButton;
    public GameObject NewPos;
    public GameObject Panel;
    public Button storeButton;

    public GameObject HaulPrompt;    
    float haulConsumeAmt;
    float happinessCalc;
    float hungerCalc;

    public Text HungerDisplay;
    public Text HappiDisplay;
    public Text HaulAmtDisplay;
    bool haulPromptOpen;

    bool Change;

    // Start is called before the first frame update
    void Start()
    {
        haulConsumeAmt = .2f;
        startingPos = StatsPanel.GetComponent<RectTransform>().transform.position;
        x = 0;
        statsUp = false;
        poppedInd = false;
        NextButton.SetActive(false);

        HappinessIndicator.SetActive(false);
        HungerIndicator.SetActive(false);
        Change = true;

        HaulPrompt.SetActive(false);
        haulPromptOpen = false;
        Panel.SetActive(true);


        happinessCalc = 0;
        hungerCalc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(Change)
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


        if(statsUp)
        {
            StatsPanel.GetComponent<RectTransform>().transform.position = NewPos.GetComponent<RectTransform>().transform.position;
        }
        else
        {
            StatsPanel.GetComponent<RectTransform>().transform.position = startingPos;
        }

        if (GlobalStats.Instance.CurFood == GlobalStats.FoodItems.None 
            || !GlobalStats.Instance.BoughtFood)
        {
            storeButton.interactable = false;
        }
        else
        {
            storeButton.interactable = true;
        }

        if(poppedInd)
        {
           
            if(x <= 3)
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
            NextButton.SetActive(true);


        }

        UpdateStats();

        if(haulPromptOpen)
        {
            HaulAmtDisplay.text = haulConsumeAmt.ToString() + " Kg/s";
            HungerDisplay.text = hungerCalc.ToString() + " Kg/s";
            HappiDisplay.text = happinessCalc.ToString() + " Kg/s";
        }
        
    }
    

    public void ConsumeBoughtFood()
    {
        if (GlobalStats.Instance.BoughtFood)
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


            }    
            
            GlobalStats.Instance.BoughtFood = false;
            GlobalStats.Instance.PrevFood = GlobalStats.Instance.CurFood;
            GlobalStats.Instance.CurFood = GlobalStats.FoodItems.None;
             
            Panel.SetActive(false);
            Change = true;
            poppedInd = true;
        }        
    }

    public void FromHaul()
    {
        HaulPrompt.SetActive(true);
        haulPromptOpen = true;
    }

    public void HaulRight()
    {
        if (haulConsumeAmt <= 2)
            haulConsumeAmt += .2f;

        if(happinessCalc < 20)        
            happinessCalc += 3f;        

        if (hungerCalc < 10)
            hungerCalc += 1f;
    }

    public void HaulLeft()
    { 
        if(haulConsumeAmt > .3)
            haulConsumeAmt -= .2f;

        if (happinessCalc > 0)
            happinessCalc -= 3f;

        if (hungerCalc > 0)
            hungerCalc -= 1f;
    }

    public void HaulExit()
    {
        HaulPrompt.SetActive(false);
        haulPromptOpen = false;
    }

    public void HaulConfirm()
    {
        GlobalStats.Instance.FishKG -= haulConsumeAmt;

        GlobalStats.Instance.DaughterHappiness += happinessCalc;
        GlobalStats.Instance.WifeHappiness += happinessCalc;

        GlobalStats.Instance.Hunger += hungerCalc;

        HaulPrompt.SetActive(false);
        haulPromptOpen = false;

        Panel.SetActive(false);
        Change = true;
        poppedInd = true;
    }

    public void SkipDinner()
    {
        GlobalStats.Instance.Hunger -= 10;
        GlobalStats.Instance.DaughterHappiness -= 10;
        GlobalStats.Instance.WifeHappiness -= 10;

        Panel.SetActive(false);

        Change = false;
        poppedInd = true;
    }

    void UpdateStats()
    {
        WifeHappiness.fillAmount = GlobalStats.Instance.WifeHappiness / 100;
        HungerMeter.fillAmount = GlobalStats.Instance.Hunger / 100;
        DaughterHappiness.fillAmount = GlobalStats.Instance.DaughterHappiness / 100;
    }

    public void BringUpStats()
    {
        statsUp = !statsUp;
        
    }
}
