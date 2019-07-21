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

    enum tempGear
    {
        Rod,
        Cast,
        Trawl
    }
    tempGear tempgear;

    enum tempBait
    {
        Bread,
        Insects,
        Worm
    }
    tempBait tempbait;

    public Image NetImg;
    public Sprite Rod, Cast, Trawl;
    public Text NetTitle, NetLevel, NetDesc, NetDesc2;
    public Text NetPieces;

    public Text RodAmt, CastAmt, TrawlAmt;

    public Image BaitImg;
    public Sprite Bread, Insect, Worm;
    public Text BaitTitle, BaitAmt, BaitDesc;

    public Text BaitBreadAmt, BaitInsectAmt, BaitWormsAmt;

    public Image FishIndic;
    public Sprite GG, Tila, LL;

    public GameObject FishingScene;

    public Text LocationName,Hours;

    public Button StartBtn;
    public bool CanStart;

    public AudioClip Return, Next, TabSfx, StartFish;

    public Button SelectGearBtn, SelectBaitBtn;

    public Text SelectedGearText, SelectedBaitText;
    public Image SelectedGearImg, SelectedBaitImg;

    public AudioClip Selected;

    public GameObject CurrentlySelectedGear, CurrentlySelectedBait;

    public MapTimeAnim MTA;

    public string ReturnActiveTab()
    {
        return ActiveTab.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        ActiveTab = Tab.Bait;
        tempgear = tempGear.Cast;
        CanStart = false;
        FishingScene.SetActive(false);
        LocationName.text = GlobalStats.Instance.SelectedLocation.ToString();

        CurrentlySelectedGear.SetActive(false);
        CurrentlySelectedBait.SetActive(false);

        switch (GlobalStats.Instance.SelectedLocation)
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

    public string ReturnTempGear()
    {
        return tempgear.ToString();
    }

    public string ReturnTempBait()
    {
        return tempbait.ToString();
    }

    public void SelectedNet()
    {
        SFXcontroller.instance.PlaySingle(Selected);
        switch(tempgear)
        {
            case tempGear.Cast:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Cast;
                break;

            case tempGear.Rod:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Rod;
                break;

            case tempGear.Trawl:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Trawling;
                break;
        }
    }

    public void SelectedBait()
    {
        SFXcontroller.instance.PlaySingle(Selected);
        switch (tempbait)
        {
            case tempBait.Bread:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Bread;
                break;

            case tempBait.Insects:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Insects;
                break;

            case tempBait.Worm:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Worms;
                break;
        }
    }

    void CheckCurrentEquips()
    {
        switch(tempgear)
        {
            case tempGear.Cast:  
                if(GlobalStats.Instance.CurrentNet == GlobalStats.NetType.Cast)
                {
                    CurrentlySelectedGear.SetActive(true);
                    SelectGearBtn.interactable = false;
                }
                else
                {
                    CurrentlySelectedGear.SetActive(false);
                    if (GlobalStats.Instance.CastPieces <= 0)
                    {
                        SelectGearBtn.interactable = false;
                        break;
                    }
                    else
                    {
                        SelectGearBtn.interactable = true;
                    }
                }

                
                break;

            case tempGear.Rod:
                if (GlobalStats.Instance.CurrentNet == GlobalStats.NetType.Rod)
                {
                    CurrentlySelectedGear.SetActive(true);
                    SelectGearBtn.interactable = false;
                }
                else
                {
                    CurrentlySelectedGear.SetActive(false);
                    if (GlobalStats.Instance.RodPieces <= 0)
                    {
                        SelectGearBtn.interactable = false;
                        break;
                    }
                    else
                    {
                        SelectGearBtn.interactable = true;
                    }
                }


               

                break;

            case tempGear.Trawl:

               
                if (GlobalStats.Instance.CurrentNet == GlobalStats.NetType.Trawling)
                {
                    CurrentlySelectedGear.SetActive(true);
                    SelectGearBtn.interactable = false;
                }
                else
                {
                    CurrentlySelectedGear.SetActive(false);
                    if (GlobalStats.Instance.TrawlPieces <= 0)
                    {
                        SelectGearBtn.interactable = false;
                        break;
                    }
                    else
                    {
                        SelectGearBtn.interactable = true;
                    }
                }

                
                break;
        }

        switch(tempbait)
        {
            case tempBait.Bread:
                

                if(GlobalStats.Instance.CurrentBait == GlobalStats.BaitType.Bread)
                {
                    CurrentlySelectedBait.SetActive(true);
                    SelectBaitBtn.interactable = false;
                }
                else
                {
                    CurrentlySelectedBait.SetActive(false);
                    if (GlobalStats.Instance.BreadAmt <= 0)
                    {
                        SelectBaitBtn.interactable = false;
                        break;
                    }
                    else
                    {
                        SelectBaitBtn.interactable = true;
                    }
                }

               
                break;

            case tempBait.Insects:

                
                if (GlobalStats.Instance.CurrentBait == GlobalStats.BaitType.Insects)
                {
                    CurrentlySelectedBait.SetActive(true);
                    SelectBaitBtn.interactable = false;
                }
                else
                {
                    CurrentlySelectedBait.SetActive(false);
                    if (GlobalStats.Instance.InsectAmt <= 0)
                    {
                        SelectBaitBtn.interactable = false;
                        break;
                    }
                    else
                    {
                        SelectBaitBtn.interactable = true;
                    }
                }

                
                break;

            case tempBait.Worm:

                
                if (GlobalStats.Instance.CurrentBait == GlobalStats.BaitType.Worms)
                {
                    CurrentlySelectedBait.SetActive(true);
                    SelectBaitBtn.interactable = false;
                }
                else
                {
                    CurrentlySelectedBait.SetActive(false);
                    if (GlobalStats.Instance.WormAmt <= 0)
                    {
                        SelectBaitBtn.interactable = false;
                        break;
                    }
                    else
                    {
                        SelectBaitBtn.interactable = true;
                    }
                }
               
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

        CheckCurrentEquips();
        UpdateNet();
        UpdateBait();

        SelectedGearText.text = GlobalStats.Instance.CurrentNet.ToString();
        SelectedBaitText.text = GlobalStats.Instance.CurrentBait.ToString();

        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                SelectedGearImg.overrideSprite = Cast;
                break;

            case GlobalStats.NetType.Rod:
                SelectedGearImg.overrideSprite = Rod;
                break;

            case GlobalStats.NetType.Trawling:
                SelectedGearImg.overrideSprite = Trawl;
                break;
        }

        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                SelectedBaitImg.overrideSprite = Bread;
                break;

            case GlobalStats.BaitType.Insects:
                SelectedBaitImg.overrideSprite = Insect;
                break;

            case GlobalStats.BaitType.Worms:
                SelectedBaitImg.overrideSprite = Worm;
                break;
        }
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
        //NetTitle.text = GlobalStats.Instance.CurrentNet.ToString();
        NetTitle.text = tempgear.ToString();

        switch (tempgear)
        {
            case tempGear.Cast:
                NetImg.sprite = Cast;
                NetLevel.text = "Level: " + GlobalStats.Instance.CastNetLevel.ToString();
                NetDesc.text = "Uses 5 bait per cast";
                NetDesc2.text = "Can catch up to 5 fish";
                NetPieces.text = GlobalStats.Instance.CastPieces.ToString() + " pieces";
                break;

            case tempGear.Rod:
                NetImg.sprite = Rod;
                NetLevel.text = "Level: " + GlobalStats.Instance.RodNetLevel.ToString();
                NetDesc.text = "Uses 1 bait per cast";
                NetDesc2.text = "Can catch only 1 fish";

                NetPieces.text = GlobalStats.Instance.RodPieces.ToString() + " pieces";
                break;

            case tempGear.Trawl:
                NetImg.sprite = Trawl;
                NetLevel.text = "Level: " + GlobalStats.Instance.TrawlingNetLevel.ToString();
                NetDesc.text = "Uses 10 bait per cast";
                NetDesc2.text = "Can catch up to 10 fish";

                NetPieces.text = GlobalStats.Instance.TrawlPieces.ToString() + " pieces";
                break;
        }

        RodAmt.text = GlobalStats.Instance.RodPieces.ToString();
        CastAmt.text = GlobalStats.Instance.CastPieces.ToString();
        TrawlAmt.text = GlobalStats.Instance.TrawlPieces.ToString();
    }

    void UpdateBait()
    {
        switch(tempbait)
        {
            case tempBait.Bread:
                BaitImg.overrideSprite = Bread;
                FishIndic.overrideSprite = GG;
                BaitAmt.text = GlobalStats.Instance.BreadAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Galunggong";

                break;

            case tempBait.Insects:
                BaitImg.overrideSprite = Insect;
                FishIndic.overrideSprite = Tila;
                BaitAmt.text = GlobalStats.Instance.InsectAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Tilapia";
                break;

            case tempBait.Worm:
                BaitImg.overrideSprite = Worm;
                FishIndic.overrideSprite = LL;
                BaitAmt.text = GlobalStats.Instance.WormAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Lapu-Lapu";
                break;
        }
        BaitTitle.text = tempbait.ToString();
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

    public void ChangeGearRight()
    {
        SFXcontroller.instance.PlaySingle(Next);
        switch (tempgear)
        {
            case tempGear.Cast:
                tempgear = tempGear.Rod;
                break;

            case tempGear.Rod:
                tempgear = tempGear.Trawl;
                break;

            case tempGear.Trawl:
                tempgear = tempGear.Cast;
                break;
        }
    }

    public void ChangeGearLeft()
    {
        SFXcontroller.instance.PlaySingle(Next);
        switch (tempgear)
        {
            case tempGear.Cast:
                tempgear = tempGear.Trawl;
                break;

            case tempGear.Rod:
                tempgear = tempGear.Cast;
                break;

            case tempGear.Trawl:
                tempgear = tempGear.Rod;
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

    public void ChangeBaitRight()
    {
        SFXcontroller.instance.PlaySingle(Next);
        switch (tempbait)
        {
            case tempBait.Bread:
                tempbait = tempBait.Insects;
                break;

            case tempBait.Insects:
                tempbait = tempBait.Worm;
                break;
            case tempBait.Worm:
                tempbait = tempBait.Bread;
                break;
        }
    }

    public void ChangeBaitLeft()
    {
        SFXcontroller.instance.PlaySingle(Next);
        switch (tempbait)
        {
            case tempBait.Bread:
                tempbait = tempBait.Worm;
                break;

            case tempBait.Insects:
                tempbait = tempBait.Bread;
                break;
            case tempBait.Worm:
                tempbait = tempBait.Insects;
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
                MTA.StartAnimation(GlobalStats.Instance.CurTime);
                GlobalStats.Instance.AdvanceTime(GlobalStats.Instance.SSHours);
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                MTA.StartAnimation(GlobalStats.Instance.CurTime);
                GlobalStats.Instance.AdvanceTime(GlobalStats.Instance.ERHours);
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                MTA.StartAnimation(GlobalStats.Instance.CurTime);
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
