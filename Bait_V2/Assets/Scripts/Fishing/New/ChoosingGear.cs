using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosingGear : MonoBehaviour
{
    public GameObject Gear, Bait;
    enum Tab
    {
        Gear,
        Bait
    }

    Tab ActiveTab;

    public Image NetImg;
    public Sprite Rod, Cast, Trawl;
    public Text NetTitle, NetLevel, NetDesc;
    public Text NetPieces;

    public Text RodAmt, CastAmt, TrawlAmt;

    public Image BaitImg;
    public Sprite Bread, Insect, Worm;
    public Text BaitTitle, BaitAmt, BaitDesc;

    public Text BaitBreadAmt, BaitInsectAmt, BaitWormsAmt;

    public GameObject FishingScene;

    public Text LocationName,Hours;

    public Button StartBtn;
    public bool CanStart;

    public AudioClip Return, Next, TabSfx, StartFish;

    public string ReturnActiveTab()
    {
        return ActiveTab.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        ActiveTab = Tab.Bait;

        CanStart = false;
        FishingScene.SetActive(false);
        LocationName.text = GlobalStats.Instance.SelectedLocation.ToString();

        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.SandyShoals:
                Hours.text = GlobalStats.Instance.SSHours.ToString() + 
                    " Hours";
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                Hours.text = GlobalStats.Instance.ERHours.ToString() + 
                    " Hours";
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                Hours.text = GlobalStats.Instance.LIHours.ToString() + 
                    " Hours";
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (CanStart)
        {
            StartBtn.interactable = true;
        }
        else
        {
            StartBtn.interactable = false;
        }
        Debug.Log(CanStart);
           
        switch (ActiveTab)
        {
            case Tab.Bait:
                Bait.SetActive(true);
                Gear.SetActive(false);
                break;

            case Tab.Gear:
                Gear.SetActive(true);
                Bait.SetActive(false);
                break;
        }
        CheckGear();
        

        UpdateNet();
        UpdateBait();
    }

    void CheckGear()
    {
        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                if (GlobalStats.Instance.CastPieces > 0)
                {
                    CheckBait();
                }
                else
                {
                    CanStart = false;
                }
                break;

            case GlobalStats.NetType.Rod:
                if (GlobalStats.Instance.RodPieces > 0)
                {
                    CheckBait();
                }
                else
                {
                    CanStart = false;
                }
                break;

            case GlobalStats.NetType.Trawling:
                if (GlobalStats.Instance.TrawlPieces > 0)
                {
                    CheckBait();
                }
                else
                {
                    CanStart = false;
                }
                break;
        }
    }

    void CheckBait()
    {
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                if(GlobalStats.Instance.BreadAmt > 0)
                {
                    CanStart = true;
                }
                else
                {
                    CanStart = false;
                }
                break;

            case GlobalStats.BaitType.Insects:
                if (GlobalStats.Instance.InsectAmt > 0)
                {
                    CanStart = true;
                }
                else
                {
                    CanStart = false;
                }
                break;

            case GlobalStats.BaitType.Worms:
                if (GlobalStats.Instance.WormAmt > 0)
                {
                    CanStart = true;
                }
                else
                {
                    CanStart = false;
                }
                break;
        }
    }

    void UpdateNet()
    {
        NetTitle.text = GlobalStats.Instance.CurrentNet.ToString();

        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                NetImg.sprite = Cast;
                NetLevel.text = "Level: " + GlobalStats.Instance.CastNetLevel.ToString();
                NetDesc.text = "Uses 5 bait per cast";

                NetPieces.text = GlobalStats.Instance.CastPieces.ToString() + " pieces";
                break;

            case GlobalStats.NetType.Rod:
                NetImg.sprite = Rod;
                NetLevel.text = "Level: " + GlobalStats.Instance.RodNetLevel.ToString();
                NetDesc.text = "Uses 1 bait per cast";

                NetPieces.text = GlobalStats.Instance.RodPieces.ToString() + " pieces";
                break;

            case GlobalStats.NetType.Trawling:
                NetImg.sprite = Trawl;
                NetLevel.text = "Level: " + GlobalStats.Instance.TrawlingNetLevel.ToString();
                NetDesc.text = "Uses 10 bait per cast";

                NetPieces.text = GlobalStats.Instance.TrawlPieces.ToString() + " pieces";
                break;
        }

        RodAmt.text = GlobalStats.Instance.RodPieces.ToString();
        CastAmt.text = GlobalStats.Instance.CastPieces.ToString();
        TrawlAmt.text = GlobalStats.Instance.TrawlPieces.ToString();
    }

    void UpdateBait()
    {
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                BaitImg.overrideSprite = Bread;
                
                BaitAmt.text = GlobalStats.Instance.BreadAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Galunggong";
                break;

            case GlobalStats.BaitType.Insects:
                BaitImg.overrideSprite = Insect;
                BaitAmt.text = GlobalStats.Instance.InsectAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Tilapia";
                break;

            case GlobalStats.BaitType.Worms:
                BaitImg.overrideSprite = Worm;
                BaitAmt.text = GlobalStats.Instance.WormAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Lapu-Lapu";
                break;
        }
        BaitTitle.text = GlobalStats.Instance.CurrentBait.ToString();
        BaitBreadAmt.text = GlobalStats.Instance.BreadAmt.ToString();
        BaitInsectAmt.text = GlobalStats.Instance.InsectAmt.ToString();
        BaitWormsAmt.text = GlobalStats.Instance.WormAmt.ToString();
    }

    public void SelectGear()
    {
        ActiveTab = Tab.Gear;
        SFXcontroller.instance.PlaySingle(TabSfx);
    }

    public void SelectBait()
    {
        ActiveTab = Tab.Bait;
        SFXcontroller.instance.PlaySingle(TabSfx);
    }

    public void ChangeGear()
    {
        SFXcontroller.instance.PlaySingle(Next);
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Rod;
                break;

            case GlobalStats.NetType.Rod:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Trawling;
                break;

            case GlobalStats.NetType.Trawling:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Cast;
                break;
        }
    }

    public void ChangeBait()
    {
        SFXcontroller.instance.PlaySingle(Next);
        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Insects;
                break;

            case GlobalStats.BaitType.Insects:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Worms;
                break;

            case GlobalStats.BaitType.Worms:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Bread;
                break;
        }
    }

    public void StartFishing()
    {
        SFXcontroller.instance.PlaySingle(StartFish);
        FishingScene.SetActive(true);
        FishingScene.GetComponent<MainFishing>().Started = true;

        switch(GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.SandyShoals:
                GlobalStats.Instance.AdvanceTime(GlobalStats.Instance.SSHours);
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                GlobalStats.Instance.AdvanceTime(GlobalStats.Instance.ERHours);
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                GlobalStats.Instance.AdvanceTime(GlobalStats.Instance.LIHours);
                break;
        }
    }

    public void ReturnToMap()
    {
        SFXcontroller.instance.PlaySingle(Return);
        LoadingScreen.Instance.LoadScene("1_MapSelector");
        //SceneManager.LoadScene("1_MapSelector");
    }
    
}
