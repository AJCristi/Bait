using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastNet : MonoBehaviour
{
    GameObject UI;
    GameObject Player;

    public Image MeterImage;

    bool finishedFishing;

    public float TotalTime;
    float timeRatio, timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        TotalTime = GlobalStats.Instance.CastFloat;

        UI = gameObject.transform.GetChild(0).gameObject;
        Player = GameObject.FindGameObjectWithTag("Player");
        
        MeterImage.fillAmount = 0;
        timeRemaining = 0;

        finishedFishing = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);

        timeRatio = timeRemaining / TotalTime;
        MeterImage.fillAmount = timeRatio;

        if (!finishedFishing)
        {
            if (timeRemaining <= TotalTime)
            {                
                MeterImage.enabled = true;
                timeRemaining += Time.deltaTime;
            }
            else
            {
                finishedFishing = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(finishedFishing)
            {
                Destroy(gameObject);
                other.gameObject.GetComponent<FishingCast>().DoneCast();

            }
        }
    }
}
