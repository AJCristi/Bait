using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    public Image SunImage;
    public Text TimerTextDisplay;

    public GameObject EndScreen;

    public float TotalTime;
    float timeRatio, timeRemaining;

    string minutes;
    string seconds;

    public Text MonthTxt, DayTxt;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        SunImage.fillAmount = 1;
        timeRemaining = TotalTime;

        MonthTxt.text = GlobalStats.Instance.Month.ToString();
        DayTxt.text = GlobalStats.Instance.Day.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        SetCurrentTimeUI();

        timeRatio = timeRemaining / TotalTime;
        SunImage.fillAmount = timeRatio;

        CheckEnd();
    }

    void SetCurrentTimeUI()
    {
        timeRemaining -= Time.deltaTime;
        minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
        seconds = (timeRemaining % 60).ToString("00");

        TimerTextDisplay.text = minutes.ToString() + ":" + seconds.ToString();
    }

    void CheckEnd()
    {
        if (timeRemaining <= 0)
        {
            End();
        }
    }

    public void End()
    {
        EndScreen.GetComponent<EndScreen>().DisplayEnd();
        //Time.timeScale = 0;
    }
}
