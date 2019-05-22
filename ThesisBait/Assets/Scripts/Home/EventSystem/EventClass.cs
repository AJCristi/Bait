using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventClass : MonoBehaviour
{

    public float TriggerMonth, TriggerDay;
    public bool ClickedButton;

    Text TextBox;

    public string Description;

    public enum Type
    {
        Positive,
        Negative
    }
    public Type ThisType;        

    public bool ToDecreaseMoney;
    public float MoneyReq;

    public float IncDecAmountHappiness;
    public bool DaughterAffected, WifeAffected;

    

    // Start is called before the first frame update
    void Start()
    {
        TextBox = GameObject.Find("EventTextBox").GetComponent<Text>();
        ClickedButton = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
 
    public void EventButtonClick()
    {
        if (!ClickedButton)
        {
            if (ThisType == Type.Positive)
            {
                if (ToDecreaseMoney)
                {
                    if (GlobalStats.Instance.Savings >= MoneyReq)
                    {
                        GlobalStats.Instance.Savings -= MoneyReq;

                        ClickedButton = true;
                    }
                }
            }
        }
    }

    public void DidNotPick()
    {
        if(ThisType == Type.Negative)
        {
            if (DaughterAffected)
            {
                GlobalStats.Instance.HappinessDaughter -= 
                    IncDecAmountHappiness;
            }

            if(WifeAffected)
            {
                GlobalStats.Instance.HappinessWife -= 
                    IncDecAmountHappiness;
            }
        }
    }
}
