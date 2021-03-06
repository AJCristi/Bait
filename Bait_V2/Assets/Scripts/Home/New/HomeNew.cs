﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeNew : MonoBehaviour
{
    public Text Date;

    public GameObject Bills, Score;

    enum Tab
    {
        Score,
        Bills
    }
    Tab Active;

    public Text BeforeMoneyTxt, BillTxt, FoodTxt, MoneyText;

    public Text CashPerDay,CashRate;
    float CPD,Rate;

    public Text HighestCPD;

    float beforeMoney, bills, food;

    bool subtracted;

    public Text TTFishCaught, TTMoneyEarned, TTDays;

    public AudioClip Next, SleepSfx;

    // Start is called before the first frame update
    void Start()
    {
        subtracted = false;
        Active = Tab.Bills;
        Bills.SetActive(false);
        Score.SetActive(false);

        CalculateRate();
        GlobalStats.Instance.CheckHighestEarnings();

        beforeMoney = GlobalStats.Instance.PlayerSavings;

        //Date.text = GlobalStats.Instance.Month.ToString() + "/" + GlobalStats.Instance.Day.ToString();
        Date.text = "Day " + GlobalStats.Instance.DisplayDay.ToString();
        bills = 200;
        food = 300;

        
    }

    // Update is     called once per frame
    void Update()
    {
        switch (Active)
        {
            case Tab.Score:
                Bills.SetActive(false);
                Score.SetActive(true);
                break;

            case Tab.Bills:
                Bills.SetActive(true);
                Score.SetActive(false);
                break;
        }

        
        BillsUI();
        ScoreUI();

        if (!subtracted)
        {
            GlobalStats.Instance.PlayerSavings -= bills + food;
            
            subtracted = true;
        }
        


        MoneyText.text = GlobalStats.Instance.PlayerSavings.ToString();
        if(GlobalStats.Instance.PlayerSavings > 0)
        {
            MoneyText.color = Color.green;
        }
        else if(GlobalStats.Instance.PlayerSavings == 0)
        {
            MoneyText.color = Color.yellow;
        }
        else if(GlobalStats.Instance.PlayerSavings < 0)
        {
            MoneyText.color = Color.red;
        }

    }

    void ScoreUI()
    {
        TTFishCaught.text = GlobalStats.Instance.TotalFishCaught.ToString("F2");
        TTMoneyEarned.text = GlobalStats.Instance.TotalMoneyEarned.ToString("F2");
        TTDays.text = GlobalStats.Instance.TotalDaysPassed.ToString();

        CPD = GlobalStats.Instance.PerDayEarning;
        CashPerDay.text = CPD.ToString("F2");

        HighestCPD.text = GlobalStats.Instance.HighestEarnings.ToString("F2");
        CashRate.text = Rate.ToString() + "%";


    }

    void BillsUI()
    {
        BeforeMoneyTxt.text = beforeMoney.ToString("F2");
        BillTxt.text = bills.ToString();
        FoodTxt.text = food.ToString();
    }

    void CalculateRate()
    {
        Rate = 0;
        Debug.Log("Yester -- " + GlobalStats.Instance.YesterdayEarning.ToString());
        Debug.Log("Tod -- " + GlobalStats.Instance.PerDayEarning.ToString());

        if (GlobalStats.Instance.YesterdayEarning > GlobalStats.Instance.PerDayEarning)
        {
            float dec = GlobalStats.Instance.YesterdayEarning - GlobalStats.Instance.PerDayEarning;
            float decPer = dec / GlobalStats.Instance.YesterdayEarning * 100;

            CashRate.color = Color.red;
            Rate = decPer;
        }
        else if (GlobalStats.Instance.YesterdayEarning < GlobalStats.Instance.PerDayEarning)
        {
            float inc = GlobalStats.Instance.PerDayEarning - GlobalStats.Instance.YesterdayEarning;
            float incPer = inc / GlobalStats.Instance.YesterdayEarning * 100;

            CashRate.color = Color.green;
            Rate = incPer;
        }

        else
        {
            CashRate.color = Color.yellow;
            Rate = 0;
        }
    }

    public void BillsTab()
    {
        SFXcontroller.instance.PlaySingle(Next);
        Active = Tab.Bills;
    }

    public void ScoreTab()
    {
        SFXcontroller.instance.PlaySingle(Next);
        Active = Tab.Score;
    }

    public void Sleep()
    {
       

        SFXcontroller.instance.PlaySingle(SleepSfx);
        GlobalStats.Instance.AdvanceDay();
        GlobalStats.Instance.CheckWin();
        GlobalStats.Instance.EventMinusDay();
        CheckWin();
        GlobalStats.Instance.UpdateRate();

        GlobalStats.Instance.PerDayEarning = 0;  

        GlobalStats.Instance.CurTime = 5;
        GlobalStats.Instance.RandomForecast();
        GlobalStats.Instance.MarketDecide();
    }

    void CheckWin()
    {
        if(GlobalStats.Instance.DisplayDay > 14)
        {
            LoadingScreen.Instance.LoadScene("5_Credits");
        }
        else
        {
            CheckLose();
        }
    }

    void CheckLose()
    {
        
        if (GlobalStats.Instance.PlayerSavings <= 0)
        {
            Debug.Log("CheckLose");
            if (GlobalStats.Instance.BreadAmt <= 0 &&
                GlobalStats.Instance.InsectAmt <= 0 &&
                GlobalStats.Instance.WormAmt <= 0)
            {
                Debug.Log("No more bait");
                LoadingScreen.Instance.LoadScene("0_GameOver");
                return;
                //SceneManager.LoadScene("0_GameOver");
            }

            else
            {
                LoadingScreen.Instance.LoadScene("1_MapSelector");
                return;
            }
        }
        
        if (GlobalStats.Instance.ActiveEvent != null)
        {
            if (GlobalStats.Instance.ActiveEvent.DaysRemaining < 0)
            {
                Debug.Log("Event Loss");
                LoadingScreen.Instance.LoadScene("0_GameOver");
                //SceneManager.LoadScene("0_GameOver");
            }
            else
                LoadingScreen.Instance.LoadScene("1_MapSelector");
            //SceneManager.LoadScene("1_MapSelector");
        }
        else
        {
            LoadingScreen.Instance.LoadScene("1_MapSelector");
            //SceneManager.LoadScene("1_MapSelector");
        }
               
    }
}
