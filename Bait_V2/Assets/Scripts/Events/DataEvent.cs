using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEvent : MonoBehaviour
{
    public string Description;
    public int StartMonth, StartDay;

    public int originalDays;
    public int DaysRemaining;
    public float MoneyRequirement;

    public bool Completed = false;
   
    public void ResetDates()
    {
        DaysRemaining = originalDays;
    }
}
