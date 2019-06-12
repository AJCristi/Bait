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

    public bool started;

    float x;
    float y;
    bool FF;

    public Button Done;

    public Text StatusTxt;

    public Text Weather, WDes;

    public string SunnyDes, OverDes, RainDes;

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
        

        switch (GlobalStats.Instance.FuelTankLevel)
        {
            case 1:
                TimeLeft += 0;
                break;

            case 2:
                TimeLeft += 15;
                break;

            case 3:
                TimeLeft += 25;
                break;
        }


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
            Weather.text = GlobalStats.Instance.Forecast.ToString();

            switch (GlobalStats.Instance.Forecast)
            {
                case GlobalStats.Weather.Overcast:
                    WDes.text = OverDes;
                    break;

                case GlobalStats.Weather.Sunny:
                    WDes.text = SunnyDes;
                    break;

                case GlobalStats.Weather.Rainy:
                    WDes.text = RainDes;
                    break;
            }
            
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
                CalculateStatus(CheckTravel(1), CheckTravel(1));
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                CalculateStatus(CheckTravel(3), CheckTravel(3));
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                CalculateStatus(CheckTravel(2), CheckTravel(2));
                break;
        }
    }

    float CheckTravel(float area)
    {
        //1 = SS 2=LI 3=ER
        float x = 0;
        switch(GlobalStats.Instance.BoatSpdLvl)
        {
            case 1:
                switch(area)
                {
                    case 1:
                        x = 5f;
                        break;

                    case 2:
                        x = 3f;
                        break;

                    case 3:
                        x = 1.5f;
                        break;
                }
                break;

            case 2:
                switch (area)
                {
                    case 1:
                        x = 10f;
                        break;

                    case 2:
                        x = 7f;
                        break;

                    case 3:
                        x = 5f;
                        break;
                }
                break;

            case 3:
                switch (area)
                {
                    case 1:
                        x = 15f;
                        break;

                    case 2:
                        x = 11f;
                        break;

                    case 3:
                        x = 7f;
                        break;
                }
                break;
        }
        return x;
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
