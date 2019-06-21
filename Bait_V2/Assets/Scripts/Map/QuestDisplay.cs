using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestDisplay : MonoBehaviour
{
    public GameObject QuestIcon;

    public GameObject SmallBox, LargeBox;

    // Start is called before the first frame update
    void Start()
    {
        //if (GlobalStats.Instance.ActiveEvent != null)
        //{
        //    QuestIcon.SetActive(false);
        //}

        LargeBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SmallBox.GetComponent<QuestSmallBox>().OnHover)
        {
            LargeBox.SetActive(true);
        }
        else
        {
            LargeBox.SetActive(false);
        }
    }
}
