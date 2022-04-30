using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParOuImpar : JogatinasBehaviours
{
    [Header("UI", order = 0)]
    public Button btnChoice;
    public Button btnStart;
    public Slider slrChoiceValue;
    [Space(-10, order = 0)]
    [Header("TMPro", order = 1)]
    public TextMeshProUGUI tmpTotalValue;
    public TextMeshProUGUI tmpResult;
    public TextMeshProUGUI tmpChoice;
    public TextMeshProUGUI tmpChoiceValue;
    [Space(-10, order = 0)]
    [Header("Images", order = 1)]
    public Image myHand;
    public Image iaHand;

    [Header("SPRITES", order = 0)]
    [Space(-10, order = 1)]
    [Header("Toggles", order = 2)]
    public Sprite toggleOn;
    public Sprite toggleOff;
    [Space(-10, order = 0)]
    [Header("fingers", order = 1)]
    public Sprite[] fingers;

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
        StatusDefault();
    }

    public void ButtonStart()
    {
        IAHandBehaviour();
        myHand.GetComponent<Button>().interactable = true;

        StartCoroutine(Cor_Result(myChoice == Result()));


        tmpTotalValue.text = (intHand1 + intHand2).ToString();
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

        myHand.sprite = fingers[intHand1];
    }

    public int Calc(int value1, int value2)
    {
        return (value1 + value2) % 2;
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

    public void IAHandBehaviour()
    {
        intHand2 = Random.Range(0, 5);

        iaHand.sprite = fingers[intHand2];

        iaHand.gameObject.SetActive(true);
    }

    public void StatusDefault()
    {
        on = true;
        ButtonChoice();
        iaHand.gameObject.SetActive(false);
        tmpTotalValue.text = "";
        tmpResult.text = "";
        ButtonInteractable(btnStart, true);
        SliderChoice(0);
        slrChoiceValue.value = 0;
        myHand.GetComponent<Button>().interactable = false;
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

        ButtonInteractable(btnStart, false);

        yield return new WaitForSeconds(3f);

        StatusDefault();
    }
}
