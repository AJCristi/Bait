using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : MonoBehaviour
{
    public Text RadText;

    public List<string> Blurbs = new List<string>();

    float x;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        RadText.text = Blurbs[RandomList()];
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime;
        if(x > 5)
        {
            RadText.text = Blurbs[RandomList()];
            x = 0;
        }
       
    }

    int RandomList()
    {
        int x = 0;

        x = Random.Range(0, Blurbs.Count);

        return x;
    }
}
