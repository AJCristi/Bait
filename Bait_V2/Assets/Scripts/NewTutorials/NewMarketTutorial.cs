﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S2)
        {
            CheckStage();
            AnyKey();
        }
        else if(GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S3)
        {
            GearTab.SetActive(true);
            BaitTab.SetActive(true);
            FishTab.SetActive(true);

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
            if (TB.ActiveTab == TabController.Tabs.Gear)
            {
                SFXcontroller.instance.PlaySingle(NextTut);
                curStage++;
            }
        }

        if(curStage == 7)
        {
            Hider.SetActive(false);
        }

        if(curStage == 8)
        {
            Hider.SetActive(true);
            StartBtn.SetActive(true);
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
