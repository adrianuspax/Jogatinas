using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Assignments : MonoBehaviour
{
    #region Variables
    public delegate void ButtonsBehaviour(int index);

    #endregion
    #region Unity_Functions
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }
    #endregion
    #region voids
    public void Assignment(Button[] buttons, bool[] isPressed, Transform header, ButtonsBehaviour behaviour)
    {        
        StartCoroutine(Cor_Assignment(buttons, isPressed, header, behaviour));
    }

    public void Buttons(int index, Button[] button, bool[] isPressed, Color btnPressed, Color btnUnpressed)
    {
        StartCoroutine(Cor_Buttons(index, button, isPressed, btnPressed, btnUnpressed));
    }
    #endregion
    #region Coroutines
    private IEnumerator Cor_Assignment(Button[] buttons, bool[] isPressed, Transform header, ButtonsBehaviour behaviour)
    {
        /*yield return null;        
        buttons = new Button[header.childCount];
        yield return null;
        isPressed = new bool[buttons.Length];

        yield return new WaitForEndOfFrame();

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i] = header.GetChild(i).GetComponent<Button>();
        }

        yield return new WaitForEndOfFrame();*/

        for (int index = 0; index < buttons.Length; index++)
        {
            buttons[index] = header.GetChild(index).GetComponent<Button>();
            buttons[index].onClick = new Button.ButtonClickedEvent();
            buttons[index].onClick.AddListener(() => behaviour(index));
        }
        yield return null;
    }

    private IEnumerator Cor_Buttons(int index, Button[] button, bool[] isPressed, Color btnPressed, Color btnUnpressed)
    {
        isPressed[index] = !isPressed[index];

        for (int i = 0; i < button.Length; i++)
        {
            if (i == index && isPressed[index])
            {
                button[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                button[index].image.color = btnPressed;
            }
            else
            {
                button[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                button[i].image.color = btnUnpressed;
                isPressed[i] = false;
            }
        }

        yield return null;
    }
    #endregion
}
