using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTutorial : MonoBehaviour
{
    public List<GameObject> TutorialObjs = new List<GameObject>();

    float curStage;

    public GameObject StatusBar1, StatusBar2;
    public GameObject Gear;
    public GameObject Location1;

    // Start is called before the first frame update
    void Start()
    {
        curStage = 1;

        foreach(GameObject G in TutorialObjs)
        {
            G.SetActive(false);
        }
        TutorialObjs[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckStage();
        AnyKey();
    }

    void AnyKey()
    {
        if (curStage < TutorialObjs.Count)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log(curStage);
                curStage++;
            }
        }

        if(curStage == 2)
        {
            StatusBar1.SetActive(true);
            StatusBar2.SetActive(true);
        }

        if (curStage == 7)
        {
            Gear.SetActive(true);
        }

        if(curStage == 8)
        {
            Location1.SetActive(true);
        }
    }

    void CheckStage()
    {        
        foreach (GameObject G in TutorialObjs)
        {            
            if(G.name == curStage.ToString())
            {
                G.SetActive(true);
            }
            else
            {
                G.SetActive(false);
            }
        }
    }
}
