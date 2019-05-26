using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishingScene : MonoBehaviour
{
    public GameObject ConfirmationScreen;

    public Text TimerTxt;
    public Image TimerImage;

    public float TimeLeft;
    float timeRatio, timeRemaining;

    string minutes;
    string seconds;

    bool started;

    float x;
    float y;
    bool FF;

    public Button Done;

    public Text StatusTxt;


    public enum FishingStatus
    {
        Moving,
        Fishing,
        Returning,
        Running,
        Done
    }
    public FishingStatus curStatus;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        timeRemaining = TimeLeft;
        FF = false;
        x = 0;
        y = 0;
    }

    void StatusTextUpdate()
    {
        switch(curStatus)
        {
            case FishingStatus.Done:
                StatusTxt.text = "Returned";
                break;

            case FishingStatus.Fishing:
                StatusTxt.text = "Fishing at the spot";
                break;

            case FishingStatus.Moving:
                StatusTxt.text = "Travelling";
                break;

            case FishingStatus.Returning:
                StatusTxt.text = "Heading Home";
                break;

            case FishingStatus.Running:
                StatusTxt.text = "Running away";
                break;
        }
    }

    public void FastForward()
    {
        FF = !FF;
    }

    // Update is called once per frame
    void Update()
    {        
        if (started)
        {
            timeRatio = timeRemaining / TimeLeft;
            TimerImage.fillAmount = timeRatio;
            SetCurrentTimeUI();
            CheckStatus();
            StatusTextUpdate();
           
            if (FF)
            {
                Time.timeScale = 5;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        else
        {
           
            TimerTxt.text = "0:00";
        }

        if (curStatus == FishingStatus.Done)
        {
            Done.interactable = true;
            Time.timeScale = 1;
        }
        else
        {
            Done.interactable = false;
        }
    }

    void SetCurrentTimeUI()
    {
        timeRemaining -= Time.deltaTime;
        minutes = Mathf.Floor(timeRemaining / 60).ToString("00");
        seconds = (timeRemaining % 60).ToString("00");
        TimerTxt.text = minutes.ToString() + ":" + seconds.ToString();       
    }

    public void Started()
    {
        ConfirmationScreen.SetActive(false);
        started = true;
    }

    void CheckStatus()
    {
        // todo add BoatSpdLvl
        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.SandyShoals:
                CalculateStatus(5, 5);
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                CalculateStatus(15, 15);
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                CalculateStatus(10, 10);
                break;
        }
    }

    void CalculateStatus(float GoingTime, float ComingTime)
    {
        float z = TimeLeft - ComingTime;

        if (timeRemaining > 0)
        {
            if (y <= z)
            {
                y += Time.deltaTime;
                if (x <= GoingTime)
                {
                    x += Time.deltaTime;
                    curStatus = FishingStatus.Moving;
                }
                else
                {
                    curStatus = FishingStatus.Fishing;
                }
            }
            else
            {
                curStatus = FishingStatus.Returning;
            }
        }
        else
        {
            curStatus = FishingStatus.Done;
            started = false;
        }
    }
}
