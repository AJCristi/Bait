using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalUI : MonoBehaviour
{
    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SetGame()
    {
        GlobalStats.Instance.CurTime = 5;
        GlobalStats.Instance.RandomForecast();
        GlobalStats.Instance.MarketDecide();
    }

    public void Reset()
    {
        GlobalStats.Instance.TotalMoneyEarned = 0;
        GlobalStats.Instance.TotalFishCaught = 0;
        GlobalStats.Instance.TotalDaysPassed = 0;

        GlobalStats.Instance.Month = 7;
        GlobalStats.Instance.Day = 1;
        GlobalStats.Instance.CurTime = 5;

        GlobalStats.Instance.PlayerSavings = 500;

        GlobalStats.Instance.smallKG = 0;
        GlobalStats.Instance.medKG = 0;
        GlobalStats.Instance.largeKG = 0;

        GlobalStats.Instance.BreadAmt = 50;
        GlobalStats.Instance.InsectAmt = 30;
        GlobalStats.Instance.WormAmt = 20;

        GlobalStats.Instance.TrawlingNetLevel = 1;
        GlobalStats.Instance.CastNetLevel = 1;
        GlobalStats.Instance.RodNetLevel = 1;

        GlobalStats.Instance.ActiveEvent = null;
        GlobalStats.Instance.ResetAllEvents();

    }
}
