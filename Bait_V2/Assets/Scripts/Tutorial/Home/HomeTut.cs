using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTut : MonoBehaviour
{
    public List<GameObject> Screens = new List<GameObject>();
    public int Stage;

    bool p;

    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
        p = false;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject G in Screens)
            {
            if (G.name == Stage.ToString())
            {
                G.SetActive(true);
            }
            else
            {
                G.SetActive(false);
            }
        }

        if (Input.anyKeyDown)
        {
            if (Stage != 4 && Stage != 7)
            {
                Stage++;
            }
        }

        if(Stage == 4)
        {
            if(p)
            {
                Stage++;
                p = false;
            }
        }

        if (Stage == 7)
        {
            if (p)
            {
                Stage++;
                p = false;
            }
        }
    }

    public void Pressed()
    {
        p = true;
    }
}
