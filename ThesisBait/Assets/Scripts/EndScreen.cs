using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text AmtFishCaught, PerKG;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateMoneyEarned()
    {
        //todo
    }

    public void DisplayEnd()
    {
        AmtFishCaught.text = Player.GetComponent<PlayerFishing>().FishAmt.ToString();
        PerKG.text = STATICPlayerStats.PhpPerKG.ToString();
    }
}
