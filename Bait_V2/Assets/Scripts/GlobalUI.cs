using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalUI : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
    }

    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void StartMenu(GameObject Menu)
    {
        Menu.SetActive(true);
    }

    public void SetGame()
    {
        GlobalStats.Instance.CurTime = 5;
        GlobalStats.Instance.RandomForecast();
        GlobalStats.Instance.MarketDecide();
    }

    public void SetTutorialStats()
    {
        Reset();
        SetGame();
        GlobalStats.Instance.PlayerSavings = 100;

        GlobalStats.Instance.BreadAmt = 50;
        GlobalStats.Instance.InsectAmt = 0;
        GlobalStats.Instance.WormAmt = 0;

        GlobalStats.Instance.RodPieces = 20;
        GlobalStats.Instance.CastPieces = 0;
        GlobalStats.Instance.TrawlPieces = 0;

        GlobalStats.Instance.CurStage = GlobalStats.MapTutorialStage.S1;
        SceneManager.LoadScene("1_MapSelectorTutorial");
    }

    public void Reset()
    {
        GlobalStats.Instance.TotalMoneyEarned = 0;
        GlobalStats.Instance.TotalFishCaught = 0;
        GlobalStats.Instance.TotalDaysPassed = 0;

        GlobalStats.Instance.PerDayEarning = 0;
        GlobalStats.Instance.YesterdayEarning = 0;
        GlobalStats.Instance.HighestEarnings = 0;

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

        GlobalStats.Instance.RodPieces = 20;
        GlobalStats.Instance.CastPieces = 5;
        GlobalStats.Instance.TrawlPieces = 3;

        GlobalStats.Instance.PerDayEarning = 0;

        GlobalStats.Instance.UpdateRate();

        GlobalStats.Instance.ActiveEvent = null;
        GlobalStats.Instance.ResetAllEvents();

    }
}
