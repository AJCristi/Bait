using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaitTab : MonoBehaviour
{
    public Sprite Bread, Insect, Worm;

    public Image CurSelectedImage;

    public Text CurSelectedTitle, CurSelectedDesc, CurSelectedAmt;

    public Text BreadAmt, InsectAmt, WormAmt;

    int baitAmt;
    public Text BuyBaitAmt;

    float baitPrice;
    public Text BaitPriceTxt;

    public Button DecreaseButton, BuyBtn;

    public AudioClip Next, BuySFX;

    public Image FishIndic;
    public Sprite GG, Tila, LL;

    // Start is called before the first frame update
    void Start()
    {
        baitAmt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelected();
        ComputePrice(); 

        BreadAmt.text = GlobalStats.Instance.BreadAmt.ToString();
        InsectAmt.text = GlobalStats.Instance.InsectAmt.ToString();
        WormAmt.text = GlobalStats.Instance.WormAmt.ToString();

        BuyBaitAmt.text = baitAmt.ToString();

        if (GlobalStats.Instance.PlayerSavings < baitPrice)
        {
            BuyBtn.interactable = false;
        }
        else
        {
            BuyBtn.interactable = true;
        }

        if (baitAmt <= 0)
        {
            DecreaseButton.interactable = false;
            BuyBtn.interactable = false;
        }
        else
        {
            DecreaseButton.interactable = true;
            BuyBtn.interactable = true;
        }        
    }

    void CheckSelected()
    {
        CurSelectedTitle.text = GlobalStats.Instance.CurrentBait.ToString();

        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                CurSelectedImage.overrideSprite = Bread;

                CurSelectedDesc.text = "Attracts more Galunggong";
                CurSelectedAmt.text = GlobalStats.Instance.BreadAmt.ToString();

                FishIndic.overrideSprite = GG;
                break;

            case GlobalStats.BaitType.Insects:
                CurSelectedImage.overrideSprite = Insect;

                CurSelectedDesc.text = "Attracts more Tilapia";
                CurSelectedAmt.text = GlobalStats.Instance.InsectAmt.ToString();

                FishIndic.overrideSprite = Tila;
                break;

            case GlobalStats.BaitType.Worms:
                CurSelectedImage.overrideSprite = Worm;

                CurSelectedDesc.text = "Attracts more Lapu-Lapu";
                CurSelectedAmt.text = GlobalStats.Instance.WormAmt.ToString();

                FishIndic.overrideSprite = LL;
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

    public void ChangeBaitLeft()
    {
        SFXcontroller.instance.PlaySingle(Next);
        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Worms;
                break;

            case GlobalStats.BaitType.Insects:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Bread;
                break;

            case GlobalStats.BaitType.Worms:
                GlobalStats.Instance.CurrentBait = GlobalStats.BaitType.Insects;
                break;
        }
    }


    void ComputePrice()
    {
        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                baitPrice = baitAmt * 3;
                break;

            case GlobalStats.BaitType.Insects:
                baitPrice = baitAmt * 5;
                break;

            case GlobalStats.BaitType.Worms:
                baitPrice = baitAmt * 7;
                break;
        }
        BaitPriceTxt.text = baitPrice.ToString();
    }

    public void IncreaseBaitAmt()
    {
        SFXcontroller.instance.PlaySingle(Next);
        baitAmt++;
    }

    public void DecreaseBaitAmt()
    {
        baitAmt--;
        SFXcontroller.instance.PlaySingle(Next);
    }

    public void Buy()
    {
        if (GlobalStats.Instance.PlayerSavings >= baitPrice)
        {
            switch (GlobalStats.Instance.CurrentBait)
            {
                case GlobalStats.BaitType.Bread:
                    GlobalStats.Instance.BreadAmt += baitAmt;
                    break;

                case GlobalStats.BaitType.Insects:
                    GlobalStats.Instance.InsectAmt += baitAmt;
                    break;

                case GlobalStats.BaitType.Worms:
                    GlobalStats.Instance.WormAmt += baitAmt;
                    break;
            }
            GlobalStats.Instance.PlayerSavings -= baitPrice;
            SFXcontroller.instance.PlaySingle(BuySFX);
        }
    }
}
