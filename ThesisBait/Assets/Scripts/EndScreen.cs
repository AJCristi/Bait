using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Text AmtFishCaught, PerKG;
    public Text MoneyEarnAmt;
    float moneyEarned;

    GameObject Player;

    GameObject screen;

    public string NextScene;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        screen = gameObject.transform.GetChild(0).gameObject;
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateMoneyEarned()
    {
        moneyEarned = Player.GetComponent<PlayerFishing>().FishAmt * 
            STATICPlayerStats.PhpPerKG;

        MoneyEarnAmt.text = "PHP: " + moneyEarned.ToString();

        GlobalStats.Instance.MoneyEarned += moneyEarned;

    }

    public void DisplayEnd()
    {
        screen.SetActive(true);
        AmtFishCaught.text = Player.GetComponent<PlayerFishing>().FishAmt.ToString();
        //PerKG.text = STATICPlayerStats.PhpPerKG.ToString();
        PerKG.text = STATICPlayerStats.PhpPerKG.ToString();

        CalculateMoneyEarned();
        Time.timeScale = 0;
    }

    public void DoneButton()
    {
        SceneManager.LoadScene(NextScene);
    }
}
