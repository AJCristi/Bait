using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingTrawl : MonoBehaviour
{
    bool started;

    public bool DeployedTrawl;

    public Image Background, MeterImage;

    public float TotalTime;
    float timeRatio, timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        DeployedTrawl = false;
        started = false;

        Background.enabled = false;
        MeterImage.enabled = false;
        MeterImage.fillAmount = 0;
        timeRemaining = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerFishing>().SelectedNet == PlayerFishing.NetType.Trawl)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Deploy();
            }
        }

        TrawlFish();
        timeRatio = timeRemaining / TotalTime;
        MeterImage.fillAmount = timeRatio;

        
    }

    public void Deploy()
    {
        DeployedTrawl = !DeployedTrawl;
        if (DeployedTrawl)
        {
            gameObject.GetComponent<PropellerBoats>().Slowdown();
        }
        else
        {
            gameObject.GetComponent<PropellerBoats>().RestoreSpeed();
        }
        
    }

    public void TrawlFish()
    {
        if (!gameObject.GetComponent<PlayerFishing>().IsOverFishingArea)
        {
            if (DeployedTrawl)
            {
                started = true;
                Debug.Log("STARTED");
            }
            else
            {
                Debug.Log("STOIPPED");
                started = false;
            }
        }

        if (started && gameObject.GetComponent<PlayerFishing>().IsOverFishingArea &&
            gameObject.GetComponent<PlayerFishing>().FishingArea.GetComponent<FishingArea>().Depleted == false)
        {
            Debug.Log("TRAWL");
            Background.enabled = true;
            MeterImage.enabled = true;
            timeRemaining += Time.deltaTime;

            if (timeRatio >= 1)
            {
                gameObject.GetComponent<PlayerFishing>().
                FishingArea.GetComponent<FishingArea>().Depleted = true;

                gameObject.GetComponent<PlayerFishing>().
                    FishingArea.GetComponent<FishingArea>().AddFish();
            }
        }
        else
        {
            
            timeRemaining = 0;
            MeterImage.fillAmount = 0;
            Background.enabled = false;
            MeterImage.enabled = false;
        }

        if (!DeployedTrawl && gameObject.GetComponent<PlayerFishing>().IsOverFishingArea)
        {
            timeRemaining = 0;
            MeterImage.fillAmount = 0;
            Background.enabled = false;
            MeterImage.enabled = false;
        }
    }
}
