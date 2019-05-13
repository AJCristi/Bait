using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRPM : MonoBehaviour
{
    public Text RPMText;
    public GameObject PlayerBoat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RPMText.text = PlayerBoat.GetComponent<PropellerBoats>().engine_rpm.ToString();
    }
}
