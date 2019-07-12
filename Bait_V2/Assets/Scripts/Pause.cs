using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool paused;
    bool debugOpen;

    public GameObject PauseMenu;
    public Text NowPlayingText;

    public AudioClip PauseSFX;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        NowPlayingText.text = SFXcontroller.instance.ReturnCurrentPlaying();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
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

    public void NextSong()
    {
        SFXcontroller.instance.NextSong();
    }

    public void pause()
    {
        SFXcontroller.instance.PlaySingle(PauseSFX);
        paused = !paused;
    }

    public void RMM()
    {
        SFXcontroller.instance.PauseMusic();
        SceneManager.LoadScene(0);
    }

}
