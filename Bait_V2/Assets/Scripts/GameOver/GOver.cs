using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GOver : MonoBehaviour
{
    public Text MoneyEarned,FishCaught;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoneyEarned.text = "You earned Php: " +
            GlobalStats.Instance.TotalMoneyEarned.ToString() + " this time";

        FishCaught.text = "You caught "+ GlobalStats.Instance.TotalFishCaught.ToString() + 
            "kgs this time";
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
