using System.Collections;
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

        beforeMoney = GlobalStats.Instance.PlayerSavings;

        Date.text = GlobalStats.Instance.Month.ToString() + "/" + GlobalStats.Instance.Day.ToString();
        bills = 200;
        food = 300;

        CalculateRate();
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

    }

    void ScoreUI()
    {
        TTFishCaught.text = GlobalStats.Instance.TotalFishCaught.ToString();
        TTMoneyEarned.text = GlobalStats.Instance.TotalMoneyEarned.ToString();
        TTDays.text = GlobalStats.Instance.TotalDaysPassed.ToString();

        CPD = GlobalStats.Instance.PerDayEarning;
        CashPerDay.text = CPD.ToString();

        
        CashRate.text = Rate.ToString() + "%";


    }

    void BillsUI()
    {
        BeforeMoneyTxt.text = beforeMoney.ToString();
        BillTxt.text = bills.ToString();
        FoodTxt.text = food.ToString();
    }

    void CalculateRate()
    {
        Rate = 0;
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
        GlobalStats.Instance.EventMinusDay();

        if(GlobalStats.Instance.PlayerSavings <= 0)
        {
            if (GlobalStats.Instance.BreadAmt <= 0 && GlobalStats.Instance.InsectAmt <= 0 && 
                GlobalStats.Instance.WormAmt <= 0)
            {
                SceneManager.LoadScene("0_GameOver");
            }
        }
       
        if(GlobalStats.Instance.ActiveEvent != null)
        {
            if (GlobalStats.Instance.ActiveEvent.DaysRemaining < 0)
            {
                SceneManager.LoadScene("0_GameOver");
            }
            else
                SceneManager.LoadScene("1_MapSelector");
        }
        else
        {
            SceneManager.LoadScene("1_MapSelector");
        }
        GlobalStats.Instance.PerDayEarning = 0;

        GlobalStats.Instance.UpdateRate();
        GlobalStats.Instance.CheckHighestEarnings();

        GlobalStats.Instance.CurTime = 5;
        GlobalStats.Instance.RandomForecast();
        GlobalStats.Instance.MarketDecide();
    }
}
