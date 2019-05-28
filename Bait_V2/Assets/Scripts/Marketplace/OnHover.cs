using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour, IPointerEnterHandler
{
    public string ToolTipOnHover;
    public Text ToolTip;   

    public void OnPointerEnter(PointerEventData eventData)
    {        
        ToolTip.text = ToolTipOnHover;
    }       
}
