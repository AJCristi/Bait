using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DayController : MonoBehaviour
{
    public Image DaySlice1, DaySlice2, DaySlice3, DaySlice4;
    public GameObject D1Indicator, D2Indicator, D3Indicator, D4Indicator;

    public GameObject GoHome,Market,Fishing;

    public Text Savings;

    public Text SmallF, MedF, LargeF;

    public Text Month, Day;

    public Text Dinner;

    // Start is called before the first frame update
    void Start()
    {       
        CheckTime();
        
        Month.text = GlobalStats.Instance.Month.ToString();
        Day.text = GlobalStats.Instance.Day.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CheckButtons();
        CheckFood();

        SmallF.text = GlobalStats.Instance.smallKG.ToString("F2") + " kg";
        MedF.text = GlobalStats.Instance.medKG.ToString("F2") + " kg";
        LargeF.text = GlobalStats.Instance.largeKG.ToString("F2") + " kg";


        Savings.text = "Savings PHP: " + GlobalStats.Instance.PlayerSavings;
    }

    void CheckTime()
    {
        switch(GlobalStats.Instance.TS1)
        {
            case GlobalStats.Activity.Fishing:
                DaySlice1.color = Color.green;
                break;

            case GlobalStats.Activity.Market:
                DaySlice1.color = Color.red;
                break;

            case GlobalStats.Activity.None:
                DaySlice1.color = Color.black;
                break;
        }

        switch (GlobalStats.Instance.TS2)
        {
            case GlobalStats.Activity.Fishing:
                DaySlice2.color = Color.green;
                break;

            case GlobalStats.Activity.Market:
                DaySlice2.color = Color.red;
                break;

            case GlobalStats.Activity.None:
                DaySlice2.color = Color.black;
                break;
        }       

        switch (GlobalStats.Instance.TS3)
        {
            case GlobalStats.Activity.Fishing:
                DaySlice3.color = Color.green;
                break;

            case GlobalStats.Activity.Market:
                DaySlice3.color = Color.red;
                break;

            case GlobalStats.Activity.None:
                DaySlice3.color = Color.black;
                break;
        }

        switch (GlobalStats.Instance.TS4)
        {
            case GlobalStats.Activity.Fishing:
                DaySlice4.color = Color.green;
                break;

            case GlobalStats.Activity.Market:
                DaySlice4.color = Color.red;
                break;

            case GlobalStats.Activity.None:
                DaySlice4.color = Color.black;
                break;
        }
    }    

    void CheckButtons()
    {
        switch(GlobalStats.Instance.CurrentTime)
        {
            case 1:
                //GoHome.SetActive(false);
                Market.SetActive(true);
                Fishing.SetActive(true);

                D1Indicator.SetActive(true);
                D2Indicator.SetActive(false);
                D3Indicator.SetActive(false);
                D4Indicator.SetActive(false);
                break;
            case 2:
                //GoHome.SetActive(false);
                Market.SetActive(true);
                Fishing.SetActive(true);

                D1Indicator.SetActive(false);
                D2Indicator.SetActive(true);
                D3Indicator.SetActive(false);
                D4Indicator.SetActive(false);
                break;
            case 3:
                //GoHome.SetActive(false);
                Market.SetActive(true);
                Fishing.SetActive(true);

                D1Indicator.SetActive(false);
                D2Indicator.SetActive(false);
                D3Indicator.SetActive(true);
                D4Indicator.SetActive(false);
                break;
            case 4:
                //GoHome.SetActive(false);
                Market.SetActive(true);
                Fishing.SetActive(true);

                D1Indicator.SetActive(false);
                D2Indicator.SetActive(false);
                D3Indicator.SetActive(false);
                D4Indicator.SetActive(true);
                break;

            case 5:
                GoHome.SetActive(true);
                Market.SetActive(false);
                Fishing.SetActive(false);

                D1Indicator.SetActive(false);
                D2Indicator.SetActive(false);
                D3Indicator.SetActive(false);
                D4Indicator.SetActive(false);
                break;
        }
    }

    void CheckFood()
    {
        Debug.Log(GlobalStats.Instance.CurFood);
        switch(GlobalStats.Instance.CurFood)
        {
            case GlobalStats.FoodItems.Beef:
                Dinner.text = "You have beef for dinner!";
                break;

            case GlobalStats.FoodItems.Chicken:
                Dinner.text = "You have Chicken for dinner!";
                break;

            case GlobalStats.FoodItems.Pork:
                Dinner.text = "You have Pork for dinner!";
                break;

            case GlobalStats.FoodItems.Vegetables:
                Dinner.text = "You have Vegetables for dinner!";
                break;

            case GlobalStats.FoodItems.Fish:
                Dinner.text = "You have Fish for dinner!";
                break;

            case GlobalStats.FoodItems.None:
                Dinner.text = "You don't have anything for dinner..";
                break;
        }
    }

    public void StartActivity(string scene)
    {
        switch(scene)
        {
            case "1_MarketPlaceTest":
                switch(GlobalStats.Instance.CurrentTime)
                {
                    case 1:
                        GlobalStats.Instance.TS1 = GlobalStats.Activity.Market;
                        break;

                    case 2:
                        GlobalStats.Instance.TS2 = GlobalStats.Activity.Market;
                        break;

                    case 3:
                        GlobalStats.Instance.TS3 = GlobalStats.Activity.Market;
                        break;

                    case 4:
                        GlobalStats.Instance.TS4 = GlobalStats.Activity.Market;
                        break;
                }                
                break;

            case "2_FishingTest":
                switch (GlobalStats.Instance.CurrentTime)
                {
                    case 1:
                        GlobalStats.Instance.TS1 = GlobalStats.Activity.Fishing;
                        break;

                    case 2:
                        GlobalStats.Instance.TS2 = GlobalStats.Activity.Fishing;
                        break;

                    case 3:
                        GlobalStats.Instance.TS3 = GlobalStats.Activity.Fishing;
                        break;

                    case 4:
                        GlobalStats.Instance.TS4 = GlobalStats.Activity.Fishing;
                        break;
                }
                break;
        }
        GlobalStats.Instance.CurrentTime++;
        SceneManager.LoadScene(scene);
    }

    public void HeadHome()
    {
        GlobalStats.Instance.CurrentTime = 1;
        GlobalStats.Instance.TS1 = GlobalStats.Activity.None;
        GlobalStats.Instance.TS2 = GlobalStats.Activity.None;
        GlobalStats.Instance.TS3 = GlobalStats.Activity.None;
        GlobalStats.Instance.TS4 = GlobalStats.Activity.None;

        SceneManager.LoadScene("3_HomeTest");

    }
}
