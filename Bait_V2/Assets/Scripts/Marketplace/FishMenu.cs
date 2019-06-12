using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishMenu : MonoBehaviour
{
    public Text SmallRate, MedRate, LargeRate;
    public Text SmallHaul, MedHaul, LargeHaul;

    public Text Earnings;
    float totalearning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalStats.Instance.smallKG > 0)
        {
            SmallHaul.enabled = true;
        }
        else
        {
            SmallHaul.enabled = false;
        }

        if (GlobalStats.Instance.medKG > 0)
        {
            MedHaul.enabled = true;
        }
        else
        {
            MedHaul.enabled = false;
        }

        if (GlobalStats.Instance.largeKG > 0)
        {
            LargeHaul.enabled = true;
        }
        else
        {
            LargeHaul.enabled = false;
        }

        SmallRate.text = "Galunggong / Kg -- " + GlobalStats.Instance.smallFishPerKG.ToString();
        MedRate.text = "Tilapia / Kg -- " + GlobalStats.Instance.medFishPerKG.ToString();
        LargeRate.text = "Lapu-Lapu / Kg -- " + GlobalStats.Instance.largeFishPerKG.ToString();

        SmallHaul.text = GlobalStats.Instance.smallKG.ToString("F2") + " kgs";
        MedHaul.text = GlobalStats.Instance.medKG.ToString("F2") + " kgs";
        LargeHaul.text = GlobalStats.Instance.largeKG.ToString("F2") + " kgs";

        Compute();
        Earnings.text = "Earnings -- PHP " + totalearning.ToString();
    }

    void Compute()
    {
        float x;
        float y;
        float z;

        x = GlobalStats.Instance.smallKG * GlobalStats.Instance.smallFishPerKG;
        y = GlobalStats.Instance.medKG * GlobalStats.Instance.medFishPerKG;
        z = GlobalStats.Instance.largeKG * GlobalStats.Instance.largeFishPerKG;        


        totalearning = x + y + z;
        
    }

    public void Sell()
    {
        GlobalStats.Instance.smallKG = 0;
        GlobalStats.Instance.medKG = 0;
        GlobalStats.Instance.largeKG = 0;
        GlobalStats.Instance.PlayerSavings += totalearning;
        GlobalStats.Instance.TotalMoneyEarned += totalearning;

    }
}
