using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmFishingTutorial : MonoBehaviour
{
    public GameObject MainFishTut;

    public List<GameObject> TutorialObjs = new List<GameObject>();

    float curStage;

    public GameObject GearTab,TabCont;

    public GameObject BaitTab, Predictions, Weather;

    public GameObject StartBtn;

  
    // Start is called before the first frame update
    void Start()
    {
        MainFishTut.SetActive(false);
        curStage = 1;
        
        foreach (GameObject G in TutorialObjs)
        {
            G.SetActive(false);
        }
        TutorialObjs[0].SetActive(true);
    }
        
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(curStage);
        CheckStage();
        AnyKey();
    }

    void CheckStage()
    {
        foreach (GameObject G in TutorialObjs)
        {
            if (G.name == curStage.ToString())
            {
                G.SetActive(true);
            }
            else
            {
                G.SetActive(false);
            }
        }
    }

    public void EndTutorial()
    {
        MainFishTut.SetActive(true);
        this.enabled = false; 
    }

    void AnyKey()
    {
        if (curStage < TutorialObjs.Count)
        {
            if (Input.anyKeyDown)
            {
                if(curStage != 2 && curStage != 4 && curStage != 5)
                {
                    
                    curStage++;
                }
                
            }
        }

        if (curStage == 2)
        {
            GearTab.SetActive(true);      
            if(TabCont.GetComponent<ChoosingGear>().ReturnActiveTab() == "Gear")
            {
                curStage++;
            }
        }

        if(curStage == 4)
        {
            if(GlobalStats.Instance.CurrentNet == GlobalStats.NetType.Rod)
            {
                curStage++;
            }
        }

        if (curStage == 5)
        {
            BaitTab.SetActive(true);
            if (TabCont.GetComponent<ChoosingGear>().ReturnActiveTab() == "Bait")
            {
                curStage++;
            }
        }

        if (curStage == 7)
        {
            Predictions.SetActive(true);
            Weather.SetActive(true);
        }

        if(curStage == 8)
        {
            StartBtn.SetActive(true);
        }
    }
}
