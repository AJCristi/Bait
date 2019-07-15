using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseIcon : MonoBehaviour
{

    public Image ToPulse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ToPulse.color = new Color(ToPulse.color.r,
            ToPulse.color.g, ToPulse.color.b,
            Mathf.PingPong(Time.time * 1f, 1));
    }
}
