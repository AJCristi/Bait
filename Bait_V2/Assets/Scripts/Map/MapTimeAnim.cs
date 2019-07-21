using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTimeAnim : MonoBehaviour
{
    public Text TimeTxt;

    public GameObject Obj;

    public bool Started;

    int temptime;

    float x;

    public AudioClip Clip;

    // Start is called before the first frame update
    void Start()
    {
        Obj.SetActive(false);
        Started = false;

        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Started)
            Obj.SetActive(false);

        else
            Obj.SetActive(true);

        TimeTxt.text = temptime.ToString() + ":00";
        
        if (Started)
        { 
            if(temptime < GlobalStats.Instance.CurTime)
            {
                x += Time.deltaTime;
                if(x > .5f)
                {
                    SFXcontroller.instance.PlaySingle(Clip);
                    temptime++;
                    x = 0;
                }
                
            }
            else
            {
                x += Time.deltaTime;
                if (x > .5)
                {
                    Started = false;
                    x = 0;
                }                    
            }            
        }
        else
        {
            x = 0;
        }
    }

    public void StartAnimation(int oldTime)
    {
        Started = true;
        temptime = oldTime;        
    }
}
