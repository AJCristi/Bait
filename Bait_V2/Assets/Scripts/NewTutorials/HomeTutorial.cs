using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeTutorial : MonoBehaviour
{

    public List<GameObject> TutorialObjs = new List<GameObject>();

    float curStage;

    public AudioClip NextTut,SleepSFX;
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

    void AnyKey()
    {
        Debug.Log(curStage);
        if (curStage < TutorialObjs.Count)
        {
            if (Input.anyKeyDown)
            {
                SFXcontroller.instance.PlaySingle(NextTut);
                curStage++;
            }
        }
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
        SFXcontroller.instance.PlaySingle(SleepSFX);
        LoadingScreen.Instance.LoadScene("1_Prologue");
        //SceneManager.LoadScene("1_Prologue");
    }
}
