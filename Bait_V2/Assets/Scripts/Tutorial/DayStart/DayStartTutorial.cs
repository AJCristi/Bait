using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayStartTutorial : MonoBehaviour
{
    public List<GameObject> Screens = new List<GameObject>();

    [Range(1,6)]
    public int Stage;

    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject G in Screens)
        {
            if(G.name == Stage.ToString())
            {
                G.SetActive(true);
            }
            else
            {
                G.SetActive(false);
            }
        }


        if(Input.anyKeyDown)
        {
            Stage++;
        }

    }
}
