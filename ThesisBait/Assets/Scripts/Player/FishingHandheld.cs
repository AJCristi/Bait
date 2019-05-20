using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingHandheld : MonoBehaviour
{
    public Image Background, MeterImage;

    bool started;

    public float TotalTime;
    float timeRatio, timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        Background.enabled = false;
        MeterImage.enabled = false;

        MeterImage.fillAmount = 0;
        timeRemaining = 0;

        TotalTime = GlobalStats.Instance.HandFloat;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerFishing>().IsOverFishingArea
            && gameObject.GetComponent<PlayerFishing>().SelectedNet == PlayerFishing.NetType.Handheld
            && gameObject.GetComponent<PlayerFishing>().FishingArea.GetComponent<FishingArea>().Depleted == false)
        {
            if (Input.GetKey(KeyCode.E))
            {
                StartFishing();
            }
        }
        else
        {
            timeRemaining = 0;
            MeterImage.fillAmount = 0;
            Background.enabled = false;
            MeterImage.enabled = false;
        }

        timeRatio = timeRemaining / TotalTime;
        MeterImage.fillAmount = timeRatio;
    }

    void StartFishing()
    {
        if(timeRemaining <= TotalTime)
        {
            Background.enabled = true;
            MeterImage.enabled = true;
            timeRemaining += Time.deltaTime;            
        }
        else
        {
            Debug.Log("Done");
            timeRemaining = 0;
            MeterImage.fillAmount = 0;
            Background.enabled = false;
            MeterImage.enabled = false;

            gameObject.GetComponent<PlayerFishing>().
                FishingArea.GetComponent<FishingArea>().Depleted = true;

            gameObject.GetComponent<PlayerFishing>().
                FishingArea.GetComponent<FishingArea>().AddFish();
        }
        
    }
    
}
