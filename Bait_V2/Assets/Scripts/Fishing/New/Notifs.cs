using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notifs : MonoBehaviour
{
    public GameObject BaitNotif;
    public Image BaitImg;
    public Sprite Bread, Insect, Worms;
    public Text BaitNum;

    public GameObject FishNotif;
    public Image FishImg;
    public Sprite GG, Tila, LL;
    public Text FishKGNum;

    public Image CurNet, CurBait;

    public Sprite Cast, Trawl, Rod;

    public GameObject GearNotif;
    public Image GearImg;  
    

    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        x = 4;
        y = 4;
        z = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(GlobalStats.Instance.CurrentBait)
        {
            case GlobalStats.BaitType.Bread:
                BaitImg.sprite = Bread;
                CurBait.sprite = Bread;
                break;

            case GlobalStats.BaitType.Insects:
                BaitImg.sprite = Insect;
                CurBait.sprite = Insect;
                break;

            case GlobalStats.BaitType.Worms:
                BaitImg.sprite = Worms;
                CurBait.sprite = Worms;
                break;
        }

        switch(GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Cast:
                CurNet.sprite = Cast;
                GearImg.sprite = Cast;
                BaitNum.text = "-5";
                break;

            case GlobalStats.NetType.Rod:
                CurNet.sprite = Rod;
                GearImg.sprite = Rod;
                BaitNum.text = "-1";
                break;

            case GlobalStats.NetType.Trawling:
                CurNet.sprite = Trawl;
                GearImg.sprite = Trawl;
                BaitNum.text = "-10";
                break;
        }
        

        x += Time.deltaTime;
        if (x > 4)
        {
            BaitNotif.SetActive(false);
        }
        else
        {
            BaitNotif.SetActive(true);
        }

        y += Time.deltaTime;
        if (y > 4)
        {
            FishNotif.SetActive(false);
        }
        else
        {
            FishNotif.SetActive(true);
        }

        z += Time.deltaTime;
        if (z > 4)
        {
            GearNotif.SetActive(false);
        }
        else
        {
            GearNotif.SetActive(true);
        }
    }

    public void ActivateBait()
    {
        x = 0;
        Debug.Log("Bait notif");
    }

    public void ActivateFish(int type, float KgAmt)
    {
        y = 0;
        switch (type)
        {
            case 1:
                FishImg.sprite = GG;
                break;

            case 2:
                FishImg.sprite = Tila;
                break;

            case 3:
                FishImg.sprite = LL;
                break;
        }
        FishKGNum.text = "+" + KgAmt.ToString();
        Debug.Log("Fish notif");
    }

    public void ActivateGear()
    {
        z = 0;
        Debug.Log("Gear Notif");
    }

    public void NoCatch()
    {
        y = 5;
        Debug.Log("None");
    }
}
