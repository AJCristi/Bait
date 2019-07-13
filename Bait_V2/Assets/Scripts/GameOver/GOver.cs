using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GOver : MonoBehaviour
{
    public Text MoneyEarned,FishCaught, HighestEarnings, AmtDays;

    public AudioClip GameOver, Return;

    // Start is called before the first frame update
    void Start()
    {
        SFXcontroller.instance.PlaySingle(GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        MoneyEarned.text = "You earned Php: " +
            GlobalStats.Instance.TotalMoneyEarned.ToString("F2") + " this time";

        FishCaught.text = "You caught "+ GlobalStats.Instance.TotalFishCaught.ToString("F2") + 
            "kgs this time";

        HighestEarnings.text = "Your highest cash per day was " + GlobalStats.Instance.HighestEarnings.ToString("F2");

        AmtDays.text = "You lasted " + GlobalStats.Instance.TotalDaysPassed + " Days";
    }

    public void ReturnToMainMenu()
    {
        SFXcontroller.instance.PlaySingle(Return);
        SceneManager.LoadScene("MainMenu");
    }
}
