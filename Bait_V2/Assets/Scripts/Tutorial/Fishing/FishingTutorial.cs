using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingTutorial : MonoBehaviour
{
    public List<GameObject> Screens = new List<GameObject>();    
    public int Stage;

    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalStats.Instance.TS1 == GlobalStats.Activity.Fishing && GlobalStats.Instance.TS2 == GlobalStats.Activity.Market)
        {
            foreach (GameObject G in Screens)
            {
                G.SetActive(false);
            }
            return;
        }

        if (Stage < 8)
        {
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
        }
        
        if (Input.anyKeyDown)
        {
            if(Stage != 4 && Stage != 5)
            {
                Stage++;
            }
        }

        if(Stage == 4)
        {           
            if(GlobalStats.Instance.CurrentNet == GlobalStats.NetType.Rod)
            {
                Stage++;
            }
        }

        if (Stage == 5)
        {
            if (GlobalStats.Instance.CurrentBait == GlobalStats.BaitType.Insects)
            {
                Stage++;
            }
        }

        if(GameObject.Find("FishingMain").GetComponent<FishingScene>().started == true)
        {
            foreach (GameObject G in Screens)
            {
                G.SetActive(false);
            }
        }
    }
}
