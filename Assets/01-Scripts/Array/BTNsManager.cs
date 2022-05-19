using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BTNsManager : Assignments
{
    public Transform header;
    public Button[] buttons;
    public bool[] isPressed;
    public Color isPressColor;
    public Color noPressColor;

    private void Awake()
    {
        (buttons, isPressed) = Assignment(header, Behaviour, AnotherBehaviour);
    }

    private void Start()
    {
    
    }

    private void Update()
    {
        
    }

    public void Behaviour(int index) => Default(index, buttons, isPressed, isPressColor, noPressColor);

    public void AnotherBehaviour(int index)
    {
        Debug.Log("AnotherBehaviour");
    }
}
