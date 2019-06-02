using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public Text Savings,calcSavings;

    public Text ElecDisplay, WaterDisplay,PrevDisplay;

    bool calculated;

    public GameObject SleepBtn;
    public bool FoodDone, EventDone;

    // Start is called before the first frame update
    void Start()
    {
        calculated = false;
        DisplayBills();
        CalclateNewSavings();
        FoodDone = false;
        EventDone = false;
        SleepBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        Savings.text = "Savings: PHP " + GlobalStats.Instance.PlayerSavings.ToString();
        calcSavings.text = "PHP: " + GlobalStats.Instance.PlayerSavings.ToString();
        Debug.Log(EventDone + " - " + FoodDone);
        if (EventDone && FoodDone)
        {
            
            SleepBtn.SetActive(true);
        }
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
