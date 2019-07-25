using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Text TotalEarnings, TotalKGs, HighestCPD;

    public Text LevelAchieved;

    public Image Medal;
    public Sprite B, S, G, P;

    public AudioClip Success, NextSFX;

    enum Level
    {
        Passed,
        Bronze,
        Silver,
        Gold,
        Platinum
    }

    Level AchievedLevel;

    // Start is called before the first frame update
    void Start()
    {
        CalculateLevel();
        SFXcontroller.instance.PlaySingle(Success);
    }

    // Update is called once per frame
    void Update()
    {
        TotalEarnings.text = GlobalStats.Instance.TotalMoneyEarned.ToString("F2");
        TotalKGs.text = GlobalStats.Instance.TotalFishCaught.ToString("F2") + " Kgs";
        HighestCPD.text = GlobalStats.Instance.HighestEarnings.ToString("F2");
    }

    public void Next()
    {
        //SceneManager.LoadScene("MainMenu");
        SFXcontroller.instance.PlaySingle(NextSFX);
        LoadingScreen.Instance.LoadScene("MainMenu");
    }

    void CalculateLevel()
    {
        if (GlobalStats.Instance.HighestEarnings > 0 &&
            GlobalStats.Instance.HighestEarnings <= 350)
        {
            AchievedLevel = Level.Passed;
        }

        else if (GlobalStats.Instance.HighestEarnings > 350 &&
            GlobalStats.Instance.HighestEarnings <= 600)
        {
            AchievedLevel = Level.Bronze;
        }

        else if (GlobalStats.Instance.HighestEarnings > 600 &&
            GlobalStats.Instance.HighestEarnings <= 1000)
        {
            AchievedLevel = Level.Silver;
        }

        else if (GlobalStats.Instance.HighestEarnings > 1000 &&
            GlobalStats.Instance.HighestEarnings <= 1300)
        {
            AchievedLevel = Level.Gold;
        }

        else if (GlobalStats.Instance.HighestEarnings > 1300)
        {
            AchievedLevel = Level.Platinum;
        }

        switch(AchievedLevel)
        {
            case Level.Passed:
                Medal.enabled = false;
                //Medal.sprite = null;
                LevelAchieved.text = "Passing grade achieved";
                break;

            case Level.Bronze:
                Medal.enabled = true;
                Medal.sprite = B;
                LevelAchieved.text = "Bronze medal achieved";
                break;

            case Level.Silver:
                Medal.enabled = true;
                Medal.sprite = S;
                LevelAchieved.text = "Silver medal achieved";
                break;

            case Level.Gold:
                Medal.enabled = true;
                Medal.sprite = G;
                LevelAchieved.text = "Gold medal achieved";
                break;

            case Level.Platinum:
                Medal.enabled = true;
                Medal.sprite = P;
                LevelAchieved.text = "Platinum medal achieved";
                break;

        }
    }
}
