using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BaitDisplay : MonoBehaviour, IPointerEnterHandler
     , IPointerExitHandler
{
    public GameObject Window;

    public Text Bread, Insects, Worms;

    public AudioClip Select;

    // Start is called before the first frame update
    void Start()
    {
        Window.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Bread.text = GlobalStats.Instance.BreadAmt.ToString();
        Insects.text = GlobalStats.Instance.InsectAmt.ToString();
        Worms.text = GlobalStats.Instance.WormAmt.ToString();
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
