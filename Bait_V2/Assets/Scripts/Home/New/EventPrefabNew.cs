using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "New Event", order = 51)]
public class EventPrefabNew : ScriptableObject
{
    public string Description;

    public int StartMonth, StartDay;

    public int DaysRemaining;

    public float MoneyRequirement;
   
}
