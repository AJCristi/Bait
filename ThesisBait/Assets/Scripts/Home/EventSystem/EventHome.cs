using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHome : MonoBehaviour
{
    public Text Month, Day;

    // Start is called before the first frame update
    void Start()
    {
        Month.text = GlobalStats.Instance.Month.ToString();
        Day.text = GlobalStats.Instance.Day.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
