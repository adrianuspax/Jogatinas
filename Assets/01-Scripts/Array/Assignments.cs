using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Assignments : MonoBehaviour
{
    #region Variables
    public delegate void ButtonsBehaviour(int index);
    public delegate void BehaviourDefault(int index, Button[] buttons, bool[] isPressed, Color isPressColor, Color noPressColor);
    #endregion
    #region Methods
    public (Button[], bool[]) Assignment(Transform header, params ButtonsBehaviour[] behaviour)
    {
        Button[] buttons;
        bool[] isPressed;
        buttons = new Button[header.childCount];
        isPressed = new bool[buttons.Length];

        for (int index = 0; index < buttons.Length; index++)
        {
            for (int i = 0; i < behaviour.Length; i++)
            {
                StartCoroutine(Cor_Assignment(index, buttons, header, behaviour[i]));
            }            
        }

        return (buttons, isPressed);
    }

    public void Default(int index, Button[] buttons, bool[] isPressed, Color isPressColor, Color noPressColor)
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

    #endregion
    #region Coroutines
    private IEnumerator Cor_Assignment(int index, Button[] buttons, Transform header, ButtonsBehaviour behaviour)
    {
        buttons[index] = header.GetChild(index).GetComponent<Button>();        
        buttons[index].onClick.AddListener(() => behaviour(index));
                
        yield return null;
    }
    #endregion
}
