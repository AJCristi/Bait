using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour
{
    public GameObject Quest, None;

    bool HasQuest;

    public Text Description, DueDate, ReqMoney;

    public AudioClip Complete;

    public Button Pay;

    int R;

    // Start is called before the first frame update
    void Start()
    {
        HasQuest = false;
        if (SceneManager.GetActiveScene().name != "4_HomeTutorial")
        {
            
            StartQuest();
            R = 0;
        }
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
            float x = Random.Range(0, 100);
            Debug.Log(x);

            if(x >=50)
            {
                Debug.Log("Started");

                //foreach (DataEvent Ev in GlobalStats.Instance.EventsList)
                //{
                //    Debug.Log(Ev.name +" -- " + Ev.StartMonth + "/" + Ev.StartDay);

                //    if (Ev.StartMonth == GlobalStats.Instance.Month &&
                //        Ev.StartDay == GlobalStats.Instance.Day && Ev.Completed == false)
                //    {

                //        GlobalStats.Instance.ActiveEvent = Ev;
                //        HasQuest = true;
                //        break;
                //    }
                //}

                foreach (DataEvent Ev in GlobalStats.Instance.EventsList)
                {
                    Debug.Log(Ev.name + " -- " + Ev.StartMonth + "/" + Ev.StartDay);
                }
                ChooseRandom();
                GlobalStats.Instance.ActiveEvent =
                    GlobalStats.Instance.EventsList[R];

                HasQuest = true;
            }

            else
            {
                HasQuest = false;
            }

        }
        else
        {
            HasQuest = true;
        }
    }

    void ChooseRandom()
    {
        R = Random.Range(0, GlobalStats.Instance.EventsList.Count);
        Debug.Log(R +" -- " + GlobalStats.Instance.EventsList.Count);
    }

    void DisplayQuest()
    {
        Description.text = GlobalStats.Instance.ActiveEvent.Description;
        DueDate.text = GlobalStats.Instance.ActiveEvent.DaysRemaining.ToString();
        ReqMoney.text = GlobalStats.Instance.ActiveEvent.MoneyRequirement.ToString();

        if(GlobalStats.Instance.PlayerSavings < GlobalStats.Instance.ActiveEvent.MoneyRequirement)
        {
            Pay.interactable = false;
        }
        else
        {
            Pay.interactable = true;
        }
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
                //GlobalStats.Instance.ActiveEvent.Completed = true;
                GlobalStats.Instance.ActiveEvent = null;
                HasQuest = false;
                GlobalStats.Instance.ResetAllEvents();
             }
        }
    }
}
