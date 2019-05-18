using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public float MoneyEarned;
    public float Savings;
    public bool TrawlUnlocked;
    public bool CastUnlocked;

    public float Month, Day;

    public enum Rudder
    {
        P1,
        P2,
        P3
    }
    public Rudder CurRudderLvl = Rudder.P1;
    public float RudderFloat;

    public void AssignRudder()
    {
        switch (CurRudderLvl)
        {
            case Rudder.P1:
                RudderFloat = 0.5f;
                break;

            case Rudder.P2:
                RudderFloat = 1f;
                break;

            case Rudder.P3:
                RudderFloat = 2f;
                break;
        }
    }

    public void UpgradeRPM()
    {
        if (CurRudderLvl == Rudder.P1)
        {
            CurRudderLvl = Rudder.P2;
        }
        else if(CurRudderLvl == Rudder.P2)
        {
            CurRudderLvl = Rudder.P3;
        }
        else
        {
            CurRudderLvl = Rudder.P3;
        }
    }
}
