﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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


    public Text Loc1Hour, Loc2Hour, Loc3Hour;
    public Image MarketPlaceIndicator;
    public Sprite Up, Down;

    public AudioClip Select;

    public MapTimeAnim MTA;

    public GameObject NotifBait, NotifGear;

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

    public void PlaySelectSFX()
    {
        SFXcontroller.instance.PlaySingle(Select);
    }

    public void Loc1Tutorial()
    {
        GlobalStats.Instance.SelectedLocation = GlobalStats.FishingLocation.SandyShoals;
        LoadingScreen.Instance.LoadScene("3_FishingTutorial");
        //SceneManager.LoadScene("3_FishingTutorial");
    }

    public void Loc2Tutorial()
    {
        GlobalStats.Instance.SelectedLocation = GlobalStats.FishingLocation.ExposedReef;
        LoadingScreen.Instance.LoadScene("3_FishingTutorial");
        //SceneManager.LoadScene("3_FishingTutorial");
    }

    public void MarketTutorial()
    {
        MTA.StartAnimation(GlobalStats.Instance.CurTime);
        GlobalStats.Instance.AdvanceTime(2);
        LoadingScreen.Instance.LoadScene("2_MarketPlaceTutorial");
        //SceneManager.LoadScene("2_MarketPlaceTutorial");
    }

    public void HomeTutorial()
    {
        SceneManager.LoadScene("4_HomeTutorial");
    }

    // Update is called once per frame
    void Update()
    {
        Loc1Hour.text = GlobalStats.Instance.SSHours.ToString() + " hours";
        Loc2Hour.text = GlobalStats.Instance.ERHours.ToString() + " hours";
        Loc3Hour.text = GlobalStats.Instance.LIHours.ToString() + " hours";
        MarketUpdate();
        CheckNotifs();

        if (GlobalStats.Instance.CurTime >= 20)
        {
            
            //LoadingScreen.Instance.LoadScene("4_Home");
            if (SceneManager.GetActiveScene().name == "1_MapSelectorTutorial4")
            {
                SceneManager.LoadScene("4_HomeTutorial");
            }
            else
            {
                SceneManager.LoadScene("4_Home");
            }
            
        }

        MenuUpdates();

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

    void CheckNotifs()
    {
        int x = GlobalStats.Instance.RodPieces + GlobalStats.Instance.CastPieces
            + GlobalStats.Instance.TrawlPieces;

        if (x < 10)
        {
            NotifGear.SetActive(true);
        }
        else
        {
            NotifGear.SetActive(false);
        }

        int y = GlobalStats.Instance.BreadAmt + GlobalStats.Instance.InsectAmt +
            GlobalStats.Instance.WormAmt;

        if(y < 20)
        {
            NotifBait.SetActive(true);
        }
        else
        {
            NotifBait.SetActive(false);
        }
    }

    void MenuUpdates()
    {
        //if (EventSystem.current.currentSelectedGameObject == HomeBtn.gameObject)
        //{

        //    HomeMenu.SetActive(true);
        //    HomeTimer = 0;
        //}
        //else
        //{
        //    HomeTimer += Time.deltaTime;
        //    if (HomeTimer > 2)
        //    {
        //        HomeMenu.SetActive(false);
        //    }
        //}

        //if (EventSystem.current.currentSelectedGameObject == MarketBtn.gameObject)
        //{
        //    MarketMenu.SetActive(true);
        //    MarketTimer = 0;
        //}
        //else
        //{
        //    MarketTimer += Time.deltaTime;
        //    if (MarketTimer > 2)
        //    {
        //        MarketMenu.SetActive(false);
        //    }
        //}

        //if (EventSystem.current.currentSelectedGameObject == Loc1Btn.gameObject)
        //{
        //    Location1Menu.SetActive(true);
        //    Loc1Timer = 0;
        //}
        //else
        //{
        //    Loc1Timer += Time.deltaTime;
        //    if (Loc1Timer > 2)
        //    {
        //        Location1Menu.SetActive(false);
        //    }
        //}

        //if (EventSystem.current.currentSelectedGameObject == Loc2Btn.gameObject)
        //{
        //    Location2Menu.SetActive(true);
        //    Loc2Timer = 0;
        //}
        //else
        //{
        //    Loc2Timer += Time.deltaTime;
        //    if (Loc2Timer > 2)
        //    {
        //        Location2Menu.SetActive(false);
        //    }
        //}

        //if (EventSystem.current.currentSelectedGameObject == Loc3Btn.gameObject)
        //{
        //    Location3Menu.SetActive(true);
        //    Loc3Timer = 0;
        //}
        //else
        //{
        //    Loc3Timer += Time.deltaTime;
        //    if (Loc3Timer > 2)
        //    {
        //        Location3Menu.SetActive(false);
        //    }
        //}

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            //Debug.Log("Null");

            HomeMenu.SetActive(false);
            MarketMenu.SetActive(false);

            Location1Menu.SetActive(false);
            Location2Menu.SetActive(false);
            Location3Menu.SetActive(false);
        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == HomeBtn.gameObject)
            {
                HomeMenu.SetActive(true);
            }
            else
            {
                if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject != HomeMenu)
                {
                    HomeMenu.SetActive(false);
                }

            }

            if (EventSystem.current.currentSelectedGameObject == MarketBtn.gameObject)
            {
                MarketMenu.SetActive(true);
            }
            else
            {
                if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject != MarketMenu)
                {
                    MarketMenu.SetActive(false);
                }
            }

            if (EventSystem.current.currentSelectedGameObject == Loc1Btn.gameObject)
            {
                Location1Menu.SetActive(true);
            }
            else
            {
                if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject != Location1Menu)
                {
                    Location1Menu.SetActive(false);
                }

            }

            if (EventSystem.current.currentSelectedGameObject == Loc2Btn.gameObject)
            {
                Location2Menu.SetActive(true);

            }
            else
            {
                if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject != Location2Menu)
                {
                    Location2Menu.SetActive(false);
                }
            }

            if (EventSystem.current.currentSelectedGameObject == Loc3Btn.gameObject)
            {
                Location3Menu.SetActive(true);
            }
            else
            {
                if (EventSystem.current.currentSelectedGameObject.transform.parent.gameObject != Location3Menu)
                {
                    Location3Menu.SetActive(false);
                }
            }

        }
        //Debug.Log(EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.name);

    }

    void MarketUpdate()
    {
        switch(GlobalStats.Instance.PricesToday)
        {
            case GlobalStats.MarketPrices.Higher:
                MarketPlaceIndicator.enabled = true;
                MarketPlaceIndicator.sprite = Up;
                break;

            case GlobalStats.MarketPrices.Normal:
                MarketPlaceIndicator.enabled = false;
                //MarketPlaceIndicator.sprite = null;

                break;

            case GlobalStats.MarketPrices.Lower:
                MarketPlaceIndicator.enabled = true;
                MarketPlaceIndicator.sprite = Down;
                break;
        }
    }

    public void YesHome()
    {
        Debug.Log("clicked");
        LoadingScreen.Instance.LoadScene("4_Home");
        //SceneManager.LoadScene("4_Home");
    }

    public void NoHome()
    {
        HomeMenu.SetActive(false);
    }

    public void YesMarket()
    {
        MTA.StartAnimation(GlobalStats.Instance.CurTime);
        GlobalStats.Instance.AdvanceTime(2);
        LoadingScreen.Instance.LoadScene("2_MarketPlace");
        
        
        //SceneManager.LoadScene("2_MarketPlace");      


    }

    public void NoMarket()
    {
        MarketMenu.SetActive(false);
    }

    public void NoLoc1Confirm()
    {
        Loc1ConfirmMenu = false;
    }

    public void YesLoc1()
    {
        //Loc1ConfirmMenu = true;
        
        GlobalStats.Instance.SelectedLocation = GlobalStats.FishingLocation.SandyShoals;
        LoadingScreen.Instance.LoadScene("3_Fishing");
        //SceneManager.LoadScene("3_Fishing");
    }

    public void NoLoc1()
    {
        Location1Menu.SetActive(false);
    }

    public void NoLoc2Confirm()
    {
        Loc2ConfirmMenu = false;
    }

    public void YesLoc2()
    {
        //Loc2ConfirmMenu = true;
        
        GlobalStats.Instance.SelectedLocation = GlobalStats.FishingLocation.ExposedReef;
        LoadingScreen.Instance.LoadScene("3_Fishing");
        //SceneManager.LoadScene("3_Fishing");
    }

    public void NoLoc2()
    {
        Location2Menu.SetActive(false);
    }

  
    public void NoLoc3Confirm()
    {
        Loc3ConfirmMenu = false;
    }

    public void YesLoc3()
    {
        //Loc3ConfirmMenu = true;
        
        GlobalStats.Instance.SelectedLocation = GlobalStats.FishingLocation.LonelyIsland;
        LoadingScreen.Instance.LoadScene("3_Fishing");
        //SceneManager.LoadScene("3_Fishing");
    }

    public void NoLoc3()
    {
        Location3Menu.SetActive(false);
    }
}
