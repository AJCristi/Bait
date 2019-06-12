using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketTutorial : MonoBehaviour
{
    public List<GameObject> Screens = new List<GameObject>();
    public int Stage;

    bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalStats.Instance.TS1 == GlobalStats.Activity.Fishing && 
            GlobalStats.Instance.TS2 == GlobalStats.Activity.Market && 
            GlobalStats.Instance.TS3 != GlobalStats.Activity.None)
        {
            foreach (GameObject G in Screens)
            {
                G.SetActive(false);
            }
            return;
        }
        foreach (GameObject G in Screens)
        {
            if (G.name == Stage.ToString())
            {
                G.SetActive(true);
            }
            else
            {
                G.SetActive(false);
            }
        }

        if (Input.anyKeyDown)
        {
            if(Stage != 4 && Stage != 7 && Stage != 8 && Stage != 12 && Stage != 13 && Stage != 9)
                Stage++;
        }

        if(Stage == 4)
        {
            if(pressed)
            {
                pressed = false;
                Stage++;
            }
        }

        if(Stage == 7)
        {
            if(GlobalStats.Instance.CurrentBait == GlobalStats.BaitType.Insects)
            {
                Stage++;
            }
        }

        if (Stage == 8)
        {
            if(GameObject.Find("MarketMenu").GetComponent<MarketMenu>().buyBaitAmt == 5)
            {
                Stage++;
            }
        }

        if(Stage == 9)
        {
            if(pressed)
            {
                pressed = false;
                Stage++;
            }
        }

        if(Stage == 12)
        {
            if (pressed)
            {
                pressed = false;
                Stage++;
            }
        }

    }

    public void Sold()
    {
        pressed = true;
    }
}
