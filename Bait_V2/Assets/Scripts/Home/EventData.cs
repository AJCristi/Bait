using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "New Event", order = 51)]
public class EventData : ScriptableObject
{
    [SerializeField]
    private string title;
    [SerializeField]
    private string description;

    public bool IsRandom;

    [SerializeField]
    private float Trmonth, TRday;
    public enum Type
    {
        Payment,
        Happiness,
        Hunger
    }
    [SerializeField]
    private Type thisEvent;

    public float HappinessPlus;
    public float HungerPlus;

    public float HappinessMinus;
    public float HungerMinus;

    public float moneyPay;

    public void OnYes()
    {
        Debug.Log(thisEvent);
        switch (thisEvent)
        {
            case Type.Happiness:
                GlobalStats.Instance.DaughterHappiness += HappinessPlus;
                GlobalStats.Instance.WifeHappiness += HappinessPlus;       
                break;

            case Type.Payment:
                GlobalStats.Instance.PlayerSavings -= moneyPay;
                break;

            case Type.Hunger:
                GlobalStats.Instance.PlayerSavings -= HungerMinus;
                break;
        }        
    }

    public void OnNo()
    {
        Debug.Log(thisEvent);
        switch (thisEvent)
        {
            case Type.Happiness:
                GlobalStats.Instance.DaughterHappiness -= HappinessMinus;
                GlobalStats.Instance.WifeHappiness -= HappinessMinus;
                break;

            case Type.Payment:
                //
                break;

            case Type.Hunger:
                GlobalStats.Instance.PlayerSavings += HungerPlus;;
                break;
        }        
    }

    public string Title
    {
        get
        {
            return title;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public Type ThisEvent
    {
        get
        {
            return thisEvent;
        }
    }

    public bool CheckDate(float m, float d)
    {
        if(m == Trmonth && d == TRday)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
