using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingCast : MonoBehaviour
{
    public GameObject CastNetPrefab;
    public GameObject SpawnNetArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<PlayerFishing>().SelectedNet == 
            PlayerFishing.NetType.Cast && 
            gameObject.GetComponent<PlayerFishing>().IsOverFishingArea)
        {            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!gameObject.GetComponent<PlayerFishing>().FishingArea.GetComponent<FishingArea>().HasNet)
                {
                    DeployNet();
                }
                else
                {
                    Debug.Log("HAS NET");
                }
            }            
        }
    }

    void DeployNet()
    {        
        GameObject Net = 
            Instantiate(CastNetPrefab, 
            SpawnNetArea.transform.position,
            Quaternion.identity) as GameObject;

        gameObject.GetComponent<PlayerFishing>().FishingArea.GetComponent<FishingArea>().HasNet = true;
    }

    public void DoneCast()
    {
        gameObject.GetComponent<PlayerFishing>().
               FishingArea.GetComponent<FishingArea>().Depleted = true;

        gameObject.GetComponent<PlayerFishing>().
            FishingArea.GetComponent<FishingArea>().AddFish();
    }
}
