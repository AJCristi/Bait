using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BillsHome : MonoBehaviour
{
    public Text Date;
    public Text SavingsAmount, MoneyEarned;    

    public float Bills;
    public Text BillsAmt;

    public float Food;
    public Text FoodsAmt;

    public Text TotalAmt;

    bool doneComputing;

    GameObject UpgradeMenu;

    

    // Start is called before the first frame update
    void Start()
    {
        doneComputing = false;

        AssignDate();

        SavingsAmount.text = "PHP: " + GlobalStats.Instance.Savings.ToString();
        MoneyEarned.text = "PHP : " + GlobalStats.Instance.MoneyEarned.ToString();
        BillsAmt.text = "PHP: -" + Bills.ToString();
        FoodsAmt.text = "PHP: -" + Food.ToString();
        UpgradeMenu = GameObject.Find("UpgradeMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(!doneComputing)
        {
            CalculateFinal();
        }
        TotalAmt.text = "PHP : " + GlobalStats.Instance.Savings.ToString();
    }

    void AssignDate()
    {
        Date.text = GlobalStats.Instance.Month.ToString() + "/" + GlobalStats.Instance.Day.ToString();
    }

    void CalculateFinal()
    {
        float x = GlobalStats.Instance.MoneyEarned - (Bills + Food);
        GlobalStats.Instance.Savings += x;
        TotalAmt.text = "PHP : " + GlobalStats.Instance.Savings.ToString();
        doneComputing = true;
    }

    public void UpgradeButton()
    {
        UpgradeMenu.GetComponent<UpgradesHome>().OpenMenu();
    }

    public void Next()
    {
        SceneManager.LoadScene("TestEnviroEvent");
    }
}
