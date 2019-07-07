using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndNotif : MonoBehaviour
{
    public Text TotalKGCaught, AmtBaitUsed, AmtGearLost;

    float TotalKG, BaitUsed;

    int GearLost;

    // Start is called before the first frame update
    void Start()
    {
        TotalKG = 0;
        BaitUsed = 0;
        GearLost = 0;
    }

    public void TotalKGAdd(float x, float y, float z)
    {
        TotalKG = x + y + z;
    }

    public void AddBait(float x)
    {
        BaitUsed += x;
    }

    public void LostGear(int x)
    {
        GearLost += x;
    }

    // Update is called once per frame
    void Update()
    {
        TotalKGCaught.text = TotalKG.ToString() + " Kgs";

        AmtBaitUsed.text = BaitUsed.ToString() + " Used";
        AmtGearLost.text = GearLost.ToString() + " Lost";
    }
}
