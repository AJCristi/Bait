using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void UnlockTrawl()
    {
        TrawlUnlocked = true;
    }

    public bool CastUnlocked;
    public void UnlockCast()
    {
        CastUnlocked = true;
    }

    public float Month, Day;
    public void AdvanceDay()
    {
        if(Day <= 30)
        {
            Day++;
        }
        else
        {
            Month++;
            Day = 1;
        }
    }   

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

    public void UpgradeRudder()
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

    public string GetRudderLevel()
    {
        string x = null;
        switch( CurRudderLvl)
        {
            case Rudder.P1:
                x = "Level 1";
                break;

            case Rudder.P2:
                x = "Level 2";
                break;

            case Rudder.P3:
                x = "Level 3";
                break;
        }

        return x;
    }

    public enum Speed
    {
        P1,
        P2,
        P3
    }
    public Speed CurSpeedLvl = Speed.P1;
    public float SpeedFloat;

    public void AssignSpeed()
    {
        switch (CurSpeedLvl)
        {
            case Speed.P1:
                SpeedFloat = 1600f;
                break;

            case Speed.P2:
                SpeedFloat = 2100f;
                break;

            case Speed.P3:
                SpeedFloat = 2900f;
                break;
        }
    }

    public void UpgradeSpd()
    {
        if (CurSpeedLvl == Speed.P1)
        {
            CurSpeedLvl = Speed.P2;
        }
        else if (CurSpeedLvl == Speed.P2)
        {
            CurSpeedLvl = Speed.P3;
        }
        else
        {
            CurSpeedLvl = Speed.P3;
        }
    }

    public string GetSpeedLvl()
    {
        string x = null;
        switch (CurSpeedLvl)
        {
            case Speed.P1:
                x = "Level 1";
                break;

            case Speed.P2:
                x = "Level 2";
                break;

            case Speed.P3:
                x = "Level 3";
                break;
        }

        return x;
    }

    public enum HandheldNetLvl
    {
        L1,
        L2,
        L3
    }
    public HandheldNetLvl CurHandLvl = HandheldNetLvl.L1;
    public float HandFloat;

    public void AssignHandTime()
    {
        switch(CurHandLvl)
        {
            case HandheldNetLvl.L1:
                HandFloat = 8.0f;
                break;

            case HandheldNetLvl.L2:
                HandFloat = 5.5f;
                break;

            case HandheldNetLvl.L3:
                HandFloat = 2.5f;
                break;
        }
    }

    public void UpgradeHand()
    {
        if (CurHandLvl == HandheldNetLvl.L1)
        {
            CurHandLvl = HandheldNetLvl.L2;
        }
        else if (CurHandLvl == HandheldNetLvl.L2)
        {
            CurHandLvl = HandheldNetLvl.L3;
        }
        else
        {
            CurHandLvl = HandheldNetLvl.L3;
        }
    }

    public string GetHandLvl()
    {
        string x = null;
        switch (CurHandLvl)
        {
            case HandheldNetLvl.L1:
                x = "Level 1";
                break;

            case HandheldNetLvl.L2:
                x = "Level 2";
                break;

            case HandheldNetLvl.L3:
                x = "Level 3";
                break;
        }

        return x;
    }

    public enum TrawlNetLvl
    {
        L1,
        L2,
        L3
    }
    public TrawlNetLvl CurTrawlLvl = TrawlNetLvl.L1;
    public float TrawlFloat;

    public void AssignTrawlTime()
    {
        switch (CurTrawlLvl)
        {
            case TrawlNetLvl.L1:
                TrawlFloat = 5.0f;
                break;

            case TrawlNetLvl.L2:
                TrawlFloat = 3.5f;
                break;  

            case TrawlNetLvl.L3:
                TrawlFloat = 2.5f;
                break;
        }
    }

    public void UpgradeTrawl()
    {
        if (CurTrawlLvl == TrawlNetLvl.L1)
        {
            CurTrawlLvl = TrawlNetLvl.L2;
        }
        else if (CurTrawlLvl == TrawlNetLvl.L2)
        {
            CurTrawlLvl = TrawlNetLvl.L3;
        }
        else
        {
            CurTrawlLvl = TrawlNetLvl.L3;
        }
    }

    public string GetTrawlLvl()
    {
        string x = null;
        switch (CurTrawlLvl)
        {
            case TrawlNetLvl.L1:
                x = "Level 1";
                break;

            case TrawlNetLvl.L2:
                x = "Level 2";
                break;

            case TrawlNetLvl.L3:
                x = "Level 3";
                break;
        }

        return x;
    }

    public enum CastNetLvl
    {
        L1,
        L2,
        L3
    }
    public CastNetLvl CurCastLvl = CastNetLvl.L1;
    public float CastFloat;

    public void AssignCastTime()
    {
        switch (CurCastLvl)
        {
            case CastNetLvl.L1:
                CastFloat = 8f;
                break;

            case CastNetLvl.L2:
                CastFloat = 5f;
                break;

            case CastNetLvl.L3:
                CastFloat = 3f;
                break;
        }
    }

    public void UpgradeCast()
    {
        if (CurCastLvl == CastNetLvl.L1)
        {
            CurCastLvl = CastNetLvl.L2;
        }
        else if (CurCastLvl == CastNetLvl.L2)
        {
            CurCastLvl = CastNetLvl.L3;
        }
        else
        {
            CurCastLvl = CastNetLvl.L3;
        }
    }

    public string GetCastLvl()
    {
        string x = null;
        switch (CurCastLvl)
        {
            case CastNetLvl.L1:
                x = "Level 1";
                break;

            case CastNetLvl.L2:
                x = "Level 2";
                break;

            case CastNetLvl.L3:
                x = "Level 3";
                break;
        }

        return x;
    }

    public float HappinessWife, HappinessDaughter;

}
