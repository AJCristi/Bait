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

        if(baitAmt <= 0)
        {
            DecreaseButton.interactable = false;
        }
        else
        {
            DecreaseButton.interactable = true;
        }

        if (GlobalStats.Instance.PlayerSavings < baitPrice)
        {
            BuyBtn.interactable = false;
        }
        else
        {
            BuyBtn.interactable = true;
        }
    }

    void CheckSelected()
    {
        CurSelectedTitle.text = GlobalStats.Instance.CurrentBait.ToString();

        switch (GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                CurSelectedImage.sprite = Bread;

                CurSelectedDesc.text = "Attracts more Galunggong";
                CurSelectedAmt.text = GlobalStats.Instance.BreadAmt.ToString();
                break;

            case GlobalStats.BaitType.Insects:
                CurSelectedImage.sprite = Insect;

                CurSelectedDesc.text = "Attracts more Tilapia";
                CurSelectedAmt.text = GlobalStats.Instance.InsectAmt.ToString();
                break;

            case GlobalStats.BaitType.Worms:
                CurSelectedImage.sprite = Worm;

                CurSelectedDesc.text = "Attracts more Lapu-Lapu";
                CurSelectedAmt.text = GlobalStats.Instance.WormAmt.ToString();
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
        baitAmt++;
    }

    public void DecreaseBaitAmt()
    {
        baitAmt--;
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
        }
    }
}
