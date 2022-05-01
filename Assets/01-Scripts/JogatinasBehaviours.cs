using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JogatinasBehaviours : MonoBehaviour
{
    public void Interactable(bool interactable, params Button[] button)
    {
        for (int i = 0; i < button.Length; i++)
        {
            int childCount;

            childCount = button[i].transform.childCount;

            if (childCount != 0)
            {
                for (int index = 0; index < childCount; index++)
                {
                    if (button[i].transform.GetChild(index).GetComponent<TextMeshProUGUI>() != null)
                    {
                        StartCoroutine(Cor_Interactable(button[i], interactable, index));
                        break;
                    }
                }
            }
            else
            {
                StartCoroutine(Cor_Interactable(button[i], interactable));
            }
        }
    }

    IEnumerator Cor_Interactable(Button button, bool interactable)
    {
        button.interactable = interactable;
        yield return null;
    }

    IEnumerator Cor_Interactable(Button button, bool interactable, int index)
    {
        Color32 color;

        button.interactable = interactable;
        color = button.transform.GetChild(index).GetComponent<TextMeshProUGUI>().color;

        yield return null;

        if (interactable)
        {
            color.a = 255;
        }
        else
        {
            color.a = 127;
        }

        yield return null;

        button.transform.GetChild(index).GetComponent<TextMeshProUGUI>().color = color;
    }
}

