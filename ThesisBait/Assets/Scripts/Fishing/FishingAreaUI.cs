using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingAreaUI : MonoBehaviour
{
    public GameObject MarkerFish;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("BinocularController").GetComponent<Binocular>().BinocsInUse)
        {
            MarkerFish.SetActive(true);
        }
        else
        {
            MarkerFish.SetActive(false);
        }
    }
}
