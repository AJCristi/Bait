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
        SmallRate.text = "Small / Kg -- " + GlobalStats.Instance.smallFishPerKG.ToString();
        MedRate.text = "Meduim / Kg -- " + GlobalStats.Instance.medFishPerKG.ToString();
        LargeRate.text = "Large / Kg -- " + GlobalStats.Instance.largeFishPerKG.ToString();

        SmallHaul.text = GlobalStats.Instance.smallKG.ToString() + " kgs";
        MedHaul.text = GlobalStats.Instance.medKG.ToString() + " kgs";
        LargeHaul.text = GlobalStats.Instance.largeKG.ToString() + " kgs";

        Compute();
        Earnings.text = "Earnings -- PHP " + totalearning.ToString();
    }

    void Compute()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        x = GlobalStats.Instance.smallKG * GlobalStats.Instance.smallFishPerKG;
        y = GlobalStats.Instance.medKG * GlobalStats.Instance.medFishPerKG;
        x = GlobalStats.Instance.largeKG * GlobalStats.Instance.largeFishPerKG;

        totalearning = x + y + z;
    }

    public void Sell()
    {
        GlobalStats.Instance.smallKG = 0;
        GlobalStats.Instance.medKG = 0;
        GlobalStats.Instance.largeKG = 0;
        GlobalStats.Instance.PlayerSavings += totalearning;
    }
}
