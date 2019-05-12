using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Binocular : MonoBehaviour
{
    public bool CanUseBinocs;
    public bool BinocsInUse;

    public Canvas BCanvas;

    public GameObject DefaultCamera;
    public Camera BinocsCamera;

    AudioListener DC, BC;

     

    // Start is called before the first frame update
    void Start()
    {
        BinocsInUse = false;
        BCanvas.enabled = false;
        CanUseBinocs = true;

        BinocsCamera.enabled = false;

        DC = DefaultCamera.transform.GetChild(0).GetChild(0).gameObject.GetComponent<AudioListener>();

        BC = BinocsCamera.GetComponent<AudioListener>();
        BC.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CanUseBinocs)
        {
            if (Input.GetMouseButtonDown(1))
            {
                UseBinocs();
            }
        }

        if (BinocsInUse)
        {
            Zoom();
        }
    }

    void UseBinocs()
    {
        BinocsInUse = !BinocsInUse;
        if (BinocsInUse)
        {
            BCanvas.enabled = true;
        }
        else
        {
            BCanvas.enabled = false;
        }
        SwitchCamera(BCanvas.enabled);
    }

    void SwitchCamera(bool x)
    {
        switch(x)
        {
            case true://activated binocs
                DefaultCamera.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                DC.enabled = false;

                BinocsCamera.enabled = true;
                BC.enabled = true;
                break;

            case false:
                DefaultCamera.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                DC.enabled = true;

                BinocsCamera.enabled = false;
                BC.enabled = false;
                break;
        }
    }

    void BinocsCamPosUpdate()
    {
        //todo
    }

    void Zoom()
    {
        //todo finish up
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)// up
        {
            Debug.Log("Up");
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)//down
        {
            Debug.Log("Down");
        }
    }
    
}
