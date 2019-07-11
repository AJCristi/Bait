using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public GameObject Quest, None;

    bool HasQuest;

    public Text Description, DueDate, ReqMoney;

    public AudioClip Complete;

    // Start is called before the first frame update
    void Start()
    {
        HasQuest = false;
        StartQuest();
    }

    // Update is called once per frame
    void Update()
    {       
        switch(HasQuest)
        {
            case true:
                Quest.SetActive(true);
                None.SetActive(false);
                DisplayQuest();
                break;

            case false:
                Quest.SetActive(false);
                None.SetActive(true);
                break;
        }


    }

    void StartQuest()
    {
        if (GlobalStats.Instance.ActiveEvent == null)
        {
            Debug.Log("Started");
            foreach (DataEvent Ev in GlobalStats.Instance.EventsList)
            {
                Debug.Log(Ev.name +" -- " + Ev.StartMonth + "/" + Ev.StartDay);

                if (Ev.StartMonth == GlobalStats.Instance.Month &&
                    Ev.StartDay == GlobalStats.Instance.Day && Ev.Completed == false)
                {
                    
                    GlobalStats.Instance.ActiveEvent = Ev;
                    HasQuest = true;
                    break;
                }
            }
        }
        else
        {
            HasQuest = true;
        }
    }

    void DisplayQuest()
    {
        Description.text = GlobalStats.Instance.ActiveEvent.Description;
        DueDate.text = GlobalStats.Instance.ActiveEvent.DaysRemaining.ToString();
        ReqMoney.text = GlobalStats.Instance.ActiveEvent.MoneyRequirement.ToString();

    }     

    public void TurnInQuest()
    {
        SFXcontroller.instance.PlaySingle(Complete);
        if (GlobalStats.Instance.PlayerSavings >= GlobalStats.Instance.ActiveEvent.MoneyRequirement)
        {
             if (GlobalStats.Instance.ActiveEvent.DaysRemaining >= 0)
             {
                Debug.Log("Turn in");
                GlobalStats.Instance.PlayerSavings -= GlobalStats.Instance.ActiveEvent.MoneyRequirement;
                //GlobalStats.Instance.EventsList.RemoveAt(0);
                GlobalStats.Instance.ActiveEvent.Completed = true;
                GlobalStats.Instance.ActiveEvent = null;
                HasQuest = false;
             }
        }
    }
}
