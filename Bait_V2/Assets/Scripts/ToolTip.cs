using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
{
    public string ToDisplay;
    public GameObject ToolTipOBJ;
    public Text TTText;


    // Start is called before the first frame update
    void Start()
    {
        ToolTipOBJ.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TTText.text = ToDisplay;
        ToolTipOBJ.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipOBJ.SetActive(false);
    }
}
