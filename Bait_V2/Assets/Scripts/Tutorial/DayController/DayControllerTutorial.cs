using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayControllerTutorial : MonoBehaviour
{
    public List<GameObject> Screens = new List<GameObject>();

    public List<GameObject> Screen2 = new List<GameObject>();

    public List<GameObject> Screen3 = new List<GameObject>();

    [Range(1, 5)]
    public int Stage;

    public int Stage2;

    public int Stage3;
    // Start is called before the first frame update
    void Start()
    {
        Stage = 1;
        Stage2 = 11;
        Stage3 = 21;
    }

    // Update is called once per frame
    void Update()
    {       

        if(GlobalStats.Instance.TS1 == GlobalStats.Activity.None)
        {
            if (Stage < 5)
            {
                foreach (GameObject G in Screens)
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
            }

            if (Input.anyKeyDown)
            {
                if (Stage < 5)
                    Stage++;
            }
        }

        else
        {
            foreach (GameObject G in Screens)
            {
                G.SetActive(false);
            }
        }

        if(GlobalStats.Instance.TS1 == GlobalStats.Activity.Fishing)
        {
           
            foreach (GameObject G in Screen2)
            {
                if (G.name == Stage2.ToString())
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
                if(Stage2 != 13)
                    Stage2++;
            }
        }

        else
        {
            foreach (GameObject G in Screen2)
            {
                G.SetActive(false);
            }
        }

        if(GlobalStats.Instance.TS2 == GlobalStats.Activity.Market)
        {
            foreach (GameObject G in Screen2)
            {
                G.SetActive(false);
            }

            if (Stage3 < 24)
            {
                foreach (GameObject G in Screen3)
                {
                    if (G.name == Stage3.ToString())
                    {
                        G.SetActive(true);
                    }
                    else
                    {
                        G.SetActive(false);
                    }
                }
            }

            if (Input.anyKeyDown)
            {

                Stage3++;
            }
        }

        else
        {
            foreach (GameObject G in Screen3)
            {
                G.SetActive(false);
            }
        }

    }
}
