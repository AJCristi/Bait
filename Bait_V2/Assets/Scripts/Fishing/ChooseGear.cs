using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChooseGear : MonoBehaviour
{
    public Text CurNetTxt,CurNetDesc;
    public string NetTrawlDes, NetCastDes, NetRodDes;
    public Text CurNetLvlTxt, CurNetLvlDesc;

    public Text CurBaitTxt, CurBaitDesc;
    public string BaitBreadDes, BaitInsectsDes, BaitWormsDes;
    public Text RemainingBait;

    public Text GalunChanceDis, TilaChanceDis, LapuChanceDis;

    public float GalunggongChances, TilapiaChances, LapuChances;

    public Button HeadOut;

    // Start is called before the first frame update
    void Start()
    {
        UpdateChances();
        HeadOut.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGear();
        //UpdateChances();

        GalunChanceDis.text = GalunggongChances.ToString() + " %";
        TilaChanceDis.text = TilapiaChances.ToString() + " %";
        LapuChanceDis.text = LapuChances.ToString() + " %";

        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                if (GlobalStats.Instance.BreadAmt > 0)
                {
                    HeadOut.interactable = true;
                }
                else
                {
                    HeadOut.interactable = false;
                }
                break;

            case GlobalStats.BaitType.Insects:
                if (GlobalStats.Instance.InsectAmt > 0)
                {
                    HeadOut.interactable = true;
                }
                else
                {
                    HeadOut.interactable = false;
                }
                break;

            case GlobalStats.BaitType.Worms:
                if (GlobalStats.Instance.WormAmt > 0)
                {
                    HeadOut.interactable = true;
                }
                else
                {
                    HeadOut.interactable = false;
                }
                break;
        }
    }

    void DisplayGear()
    {
        CurNetTxt.text = GlobalStats.Instance.CurrentNet.ToString();
       
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                CurNetLvlTxt.text = "Net Level : " + GlobalStats.Instance.CastNetLevel.ToString();
                CurNetDesc.text = NetCastDes;
                break;

            case GlobalStats.NetType.Trawling:
                CurNetLvlTxt.text = "Net Level : " + GlobalStats.Instance.TrawlingNetLevel.ToString();
                CurNetDesc.text = NetTrawlDes;
                break;

            case GlobalStats.NetType.Rod:
                CurNetLvlTxt.text = "Net Level : " + GlobalStats.Instance.RodNetLevel.ToString();
                CurNetDesc.text = NetRodDes;
                break;
        }

        CurBaitTxt.text = GlobalStats.Instance.CurrentBait.ToString();
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                CurBaitDesc.text = BaitBreadDes;
                RemainingBait.text = "You have " + GlobalStats.Instance.BreadAmt.ToString() + " left";
                break;

            case GlobalStats.BaitType.Insects:
                CurBaitDesc.text = BaitInsectsDes;
                RemainingBait.text = "You have " + GlobalStats.Instance.InsectAmt.ToString() + " left";
                break;

            case GlobalStats.BaitType.Worms:
                CurBaitDesc.text = BaitWormsDes;
                RemainingBait.text = "You have " + GlobalStats.Instance.WormAmt.ToString() + " left";
                break;
        }
    }

    public void ChangeNet()
    {
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Trawling:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Cast;
                break;

            case GlobalStats.NetType.Cast:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Rod;
                break;

            case GlobalStats.NetType.Rod:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Trawling;
                break;
        }
    }

    public void ChangeBait()
    {
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

    public void UpdateChances()
    {
        GalunggongChances = 40;
        TilapiaChances = 25;
        LapuChances = 10;

        switch (GlobalStats.Instance.SelectedLocation)
        {
            case GlobalStats.FishingLocation.SandyShoals:
                GalunggongChances += 10;
                TilapiaChances -= 5;
                LapuChances -= 5;
                break;

            case GlobalStats.FishingLocation.ExposedReef:
                GalunggongChances -= 5;
                TilapiaChances += 10;
                LapuChances -= 5;
                break;

            case GlobalStats.FishingLocation.LonelyIsland:
                GalunggongChances -= 5;
                TilapiaChances -= 5;
                LapuChances += 10;
                break;
        }
        
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                GalunggongChances += 5;
                TilapiaChances -= 5;
                LapuChances -= 5;
                break;

            case GlobalStats.BaitType.Insects:
                GalunggongChances -= 5;
                TilapiaChances += 5;
                LapuChances -= 5;
                break;

            case GlobalStats.BaitType.Worms:
                GalunggongChances -= 5;
                TilapiaChances -= 5;
                LapuChances += 5;
                break;
        }

        switch(GlobalStats.Instance.Forecast)
        {
            case GlobalStats.Weather.Overcast:
                GalunggongChances += 5;
                TilapiaChances += 5;
                LapuChances += 5;
                break;

            case GlobalStats.Weather.Sunny:
                GalunggongChances += 0;
                TilapiaChances += 0;
                LapuChances += 0;
                break;

            case GlobalStats.Weather.Rainy:
                GalunggongChances -= 10;
                TilapiaChances -= 10;
                LapuChances -= 10;
                break;
        }

        

        
    }
}
