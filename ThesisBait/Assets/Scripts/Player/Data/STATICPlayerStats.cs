using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class STATICPlayerStats
{
    private static float money;

    public static float Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }

    public static bool TrawlUnlocked = true;
    public static bool CastUnlocked = true  ;

    
}
