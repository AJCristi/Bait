using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMenu : MonoBehaviour
{
    bool debugActive;

    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        debugActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            debugActive = false;
        }

        if (debugActive)
        {
            Menu.SetActive(true);
        }
        else
        {
            Menu.SetActive(false);
        }
    }

    public void Activate()
    {
        debugActive = !debugActive;
    }

    public void ChangeMoney(InputField IF)
    {
        GlobalStats.Instance.PlayerSavings = float.Parse(IF.text);
    }

    public void AddGalunggong(InputField IF)
    {
        GlobalStats.Instance.smallKG += float.Parse(IF.text);
    }
    public void AddTilapia(InputField IF)
    {
        GlobalStats.Instance.medKG += float.Parse(IF.text);
    }
    public void AddLapuLapu(InputField IF)
    {
        GlobalStats.Instance.largeKG += float.Parse(IF.text);
    }
}
