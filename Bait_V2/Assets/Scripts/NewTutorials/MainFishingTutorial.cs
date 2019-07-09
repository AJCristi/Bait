using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(!MF.Started)
        {
            First.SetActive(false);
            Second.SetActive(true);
        }

    }

    public void NextStage()
    {
        GlobalStats.Instance.CurStage = GlobalStats.MapTutorialStage.S2;
    }
}
