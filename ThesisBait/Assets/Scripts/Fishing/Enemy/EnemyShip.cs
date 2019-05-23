using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject Helicopter;
    public RestrictedArea area; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(area.PlayerInside)
        {
            DispatchHeli();
        }
    }

    void DispatchHeli()
    {
        Helicopter.GetComponent<Helicopter>().Dispatch();
    }
}
