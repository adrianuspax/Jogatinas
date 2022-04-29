using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParOuImpar : MonoBehaviour
{    
    [Header("UI", order = 0)]
    public Button btnChoice;
    public Button btnStart;
    public Slider slrChoiceValue;
    [Space(-10, order = 0)]
    [Header("TMPro", order = 1)]
    public TextMeshProUGUI tmpHand2Value;
    public TextMeshProUGUI tmpResult;
    public TextMeshProUGUI tmpChoice;
    public TextMeshProUGUI tmpChoiceValue;
    [Space(-10, order = 0)]
    [Header("Sprites", order = 1)]
    public Sprite toggleOn;
    public Sprite toggleOff;
    [Space(-10, order = 0)]
    [Header("Values", order = 1)]
    [SerializeField][Range(0, 5)] private int intHand1;
    [SerializeField][Range(0, 5)] private int intHand2;
    [Space(-10, order = 0)]
    [Header("Bools", order = 1)]
    [SerializeField] private bool on;
    [SerializeField] private bool myChoice;

    private void Awake()
    {
        btnChoice.onClick = new Button.ButtonClickedEvent();
        btnChoice.onClick.AddListener(() => ButtonChoice());
        btnStart.onClick = new Button.ButtonClickedEvent();
        btnStart.onClick.AddListener(() => ButtonStart());   

        slrChoiceValue.onValueChanged.AddListener(SliderChoice);
    }

    private void Start()
    {
        on = true;
        ButtonChoice();
    }

    private void Update()
    {
        
    }

    public void ButtonStart()
    {
        tmpHand2Value.text = Hand2Behaviour().ToString();

        if (myChoice == Result())
        {
            StartCoroutine(Cor_Result(true));
        }
        else
        {
            StartCoroutine(Cor_Result(false));
        }
    }

    public void ButtonChoice()
    {
        on = !on;

        if (on)
        {
            btnChoice.image.sprite = toggleOn;
            tmpChoice.text = "ímpar";
        }

        if (!on)
        {
            btnChoice.image.sprite = toggleOff;
            tmpChoice.text = "Par";
        }

        myChoice = !on;
    }

    public void SliderChoice(float value)
    {
        tmpChoiceValue.text = value.ToString();

        intHand1 = (int)value;
    }

    public int Calc(int value1, int value2)
    {
        return (value1 + value2) % 2;
    }

    public int Calc(int value)
    {
        return value % 2;
    }

    public bool Result()
    {
        bool result;

        if (Calc(intHand1, intHand2) == 0)
        {
            result = true;
        }
        else
        {
            result = false;
        }

        return result;
    }

    public int Hand2Behaviour()
    {
        intHand2 = Random.Range(0, 5);
        return intHand2;
    }

    private IEnumerator Cor_Result(bool win)
    {
        if (win)
        {
            tmpResult.text = "You Win!";
        }
        else
        {
            tmpResult.text = "You Loose!";
        }

        btnStart.interactable = false;

        yield return new WaitForSeconds(3f);
                
        tmpResult.text = "";
        btnStart.interactable = true;
    }
}
