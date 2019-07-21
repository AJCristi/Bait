using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverWeather : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Text Title, Desc;

    public GameObject Obj;

    // Start is called before the first frame update
    void Start()
    {
        Obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GlobalStats.Instance.Forecast)
        {
            case GlobalStats.Weather.Overcast:
                Title.text = "Overcast";
                Desc.text = "More Fish";
                break;

            case GlobalStats.Weather.Rainy:
                Title.text = "Rain";
                Desc.text = "Less Fish";
                break;

            case GlobalStats.Weather.Sunny:
                Title.text = "Sunny";
                Desc.text = "No bonus";
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Obj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Obj.SetActive(false);
    }
}
