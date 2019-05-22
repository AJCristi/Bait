using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventHome : MonoBehaviour
{
    public Text Month, Day;
    public GameObject EventArea;
    EventClass EventObj;

    public List<EventClass> Events = new List<EventClass>();
    bool eventTriggered;

    public Text WifeHappiness, DaughtHappiness;

    // Start is called before the first frame update
    void Start()
    {
        eventTriggered = false;
        EventArea.SetActive(false);

        Month.text = GlobalStats.Instance.Month.ToString();
        Day.text = GlobalStats.Instance.Day.ToString();

        WifeHappiness.text = GlobalStats.Instance.HappinessWife.ToString();
        DaughtHappiness.text = GlobalStats.Instance.HappinessDaughter.ToString();

        EventObj = null;       
        CheckDate();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventTriggered)
        {
            EventArea.SetActive(true);
            if(!EventObj.ClickedButton)
                EventArea.transform.GetChild(1).GetComponent<Button>().
                onClick.AddListener(EventObj.EventButtonClick);



            EventArea.transform.GetChild(0).GetComponent<Text>().text =
                EventObj.Description;

            if(EventObj.ClickedButton)
            {
                EventArea.transform.GetChild(1).GetComponent<Button>().interactable = false;
            }
        }
    }

    void CheckDate()
    {
        foreach(EventClass x in Events)
        {
            if (x.TriggerMonth == GlobalStats.Instance.Month &&
                x.TriggerDay == GlobalStats.Instance.Day)
            {                
                EventObj = x;
                eventTriggered = true;
                break;
            }
        }
    }

    public void NextDay()
    {
        GlobalStats.Instance.AdvanceDay();
        SceneManager.LoadScene("TestEnviro");
        //todo replace
    }
}
