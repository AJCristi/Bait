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

    float Fov, minFov, maxFov;

    public GameObject Player;
    
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

        Fov = BinocsCamera.fieldOfView;
        minFov = Fov;//60
        maxFov = 20;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //BinocsCamPosUpdate();
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
        BinocsCamera.gameObject.GetComponent<FPLook>().ResetCamPos();
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
        //transform.position = new Vector3(Player.transform.position.x, 7.0f, Player.transform.position.z);

        BinocsCamera.gameObject.transform.position = 
            new Vector3(Player.transform.position.x, 7.0f, Player.transform.position.z);
    }

    void Zoom()
    {
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)// up
        {
            
            if (BinocsCamera.fieldOfView <= minFov && BinocsCamera.fieldOfView >= maxFov )
            {                
                BinocsCamera.fieldOfView -= 5f;
                if (BinocsCamera.fieldOfView < maxFov)
                {
                    Debug.Log("Up");
                    BinocsCamera.fieldOfView = maxFov;
                }
            }
           
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)//down
        {
            
            if (BinocsCamera.fieldOfView <= minFov && BinocsCamera.fieldOfView >= maxFov)
            {
                BinocsCamera.fieldOfView += 5f;
                if(BinocsCamera.fieldOfView > minFov)
                {
                    Debug.Log("Down");
                    BinocsCamera.fieldOfView = minFov;
                }
            }
        }
    }
    
}
