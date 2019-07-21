using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetTab : MonoBehaviour
{
    public Sprite Rod, Trawl, Cast;

    public Image CurSelectedImage;

    public Text CurSelectedTitle, CurSelectedDesc, CurSelectedLvl;

    public Text NetPrice;
    float curPrice;

    public GameObject BuyBtn;

    public Text RodAmt, CastAmt, TrawlAmt;
    public Text CurSelectedAmt, CurSelectedPrice;

    public GameObject BuyNetBtn;
    float gearPrice;

    public AudioClip BuySFX;
    public AudioClip Switch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelected();
        CalculatePrice();

        CheckNets();
        
        if (GlobalStats.Instance.PlayerSavings < curPrice)
        {
            BuyBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            BuyBtn.GetComponent<Button>().interactable = true;
        }

        if (GlobalStats.Instance.PlayerSavings < gearPrice)
        {
            BuyNetBtn.GetComponent<Button>().interactable = false;
        }
        else
        {
            BuyNetBtn.GetComponent<Button>().interactable = true;
        }
    }

    void CheckSelected()
    {
        CurSelectedTitle.text = GlobalStats.Instance.CurrentNet.ToString();

        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                CurSelectedImage.sprite = Cast;

                CurSelectedDesc.text = "Uses 5 bait per cast";
                CurSelectedLvl.text = "Level: " + GlobalStats.Instance.CastNetLevel.ToString();

                CurSelectedAmt.text = GlobalStats.Instance.CastPieces.ToString() + " pieces";
                break;

            case GlobalStats.NetType.Rod:
                CurSelectedImage.sprite = Rod;

                CurSelectedDesc.text = "Uses 1 bait per cast";
                CurSelectedLvl.text = "Level: " + GlobalStats.Instance.RodNetLevel.ToString();

                CurSelectedAmt.text = GlobalStats.Instance.RodPieces.ToString() + " pieces";
                break;

            case GlobalStats.NetType.Trawling:
                CurSelectedImage.sprite = Trawl;

                CurSelectedDesc.text = "Uses 10 bait per cast";
                CurSelectedLvl.text ="Level: "+ GlobalStats.Instance.TrawlingNetLevel.ToString();

                CurSelectedAmt.text = GlobalStats.Instance.TrawlPieces.ToString() + " pieces";
                break;
        }
    }

    public void ChangeNet()
    {
        SFXcontroller.instance.PlaySingle(Switch);
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

    public void ChangeNetLeft()
    {
        SFXcontroller.instance.PlaySingle(Switch);
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Trawling;
                break;

            case GlobalStats.NetType.Rod:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Cast;
                break;

            case GlobalStats.NetType.Trawling:
                GlobalStats.Instance.CurrentNet = GlobalStats.NetType.Rod;
                break;
        }
    }

    void CalculatePrice()
    {
        NetPrice.text = curPrice.ToString();
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                switch(GlobalStats.Instance.CastNetLevel)
                {
                    case 1:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 250;
                        break;

                    case 2:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 350;
                        break;

                    case 3:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 400;
                        break;

                    case 4:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 500;
                        break;

                    case 5:
                        BuyBtn.SetActive(false);
                        NetPrice.gameObject.SetActive(false);
                        break;                  
                }
                break;

            case GlobalStats.NetType.Rod:
                switch (GlobalStats.Instance.RodNetLevel)
                {
                    case 1:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 200;
                        break;

                    case 2:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 250;
                        break;

                    case 3:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 300;
                        break;

                    case 4:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 350;
                        break;

                    case 5:
                        BuyBtn.SetActive(false);
                        NetPrice.gameObject.SetActive(false);
                        break;
                }
                break;

            case GlobalStats.NetType.Trawling:
                switch (GlobalStats.Instance.TrawlingNetLevel   )
                {
                    case 1:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 350;
                        break;

                    case 2:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 450;
                        break;

                    case 3:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 550;
                        break;

                    case 4:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 700;
                        break;

                    case 5:
                        BuyBtn.SetActive(false);
                        NetPrice.gameObject.SetActive(false);
                        break;
                }
                break;
        }
    }

    public void Buy()
    {
        if (GlobalStats.Instance.PlayerSavings >= curPrice)
        {
            switch(GlobalStats.Instance.CurrentNet)
            {
                case GlobalStats.NetType.Cast:
                    GlobalStats.Instance.CastNetLevel++;
                    break;

                case GlobalStats.NetType.Rod:
                    GlobalStats.Instance.RodNetLevel++;
                    break;

                case GlobalStats.NetType.Trawling:
                    GlobalStats.Instance.TrawlingNetLevel++;
                    break;
            }
            GlobalStats.Instance.PlayerSavings -= curPrice;
            SFXcontroller.instance.PlaySingle(BuySFX);
        }
    }

    void CheckNets()
    {
        RodAmt.text = GlobalStats.Instance.RodPieces.ToString();
        CastAmt.text = GlobalStats.Instance.CastPieces.ToString();
        TrawlAmt.text = GlobalStats.Instance.TrawlPieces.ToString();

        CurSelectedPrice.text = gearPrice.ToString();

        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                gearPrice = 20;
                break;

            case GlobalStats.NetType.Rod:
                gearPrice = 10;
                break;

            case GlobalStats.NetType.Trawling:
                gearPrice = 30;
                break;
        }
    }

    public void BuyNet()
    {
        if (GlobalStats.Instance.PlayerSavings >= gearPrice)
        {
            switch(GlobalStats.Instance.CurrentNet)
            {
                case GlobalStats.NetType.Cast:
                    GlobalStats.Instance.CastPieces++;
                    break;

                case GlobalStats.NetType.Rod:
                    GlobalStats.Instance.RodPieces++;
                    break;

                case GlobalStats.NetType.Trawling:
                    GlobalStats.Instance.TrawlPieces++;
                    break;
            }
            GlobalStats.Instance.PlayerSavings -= gearPrice;
            SFXcontroller.instance.PlaySingle(BuySFX);
        }
    }
}
