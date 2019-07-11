using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StreamVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public double time;
    public double currentTime;
    // Use this for initialization
    void Start()
    {
        time = videoPlayer.clip.length;
        StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }

    void Update()
    {       
        currentTime = videoPlayer.time;

        double x = currentTime / time;
        Debug.Log(x);

        if(x > .994)
        {
            if(SceneManager.GetActiveScene().name == "1_Prologue")
                SceneManager.LoadScene("1_MapSelector");
        }

    }
}
