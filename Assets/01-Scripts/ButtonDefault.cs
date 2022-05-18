using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonDefault : JogatinasBehaviours//, IPointerClickHandler
{
    public Button button;
    public Color onColor;
    public Color offColor;
    //public bool pressed;
    //public PointerEventData eventData;
    //public EventSystem eventSystem;

    private void Awake()
    {
        //eventData = new PointerEventData(eventSystem);
        button.onClick.AddListener(() => ButtonBehaviour());
    }

    private void Start()
    {
       
        //ButtonBehaviour(pressed);
    }

    public void ButtonBehaviour()
    {
        button.image.color = (button.image.color == onColor) ? offColor : onColor;
    }

}