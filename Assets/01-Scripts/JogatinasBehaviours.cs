using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JogatinasBehaviours : MonoBehaviour
{
    public void ButtonInteractable(Button button, bool interactable)
    {
        StartCoroutine(Cor_Interactable(button, interactable));
    }

    IEnumerator Cor_Interactable(Button button, bool interactable)
    {
        Color32 color;

        button.interactable = interactable;
        color = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color;

        yield return null;

        if (interactable)
        {
            color.a = 255;
        }
        else
        {
            color.a = 55;
        }

        yield return null;
        
        button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;
    }
}

