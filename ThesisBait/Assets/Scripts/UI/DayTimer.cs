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

    // Start is called before the first frame update
    void Start()
    {
        SunImage.fillAmount = 1;
        timeRemaining = TotalTime;        
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            EndScreen.GetComponent<EndScreen>().DisplayEnd();
        }


        if (timeRemaining <= 0)
        {
            EndScreen.GetComponent<EndScreen>().DisplayEnd();
            
        }
    }
}
