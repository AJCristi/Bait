using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    public GameObject HomeMenu;
    public Button HomeBtn;

    public GameObject MarketMenu;
    public Button MarketBtn;
   
    float HomeTimer, MarketTimer;

    public GameObject Location1Menu, Location1ConfirmMenu;
    public Button Loc1Btn;
    bool Loc1ConfirmMenu;
    float Loc1Timer;

    public GameObject Location2Menu, Location2ConfirmMenu;
    public Button Loc2Btn;
    bool Loc2ConfirmMenu;
    float Loc2Timer;

    public GameObject Location3Menu, Location3ConfirmMenu;
    public Button Loc3Btn;
    bool Loc3ConfirmMenu;
    float Loc3Timer;

    // Start is called before the first frame update
    void Start()
    {
        HomeTimer = 0;
        MarketTimer = 0;

        Loc1Timer = 0;
        Loc2Timer = 0;
        Loc3Timer = 0;

        HomeMenu.SetActive(false);
        MarketMenu.SetActive(false);

        Location1Menu.SetActive(false);
        Location1ConfirmMenu.SetActive(false);
        Loc1ConfirmMenu = false;

        Location2Menu.SetActive(false);
        Location2ConfirmMenu.SetActive(false);
        Loc2ConfirmMenu = false;

        Location3Menu.SetActive(false);
        Location3ConfirmMenu.SetActive(false);
        Loc3ConfirmMenu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == HomeBtn.gameObject)
        {
            HomeMenu.SetActive(true);
            HomeTimer = 0;
        }
        else
        {
            HomeTimer += Time.deltaTime;            
            if (HomeTimer > 2)
            {
                HomeMenu.SetActive(false);
            }            
        }

        if (EventSystem.current.currentSelectedGameObject == MarketBtn.gameObject)
        {
            MarketMenu.SetActive(true);
            MarketTimer = 0;
        }
        else
        {
            MarketTimer += Time.deltaTime;
            if (MarketTimer > 2)
            {
                MarketMenu.SetActive(false);
            }
        }

        if (EventSystem.current.currentSelectedGameObject == Loc1Btn.gameObject)
        {
            Location1Menu.SetActive(true);
            Loc1Timer = 0;
        }
        else
        {
            Loc1Timer += Time.deltaTime;
            if (Loc1Timer > 2)
            {
                Location1Menu.SetActive(false);
            }
        }

        if (Loc1ConfirmMenu)
        {
            Location1ConfirmMenu.SetActive(true);
            Location1Menu.SetActive(false);

            Loc1Timer += Time.deltaTime;
            if (Loc1Timer > 2)
            {               
                Loc1ConfirmMenu = false;
                Loc1Timer = 0;
            }
        }
        else
        {
            Location1ConfirmMenu.SetActive(false);
            
        }

        if (EventSystem.current.currentSelectedGameObject == Loc2Btn.gameObject)
        {
            Location2Menu.SetActive(true);
            Loc2Timer = 0;
        }
        else
        {
            Loc2Timer += Time.deltaTime;
            if (Loc2Timer >2)
            {
                Location2Menu.SetActive(false);
            }
        }

        if (Loc2ConfirmMenu)
        {
            Location2ConfirmMenu.SetActive(true);
            Location2Menu.SetActive(false);

            Loc2Timer += Time.deltaTime;
            if (Loc2Timer >2)
            {
                Loc2ConfirmMenu = false;
                Loc2Timer = 0;
            }
        }
        else
        {
            Location2ConfirmMenu.SetActive(false);
           
        }

        if (EventSystem.current.currentSelectedGameObject == Loc3Btn.gameObject)
        {
            Location3Menu.SetActive(true);
            Loc3Timer = 0;
        }
        else
        {
            Loc3Timer += Time.deltaTime;
            if (Loc3Timer > 2)
            {
                Location3Menu.SetActive(false);
            }
        }

        if (Loc3ConfirmMenu)
        {
            Location3ConfirmMenu.SetActive(true);
            Location3Menu.SetActive(false);

            Loc3Timer += Time.deltaTime;
            if (Loc3Timer > 2)
            {
                Loc3ConfirmMenu = false;
                Loc3Timer = 0;
            }
        }
        else
        {
            Location3ConfirmMenu.SetActive(false);
           
        }

    }

    public void YesHome()
    {
        Debug.Log("BRUH MOMENTS");
    }

    public void NoHome()
    {
        HomeMenu.SetActive(false);
    }

    public void YesMarket()
    {
        //todo
    }

    public void NoMarket()
    {
        MarketMenu.SetActive(false);
    }

    public void YesLoc1Confirm()
    {
        //todo gotolocation
    }

    public void NoLoc1Confirm()
    {
        Loc1ConfirmMenu = false;
    }

    public void YesLoc1()
    {
        Loc1ConfirmMenu = true;
    }

    public void NoLoc1()
    {
        Location1Menu.SetActive(false);
    }

    public void YesLoc2Confirm()
    {
        //todo gotolocation
    }

    public void NoLoc2Confirm()
    {
        Loc2ConfirmMenu = false;
    }

    public void YesLoc2()
    {
        Loc2ConfirmMenu = true;
    }

    public void NoLoc2()
    {
        Location2Menu.SetActive(false);
    }

    public void YesLoc3Confirm()
    {
        //todo gotolocation
    }

    public void NoLoc3Confirm()
    {
        Loc3ConfirmMenu = false;
    }

    public void YesLoc3()
    {
        Loc3ConfirmMenu = true;
    }

    public void NoLoc3()
    {
        Location3Menu.SetActive(false);
    }
}
