using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainFishingTutorial : MonoBehaviour
{
    public GameObject First,Second;
    public MainFishing MF;

    // Start is called before the first frame update
    void Start()
    {
        First.SetActive(true);
        Second.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
            if (!MF.Started)
            {
                First.SetActive(false);
                Second.SetActive(true);
            }
        
        

    }

    public void NextStage()
    {
        if (GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S1)
            GlobalStats.Instance.CurStage = GlobalStats.MapTutorialStage.S2;

        else if (GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S2)
        {
            GlobalStats.Instance.CurStage = GlobalStats.MapTutorialStage.S3;
        }
    }

    public void DoneTutorial()
    {
        if (GlobalStats.Instance.CurStage == GlobalStats.MapTutorialStage.S1)
            LoadingScreen.Instance.LoadScene("1_MapSelectorTutorial2");
        //SceneManager.LoadScene("1_MapSelectorTutorial2");

        else
        {
            LoadingScreen.Instance.LoadScene("1_MapSelectorTutorial4");
            //SceneManager.LoadScene("1_MapSelectorTutorial4");
        }
    }
}
