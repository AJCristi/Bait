using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckDaysRemaining : MonoBehaviour, IPointerEnterHandler,
    IPointerExitHandler
{
    public GameObject DaysObj;
    public Text DaysRemainingText;

    void Start()
    {
        DaysObj.SetActive(false);
    }

    void Update()
    {
        int x = GlobalStats.Instance.EndDay - GlobalStats.Instance.Day ;
        DaysRemainingText.text = x.ToString() + " Day/s remaining";
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        DaysObj.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)

    {
        DaysObj.SetActive(false);
    }
}
