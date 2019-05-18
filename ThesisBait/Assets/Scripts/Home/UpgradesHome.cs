using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradesHome : MonoBehaviour
{
    public GameObject Menu;

    public Text SpeedLvl;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        Menu.SetActive(true);
    }

    public void ReturnBtn()
    {
        Menu.SetActive(false);
    }
}//todo most upgrades
