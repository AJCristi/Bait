using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputationTutorial : MonoBehaviour
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
        if (GameObject.Find("FishingMain").GetComponent<FishingScene>().started == true)
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

            if (Input.anyKeyDown)
            { 
                if(Stage != 3 && Stage != 4)
                    Stage++;               
            }
        }

        if (Stage == 3)
        {
            if (GameObject.Find("FishingMain").GetComponent<FishingScene>().curStatus ==
                FishingScene.FishingStatus.Done)
            {              
                Stage++;   
            }
        }

        if(Stage == 4)
        {
            Screens[3].SetActive(true);            
        }
    }
}
