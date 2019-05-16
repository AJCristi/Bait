using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingArea : MonoBehaviour
{
    public enum AmountYielded
    {
        Low,
        Medium,
        High
    }

    public AmountYielded Yield;

    bool IsPlayerInside;

    public bool Depleted;

    public float LowYield, MediumYield, HighYield;

    public bool HasNet;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Depleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerInside = true;
            Player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerInside = false;
            Player = null;
        }
    }

    public void AddFish()
    {
        switch (Yield)
        {
            case AmountYielded.Low:
                Player.GetComponent<PlayerFishing>().FishAmt += LowYield;
                break;

            case AmountYielded.Medium:
                Player.GetComponent<PlayerFishing>().FishAmt += MediumYield;
                break;

            case AmountYielded.High:
                Player.GetComponent<PlayerFishing>().FishAmt += HighYield;
                break;

        }
    }    
}
