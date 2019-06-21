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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckSelected();
        CalculatePrice();
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
                break;

            case GlobalStats.NetType.Rod:
                CurSelectedImage.sprite = Rod;

                CurSelectedDesc.text = "Uses 1 bait per cast";
                CurSelectedLvl.text = "Level: " + GlobalStats.Instance.RodNetLevel.ToString();
                break;

            case GlobalStats.NetType.Trawling:
                CurSelectedImage.sprite = Trawl;

                CurSelectedDesc.text = "Uses 10 bait per cast";
                CurSelectedLvl.text ="Level: "+ GlobalStats.Instance.TrawlingNetLevel.ToString();
                break;
        }
    }

    public void ChangeNet()
    {
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
                        curPrice = 200;
                        break;

                    case 2:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 300;
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
                        curPrice = 300;
                        break;

                    case 2:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 400;
                        break;

                    case 3:
                        BuyBtn.SetActive(true);
                        NetPrice.gameObject.SetActive(true);
                        curPrice = 500;
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
        }
    }
}
