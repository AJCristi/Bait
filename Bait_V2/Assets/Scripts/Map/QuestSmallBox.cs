using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestSmallBox : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
{

    public bool OnHover;
    // Start is called before the first frame update
    void Start()
    {
        OnHover = false;
    }

  
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnHover = false;
    }
}
