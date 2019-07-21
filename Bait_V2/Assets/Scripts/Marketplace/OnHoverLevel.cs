using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OnHoverLevel : MonoBehaviour, IPointerEnterHandler, 
    IPointerExitHandler
{
    public GameObject Obj;
    public Text Leveltxt;
    public MainFishing MF;
    public ChoosingGear CG;

    // Start is called before the first frame update
    void Start()
    {
        Obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (CG.ReturnTempGear())
        {
            case "Cast":
                switch (GlobalStats.Instance.CastNetLevel)
                {
                    case 1:
                        Leveltxt.text = "Level " + GlobalStats.Instance.CastNetLevel.ToString()
                            + ": Fishes every 11 seconds";
                        break;

                    case 2:
                        Leveltxt.text = "Level " + GlobalStats.Instance.CastNetLevel.ToString()
                            + ": Fishes every 10 seconds";
                        break;

                    case 3:
                        Leveltxt.text = "Level " + GlobalStats.Instance.CastNetLevel.ToString()
                            + ": Fishes every 8 seconds";
                        break;

                    case 4:
                        Leveltxt.text = "Level " + GlobalStats.Instance.CastNetLevel.ToString()
                            + ": Fishes every 6.5 seconds";
                        break;

                    case 5:
                        Leveltxt.text = "Level " + GlobalStats.Instance.CastNetLevel.ToString()
                            + ": Fishes every 5 seconds";
                        break;
                }
                break;

            case "Rod":
                switch (GlobalStats.Instance.RodNetLevel)
                {
                    case 1:
                        Leveltxt.text = "Level " + GlobalStats.Instance.RodNetLevel.ToString()
                            + ": Fishes every 15 seconds";
                        break;

                    case 2:
                        Leveltxt.text = "Level " + GlobalStats.Instance.RodNetLevel.ToString()
                            + ": Fishes every 13 seconds";
                        break;

                    case 3:
                        Leveltxt.text = "Level " + GlobalStats.Instance.RodNetLevel.ToString()
                            + ": Fishes every 11 seconds";
                        break;

                    case 4:
                        Leveltxt.text = "Level " + GlobalStats.Instance.RodNetLevel.ToString()
                            + ": Fishes every 9 seconds";
                        break;

                    case 5:
                        Leveltxt.text = "Level " + GlobalStats.Instance.RodNetLevel.ToString()
                            + ": Fishes every 6 seconds";
                        break;
                }
                break;

            case "Trawl":
                switch (GlobalStats.Instance.TrawlingNetLevel)
                {
                    case 1:
                        Leveltxt.text = "Level " + GlobalStats.Instance.TrawlingNetLevel.ToString()
                            + ": Fishes every 20 seconds";
                        break;

                    case 2:
                        Leveltxt.text = "Level " + GlobalStats.Instance.TrawlingNetLevel.ToString()
                            + ": Fishes every 18 seconds";
                        break;

                    case 3:
                        Leveltxt.text = "Level " + GlobalStats.Instance.TrawlingNetLevel.ToString()
                            + ": Fishes every 15 seconds";
                        break;

                    case 4:
                        Leveltxt.text = "Level " + GlobalStats.Instance.TrawlingNetLevel.ToString()
                            + ": Fishes every 13 seconds";
                        break;

                    case 5:
                        Leveltxt.text = "Level " + GlobalStats.Instance.TrawlingNetLevel.ToString()
                            + ": Fishes every 10 seconds";
                        break;
                }
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Obj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        Obj.SetActive(false);
    }
}
