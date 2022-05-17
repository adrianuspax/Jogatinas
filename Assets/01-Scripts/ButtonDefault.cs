using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonDefault : JogatinasBehaviours, IPointerClickHandler
{
    public Button button;
    public Color onColor;
    public Color offColor;
    public bool pressed;
    public PointerEventData eventData;
    public EventSystem eventSystem;

    private void Awake()
    {
        eventData = new PointerEventData(eventSystem);
    }

    private void Start()
    {
        button.onClick.AddListener(() => OnPointerClick(eventData));
        ButtonBehaviour(pressed);
    }

    private void Update()
    {
        
    }

    public void ButtonBehaviour(bool on)
    {
        on = !on;

        button.image.color = on ? onColor : offColor;

        pressed = on;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ButtonBehaviour(pressed);
        }
    }
}