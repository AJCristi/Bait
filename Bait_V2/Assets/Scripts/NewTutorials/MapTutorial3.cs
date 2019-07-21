using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTutorial3 : MonoBehaviour
{
    public List<GameObject> TutorialObjs = new List<GameObject>();

    float curStage;

    public AudioClip NextTut;

    // Start is called before the first frame update
    void Start()
    {
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

    void AnyKey()
    {
        if (curStage < TutorialObjs.Count)
        {
            if (Input.anyKeyDown)
            {
                SFXcontroller.instance.PlaySingle(NextTut);
                Debug.Log(curStage);
                curStage++;
            }
        }
    }
}
