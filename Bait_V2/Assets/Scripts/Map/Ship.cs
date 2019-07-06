using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject Loc1Ship, Loc2Ship, Loc3Ship;
    public GameObject Loc1Blocker, Loc2Blocker, Loc3Blocker;

    public bool Loc1Blocked, Loc2Blocked, Loc3Blocked;

    // Start is called before the first frame update
    void Start()
    {
        Loc1Ship.SetActive(false);
        Loc2Ship.SetActive(false);
        Loc3Ship.SetActive(false);

        Loc1Blocker.SetActive(false);
        Loc2Blocker.SetActive(false);
        Loc3Blocker.SetActive(false);

        Loc1Blocked = false;
        Loc2Blocked = false;
        Loc3Blocked = false;

        CheckBlocked();

    }

    // Update is called once per frame
    void Update()
    {
        switch (Loc1Blocked)
        {
            case true:
                Loc1Ship.SetActive(true);
                Loc1Blocker.SetActive(true);
                break;

            case false:
                Loc1Ship.SetActive(false);
                Loc1Blocker.SetActive(false);
                break;
        }

        switch (Loc2Blocked)
        {
            case true:
                Loc2Ship.SetActive(true);
                Loc2Blocker.SetActive(true);
                break;

            case false:
                Loc2Ship.SetActive(false);
                Loc2Blocker.SetActive(false);
                break;
        }

        switch (Loc3Blocked)
        {
            case true:
                Loc3Ship.SetActive(true);
                Loc3Blocker.SetActive(true);
                break;

            case false:
                Loc3Ship.SetActive(false);
                Loc3Blocker.SetActive(false);
                break;
        }

    }

    void CheckBlocked()
    {
        if(Random100() < 10)
        {
            Loc1Blocked = true;
        }

        if (Random100() < 10)
        {
            Loc2Blocked = true;
        }

        if (Random100() < 10)
        {
            Loc3Blocked = true;
        }
    }

    float Random100()
    {
        return Random.Range(1, 100);
    }
}
