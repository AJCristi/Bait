using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public Text Savings,calcSavings,HaulTD;

    public Text ElecDisplay, WaterDisplay,PrevDisplay;

    bool calculated;
    // Start is called before the first frame update
    void Start()
    {
        calculated = false;
        DisplayBills();
        CalclateNewSavings();
    }

    // Update is called once per frame
    void Update()
    {
        HaulTD.text = "Haul today: " + GlobalStats.Instance.FishKG.ToString() + " kg's";
        Savings.text = "Savings: PHP " + GlobalStats.Instance.PlayerSavings.ToString();
        calcSavings.text = "PHP: " + GlobalStats.Instance.PlayerSavings.ToString();
    }

    void DisplayBills()
    {
        ElecDisplay.text = GlobalStats.Instance.ElectricityCost.ToString();
        WaterDisplay.text = GlobalStats.Instance.WaterCost.ToString();
        PrevDisplay.text = GlobalStats.Instance.PlayerSavings.ToString();
    }

    void CalclateNewSavings()
    {
        if(!calculated)
        {
            GlobalStats.Instance.PlayerSavings -= GlobalStats.Instance.ElectricityCost + GlobalStats.Instance.WaterCost;

            calculated = true;
        }
    }
}
