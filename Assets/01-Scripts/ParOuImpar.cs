using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParOuImpar : JogatinasBehaviours
{
    [Header("UI", order = 0)]
    public Button btnToggle;
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
    [SerializeField][Range(0, 5)] private int myFingers;
    [SerializeField][Range(0, 5)] private int iaFingers;
    [Space(-10, order = 0)]
    [Header("Bools", order = 1)]
    [SerializeField] private bool on;
    [SerializeField] private bool par;

    private void Awake()
    {
        btnToggle.onClick = new Button.ButtonClickedEvent();
        btnToggle.onClick.AddListener(() => ButtonChoice());
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
        ButtonInteractable(myHand.GetComponent<Button>(), true);

        StartCoroutine(Cor_Result(par == Result()));


        tmpTotalValue.text = (myFingers + iaFingers).ToString();
    }

    public void ButtonChoice()
    {
        on = !on;

        if (on)
        {
            btnToggle.image.sprite = toggleOn;
            tmpChoice.text = "ímpar";
        }

        if (!on)
        {
            btnToggle.image.sprite = toggleOff;
            tmpChoice.text = "Par";
        }

        par = !on;
    }

    public void SliderChoice(float value)
    {
        tmpChoiceValue.text = value.ToString();

        myFingers = (int)value;

        myHand.sprite = fingers[myFingers];
    }

    public int Calc(int value1, int value2)
    {
        return (value1 + value2) % 2;
    }

    public bool Result()
    {
        bool result;

        if (Calc(myFingers, iaFingers) == 0)
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
        iaFingers = Random.Range(0, 5);

        iaHand.sprite = fingers[iaFingers];

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
        ButtonInteractable(myHand.GetComponent<Button>(), false);
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
