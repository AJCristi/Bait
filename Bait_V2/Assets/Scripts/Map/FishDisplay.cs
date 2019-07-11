using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishDisplay : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
{

    public GameObject Window;

    public Text GG, Tilapia, Lapu2;
    public Text GGPcs, TilaPcs, LapuPcs;

    public AudioClip Select;

    // Start is called before the first frame update
    void Start()
    {
        Window.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GG.text = GlobalStats.Instance.smallKG.ToString("F2") + " kg";
        Tilapia.text = GlobalStats.Instance.medKG.ToString("F2") + " kg";
        Lapu2.text = GlobalStats.Instance.largeKG.ToString("F2") + " kg";

        GGPcs.text = GlobalStats.Instance.GGPieces.ToString();
        TilaPcs.text = GlobalStats.Instance.TilaPieces.ToString();
        LapuPcs.text = GlobalStats.Instance.LapuPieces.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SFXcontroller.instance.PlaySingle(Select);
        Window.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Window.SetActive(false);
    }
}
