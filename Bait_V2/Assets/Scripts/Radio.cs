using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public Text RadText;

    public List<string> Blurbs = new List<string>();

    public GameObject Ticker;

    float x;

    public GameObject StartPos, EndPos;

    bool started;

    public float Speed;
    

    // Start is called before the first frame update
    void Start()
    {
        started = false;

        x = 0;
        RadText.text = Blurbs[RandomList()];

        Ticker.transform.localPosition = StartPos.transform.localPosition;
        
    }

    void MoveTicker()
    {
        if(!started)
        {
          
            if(Vector3.Distance(Ticker.transform.localPosition, EndPos.transform.localPosition) > 1f)
            {
                
                Ticker.transform.localPosition = Vector3.MoveTowards(Ticker.transform.localPosition,
                    EndPos.transform.localPosition, Speed * Time.deltaTime);
            }
            else
            {
                x += Time.deltaTime;
                //Debug.Log(x);
                if (x > 5)
                {
                    Ticker.transform.localPosition = StartPos.transform.localPosition;
                    RadText.text = Blurbs[RandomList()];
                    x = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeTicker();
        MoveTicker();

    } 


    int RandomList()
    {
        int x = 0;

        x = Random.Range(0, Blurbs.Count);

        return x;
    }
}
