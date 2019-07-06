using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicChanger : MonoBehaviour
{
    public Image Graphic;

    public Sprite RodDefault, RodCaught, RodNone;
    public Sprite CastDefault, CastCaught, CastNone;
    public Sprite TrawlDefault, TrawlCaught, TrawlNone;

    public enum FishingState
    {
        Default,
        Caught,
        None
    }
    public FishingState CurrentFState;

    // Start is called before the first frame update
    void Start()
    {
        //Graphic.sprite = null;
    }

    public void Default()
    {
        CurrentFState = FishingState.Default;
    }

    public void Caught()
    {
        CurrentFState = FishingState.Caught;
    }

    public void None()
    {
        CurrentFState = FishingState.None;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CurrentFState);
        switch(CurrentFState)
        {
            case FishingState.Default:
                AssignDefault();
                break;

            case FishingState.Caught:
                AssignCaught();
                break;

            case FishingState.None:
                AssignNone();
                break;

        }
    }

    void AssignDefault()
    {
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Rod:
                Graphic.overrideSprite = RodDefault;
                break;

            case GlobalStats.NetType.Cast:
                Graphic.overrideSprite = CastDefault;
                break;

            case GlobalStats.NetType.Trawling:
                Graphic.overrideSprite = TrawlDefault;
                break;

        }
    }

    void AssignCaught()
    {
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Rod:
                Graphic.overrideSprite = RodCaught;
                break;

            case GlobalStats.NetType.Cast:
                Graphic.overrideSprite = CastCaught;
                break;

            case GlobalStats.NetType.Trawling:
                Graphic.overrideSprite = TrawlCaught;
                break;
        }
    }

    void AssignNone()
    {
        switch (GlobalStats.Instance.CurrentNet)
        {
            case GlobalStats.NetType.Rod:
                Graphic.overrideSprite = RodNone;
                break;

            case GlobalStats.NetType.Cast:
                Graphic.overrideSprite = CastNone;
                break;

            case GlobalStats.NetType.Trawling:
                Graphic.overrideSprite = TrawlNone;
                break;
        }
    }
}
