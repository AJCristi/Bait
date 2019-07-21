using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmFishingTutorial : MonoBehaviour
{
    public GameObject MainFishTut;

    public ChoosingGear CG;

    public List<GameObject> TutorialObjs = new List<GameObject>();

    float curStage;

    public GameObject GearTab,TabCont,ReturnBtn;

    public GameObject BaitTab, Predictions, Weather;

    public GameObject StartBtn, Selection, Hider, Hours;
        
    public AudioClip Next;
  
    // Start is called before the first frame update
    void Start()
    {
        
        MainFishTut.SetActive(false);
        curStage = 1;
        Hider.SetActive(true);

        BaitTab.GetComponent<Button>().interactable = false;

        foreach (GameObject G in TutorialObjs)
        {
            G.SetActive(false);
        }
        if (GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S1)
        {
            TutorialObjs[0].SetActive(true);
        }
        else
        {
            Debug.Log("xd");
            GearTab.SetActive(true);
            TabCont.SetActive(true);

            BaitTab.GetComponent<Button>().interactable = true;


            Predictions.SetActive(true);
            Selection.SetActive(true);
            Weather.SetActive(true);

            StartBtn.SetActive(true);
            BaitTab.SetActive(true);

            Hider.SetActive(false);

            Hours.SetActive(true);
        }

        if(GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S3)
            ReturnBtn.SetActive(true);


    }

    public void ReturnTutorial()
    {
        SceneManager.LoadScene("1_MapSelectorTutorial4");
    }
        
    // Update is called once per frame
    void Update()
    {
        if (GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S1)
        {
            //Debug.Log(curStage);
            CheckStage();
            AnyKey();
        }
        Debug.Log(curStage);
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
                if(curStage != 2 && curStage != 5 && curStage != 6
                    && curStage != 7)
                {
                    SFXcontroller.instance.PlaySingle(Next);
                    curStage++;
                }
                
            }
        }

        if (curStage == 2)
        {
            GearTab.SetActive(true);
           
            if(TabCont.GetComponent<ChoosingGear>().ReturnActiveTab() == "Gear")
            {
                Hider.SetActive(false);
                SFXcontroller.instance.PlaySingle(Next);
                curStage++;
            }
        }

        if (curStage == 5)
        {
            //BaitTab.SetActive(true);
            Hider.SetActive(false);
            if(CG.ReturnTempGear() == "Rod")
            {
                SFXcontroller.instance.PlaySingle(Next);
                curStage++;
            }           
        }

        if(curStage == 6)
        {
           
            Selection.SetActive(true);
            if (CG.ReturnTempGear() != "Rod")
            {
                curStage = 5;
            }

            if(GlobalStats.Instance.CurrentNet == GlobalStats.NetType.Rod)
            {
                SFXcontroller.instance.PlaySingle(Next);
                curStage++;
            }
        }

        if (curStage == 7)
        {
            Hider.SetActive(true);
           
            BaitTab.GetComponent<Button>().interactable = true;
            

            if (TabCont.GetComponent<ChoosingGear>().ReturnActiveTab() == "Bait")
            {
                SFXcontroller.instance.PlaySingle(Next);
                curStage++;
            }
        }

        if(curStage == 8)
        {
            Hider.SetActive(false);
            GearTab.GetComponent<Button>().interactable = false;


            
        }

        if(curStage == 9)
        {
            Weather.SetActive(true);
            Predictions.SetActive(true);
        }

        if(curStage == 10)
        {
            Hours.SetActive(true);
            StartBtn.SetActive(true);
        }
    }
}
