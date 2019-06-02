using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour
{
    public Text Title, Description;

    public List<EventData> EventsList = new List<EventData>();

    List<EventData> RandomEvents = new List<EventData>();
    List<EventData> SetEvents = new List<EventData>();

    EventData Chosen;

    float M, D;

    bool found;

    public GameObject EventsTab;

    public Text ToolTip;
    public string HappPlus, MoneyPlus, HungerPlus;
    public string HappMinus, MoneyMinus, HungerMinus;

    bool TTactive;
    bool positive;

    float x;
    // Start is called before the first frame update
    void Start()
    {
        found = false;
        M = GlobalStats.Instance.Month;
        D = GlobalStats.Instance.Day;
        SortEvents();
        FindEvent();

        ToolTip.enabled = false;
        EventsTab.SetActive(false);
        TTactive = false;

        positive = false;
        x = 0;
    }

    void SortEvents()
    {
        foreach (EventData Ev in EventsList)
        {
            if(Ev.IsRandom)
            {
                RandomEvents.Add(Ev);                
            }
            else
            {
                SetEvents.Add(Ev);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(found)
        {
            case true:
                EventsTab.SetActive(true);
                AssignUI();
                
                break;

            case false:
                EventsTab.SetActive(false);
                break;
        }

        if (TTactive)
        {
            GetComponent<Home>().EventDone = true;
            EventsTab.SetActive(false);
            x += Time.deltaTime;

            switch(Chosen.ThisEvent)
            {
                case EventData.Type.Happiness:
                    if(positive)
                    {
                        ToolTip.text = HappPlus;
                    }
                    else
                    {
                        ToolTip.text = HappMinus;
                    }
                    break;

                case EventData.Type.Hunger:
                    if (positive)
                    {
                        ToolTip.text = HungerPlus;
                    }
                    else
                    {
                        ToolTip.text = HungerMinus;
                    }
                    break;

                case EventData.Type.Payment:
                    if (positive)
                    {
                        ToolTip.text = MoneyPlus;
                    }
                    else
                    {
                        ToolTip.text = MoneyMinus;
                    }
                    break;
            }

            if (x > 2.5f)
            {
                ToolTip.enabled = false;                
            }
            else
                ToolTip.enabled = true;
        }
       
    }

    void FindEvent()
    {
        foreach (EventData Ev in SetEvents)
        {
            if (Ev.CheckDate(M, D))
            {
                Chosen = Ev;
                found = true;
                return;
            }
            Debug.Log("DO");
        }

        if (!found)
        {
            int x = Random.Range(0, RandomEvents.Count);
            float y = Random.Range(0, 100);
            Debug.Log(y);
            if (y >= 50)
            {
                Chosen = RandomEvents[x];
                found = true;
                return;
            }    
        }
    }

    void AssignUI()
    {
        if (Chosen != null)
        {
            Debug.Log("UI");
            Title.text = Chosen.Title;
            Description.text = Chosen.Description;
        }
    }

    public void NoButton()
    {
        Chosen.OnNo();
        positive = false;
        TTactive = true;
    }

    public void YesButton()
    {
        Chosen.OnYes();
        positive = true;
        TTactive = true;
    }
}
