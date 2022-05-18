using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BTNsManager : MonoBehaviour
{
    public Transform header;
    public Button[] buttons;
    public bool[] isPressed;
    public Color isPressColor;
    public Color noPressColor;

    private Assignments Assignments;

    public delegate void BehaviourButtons(int index);

    private void Awake()
    {
        New();
        Assignment(buttons, isPressed, header, ButtonsBehaviour);
    }

    private void Start()
    {
             
    }

    private void Update()
    {
        
    }

    public void ButtonsBehaviour(int index)
    {
        isPressed[index] = !isPressed[index];

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == index && isPressed[index])
            {
                buttons[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                buttons[index].image.color = isPressColor;
            }
            else
            {
                buttons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                buttons[i].image.color = noPressColor;
                isPressed[i] = false;
            }
        }
    }

    public void New()
    {
        buttons = new Button[header.childCount];
        isPressed = new bool[buttons.Length];        
    }

    public void Assignment(Button[] buttons, bool[] isPressed, Transform header, BehaviourButtons behaviour)
    {
        for (int index = 0; index < buttons.Length; index++)
        {
            StartCoroutine(Cor_Assignment(index, buttons, isPressed, header, behaviour));
        }
    }

    public IEnumerator Cor_New(Button[] buttons, bool[] isPressed, Transform header)
    {
        buttons = new Button[header.childCount];
        isPressed = new bool[buttons.Length];
        yield return null;
    }

    private IEnumerator Cor_Assignment(int index, Button[] buttons, bool[] isPressed, Transform header, BehaviourButtons behaviour)
    { 
        buttons[index] = header.GetChild(index).GetComponent<Button>();
        buttons[index].onClick = new Button.ButtonClickedEvent();
        buttons[index].onClick.AddListener(() => behaviour(index));
        yield return null;
    }
}
