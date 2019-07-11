using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestSmallBox : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
{

    public bool OnHover;
    public AudioClip Select;
    // Start is called before the first frame update
    void Start()
    {
        OnHover = false;
    }

  
    public void OnPointerEnter(PointerEventData eventData)
    {
        SFXcontroller.instance.PlaySingle(Select);
        OnHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnHover = false;
    }
}
