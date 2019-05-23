using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestrictedArea : MonoBehaviour
{
    public bool PlayerInside;


    // Start is called before the first frame update
    void Start()
    {
        PlayerInside = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
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
