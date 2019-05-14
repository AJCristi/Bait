﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFishing : MonoBehaviour
{
    public enum NetType
    {
        Handheld,
        Trawl,
        Cast
    }

    public float FishCarried;

    public NetType SelectedNet;

    public Button HandheldButton, TrawlButton, CastButton;

    public Text FishKG;
    public float FishAmt;

    public bool IsOverFishingArea;
    public GameObject FishingArea;

    // Start is called before the first frame update
    void Start()
    {
        SelectedNet = NetType.Handheld;

        if(STATICPlayerStats.TrawlUnlocked)
        {
            TrawlButton.interactable = true;
        }
        else
        {
            TrawlButton.interactable = false;
        }

        if (STATICPlayerStats.CastUnlocked)
        {
            CastButton.interactable = true;
        }
        else
        {
            CastButton.interactable = false;
        }

        FishAmt = 0;
        IsOverFishingArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        FishKG.text = FishAmt.ToString();

        SelectNet();
        //Debug.Log(SelectedNet);

         
    }

    void SelectNet()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedNet = NetType.Handheld;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(STATICPlayerStats.TrawlUnlocked)
            {
                SelectedNet = NetType.Trawl;
            }
            else
            {
                //
                SelectedNet = NetType.Handheld;
            }
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (STATICPlayerStats.CastUnlocked)
            {
                SelectedNet = NetType.Cast;
            }
            else
            {
                //
                SelectedNet = NetType.Handheld;
            }
        }
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="FishArea")
        {
            IsOverFishingArea = true;
            FishingArea = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FishArea")
        {
            IsOverFishingArea = false;
            FishingArea = null;
        }
    }

}
