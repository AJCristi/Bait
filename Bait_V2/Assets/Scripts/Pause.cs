using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool paused;

    public GameObject PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }


        if (paused)
        {
            //Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else
        {
            //Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }   

    public void pause()
    {
        paused = !paused;
    }

    public void RMM()
    {
        SceneManager.LoadScene(0);
    }

}
