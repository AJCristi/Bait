using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject BoughtText;

    public Text ChickenTxt, BeefTxt, VeggTxt, PorkTxt;
    public float ChickenPrice, BeefPrice, VeggPrice, PorkPrice;
    bool picked;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(true);
        BoughtText.SetActive(false);
        picked = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        ChickenTxt.text = "PHP: " + ChickenPrice.ToString();
        BeefTxt.text = "PHP: " + BeefPrice.ToString();
        VeggTxt.text = "PHP: " + VeggPrice.ToString();
        PorkTxt.text = "PHP: " + PorkPrice.ToString();

        if (picked)
        {
            GlobalStats.Instance.BoughtFood = true;
            
        }

        if (GlobalStats.Instance.BoughtFood)
        {
            Menu.SetActive(false);
            BoughtText.SetActive(true);
            BoughtText.GetComponent<Text>().text =
                "Your meal later is : " + GlobalStats.Instance.CurFood.ToString();
        }
    }

    public void Chicken()
    {
        if (GlobalStats.Instance.PlayerSavings >= ChickenPrice)
        {
            GlobalStats.Instance.PlayerSavings -= ChickenPrice;
            GlobalStats.Instance.CurFood = GlobalStats.FoodItems.Chicken;
            picked = true;
        }
    }

    public void Beef()
    {
        if (GlobalStats.Instance.PlayerSavings >= BeefPrice)
        {
            GlobalStats.Instance.PlayerSavings -= BeefPrice;
            GlobalStats.Instance.CurFood = GlobalStats.FoodItems.Beef;
            picked = true;
        }
    }

    public void Pork()
    {
        if (GlobalStats.Instance.PlayerSavings >= PorkPrice)
        {
            GlobalStats.Instance.PlayerSavings -= PorkPrice;
            GlobalStats.Instance.CurFood = GlobalStats.FoodItems.Pork;
            picked = true;
        }
    }

    public void Vegetables()
    {
        if (GlobalStats.Instance.PlayerSavings >= VeggPrice)
        {
            GlobalStats.Instance.PlayerSavings -= VeggPrice;
            GlobalStats.Instance.CurFood = GlobalStats.FoodItems.Vegetables;
            picked = true;
        }
    }
}
