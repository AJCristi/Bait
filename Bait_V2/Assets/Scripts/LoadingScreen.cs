using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }


    private bool loadScene = false;
    
    private string scene;
    [SerializeField]
    private Text loadingText;

    public GameObject LoadingScrn;

    public void LoadScene(string x)
    {
        scene = x;
        loadScene = true;
        
        loadingText.text = "Loading...";
        DisplayOn();
        StartCoroutine(LoadNewScene());

    }

    private void Start()
    {
        LoadingScrn.SetActive(false);
    }

    void DisplayOn()
    {
        Debug.Log("On");
        LoadingScrn.SetActive(true);
    }

    private void Update()
    {
        loadingText.color = new Color(loadingText.color.r,
            loadingText.color.g, loadingText.color.b, 
            Mathf.PingPong(Time.time, 1));

    }

    void DisplayOff()
    {
        LoadingScrn.SetActive(false);
    }

    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene()
    {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.

        //yield return new WaitForSeconds(3);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {            
            loadScene = false;
            DisplayOff();
            yield return null;
        }

    }
}
