using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewMarketTutorial : MonoBehaviour
{
    public TabController TB;

    public List<GameObject> TutorialObjs = new List<GameObject>();

    float curStage;

    public GameObject GearTab, BaitTab, FishTab;

    public GameObject StartBtn;

    public GameObject Hider;

    public AudioClip NextTut;

    public GameObject GearUpgradeBtn;
    Vector3 oldpos;
    // Start is called before the first frame update
    void Start()
    {
        curStage = 1;
        Hider.SetActive(true);
        foreach (GameObject G in TutorialObjs)
        {
            G.SetActive(false);
        }
        if (GlobalStats.Instance.CurStage != GlobalStats.MapTutorialStage.S3)
        {
            TutorialObjs[0].SetActive(true);
        }

        oldpos = GearUpgradeBtn.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S2)
        {
            CheckStage();
            AnyKey();
            //GearUpgradeBtn.GetComponent<Button>().interactable = false;
            //GearUpgradeBtn.SetActive(false);
            GearUpgradeBtn.transform.position = new Vector3(2000, 0, 0);

        }
        else if(GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S3)
        {
            GearTab.SetActive(true);
            BaitTab.SetActive(true);
            FishTab.SetActive(true);
            //GearUpgradeBtn.GetComponent<Button>().interactable = true;
            //GearUpgradeBtn.SetActive(true);
            GearUpgradeBtn.transform.position = oldpos;

            StartBtn.SetActive(true);
            Hider.SetActive(false);
        }
    }

    void AnyKey()
    {
        Debug.Log(curStage);
        if (curStage < TutorialObjs.Count)
        {
            if (Input.anyKeyDown)
            {
                if(curStage != 2 && curStage != 3 && curStage != 4 && 
                    curStage != 5 && curStage != 6 && curStage != 7)
                {
                    SFXcontroller.instance.PlaySingle(NextTut);
                    curStage++;
                }
                
            }
        }
        if (curStage == 2)
        {
            FishTab.SetActive(true);
            if(TB.ActiveTab == TabController.Tabs.Fish)
            {
                SFXcontroller.instance.PlaySingle(NextTut);
                curStage++;
            }
        }
        if (curStage == 3)
        {
            Hider.SetActive(false);
        }

        if(curStage == 4)
        {
            Hider.SetActive(true);
            FishTab.SetActive(false);
            BaitTab.SetActive(true);
            if(TB.ActiveTab == TabController.Tabs.Bait)
            {
                SFXcontroller.instance.PlaySingle(NextTut);
                curStage++;
            }
        }

        if(curStage == 5)
        {
            Hider.SetActive(false);
        }

        if(curStage == 6)
        {
            Hider.SetActive(true);            
            GearTab.SetActive(true);
            BaitTab.SetActive(false);
            if (TB.ActiveTab == TabController.Tabs.Gear)
            {
                SFXcontroller.instance.PlaySingle(NextTut);
                curStage++;
            }
        }

        if(curStage == 7)
        {
            Hider.SetActive(false);
            if(GlobalStats.Instance.PlayerSavings < 10)
            {
                GlobalStats.Instance.PlayerSavings = 300;
            }
        }

        if(curStage == 8)
        {
            Hider.SetActive(true);
            StartBtn.SetActive(true);
            FishTab.SetActive(true);
            BaitTab.SetActive(true);
        }

    }

    public void Next()
    {
        SFXcontroller.instance.PlaySingle(NextTut);
        curStage++;
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

    public void ReturnTutorial()
    {
        if(GlobalStats.Instance.CurStage != GlobalStats.MapTutorialStage.S3)
            SceneManager.LoadScene("1_MapSelectorTutorial3");

        else
        {
            SceneManager.LoadScene("1_MapSelectorTutorial4");
        }
    }
}
