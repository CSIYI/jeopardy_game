using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool IsHover { get; set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHover = false;
    }
}
