using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port : MonoBehaviour
{
    bool PlayerInside;

    public GameObject Return;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInside = false;
        Return.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInside)
        {
            Return.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<DayTimer>().End();
            }
        }

        else
        {
            Return.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInside = false;
        }
    }
}
