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

    public Image BaitImg;
    public Sprite Bread, Insect, Worm;
    public Text BaitTitle, BaitAmt, BaitDesc;

    public Text BaitBreadAmt, BaitInsectAmt, BaitWormsAmt;

    public GameObject FishingScene;

    public Text LocationName,Hours;

    // Start is called before the first frame update
    void Start()
    {
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
        switch(ActiveTab)
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

        UpdateNet();
        UpdateBait();
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
                break;

            case GlobalStats.NetType.Rod:
                NetImg.sprite = Rod;
                NetLevel.text = "Level: " + GlobalStats.Instance.RodNetLevel.ToString();
                NetDesc.text = "Uses 1 bait per cast";
                break;

            case GlobalStats.NetType.Trawling:
                NetImg.sprite = Trawl;
                NetLevel.text = "Level: " + GlobalStats.Instance.TrawlingNetLevel.ToString();
                NetDesc.text = "Uses 10 bait per cast";
                break;
        }
    }

    void UpdateBait()
    {
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                BaitImg.sprite = Bread;
                BaitAmt.text = GlobalStats.Instance.BreadAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Galunggong";
                break;

            case GlobalStats.BaitType.Insects:
                BaitImg.sprite = Insect;
                BaitAmt.text = GlobalStats.Instance.InsectAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Tilapia";
                break;

            case GlobalStats.BaitType.Worms:
                BaitImg.sprite = Worm;
                BaitAmt.text = GlobalStats.Instance.WormAmt.ToString() + " Pieces left";
                BaitDesc.text = "Attracts more Lapu-Lapu";
                break;
        }

        BaitBreadAmt.text = GlobalStats.Instance.BreadAmt.ToString();
        BaitInsectAmt.text = GlobalStats.Instance.InsectAmt.ToString();
        BaitWormsAmt.text = GlobalStats.Instance.WormAmt.ToString();
    }

    public void SelectGear()
    {
        ActiveTab = Tab.Gear;
    }

    public void SelectBait()
    {
        ActiveTab = Tab.Bait;
    }

    public void ChangeGear()
    {
        switch(GlobalStats.Instance.CurrentNet)
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
        switch(GlobalStats.Instance.CurrentBait)
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
        SceneManager.LoadScene("1_MapSelector");
    }
    
}
