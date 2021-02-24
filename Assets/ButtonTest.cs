using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    public Button button;
    public Text text;
    public TextMeshProUGUI text2;

    public void ChangeButton()
    {
        button.interactable = !button.interactable;
    }

    public void OnClick()
    {
        Debug.Log("click");
        text.text = "click";
        text2.text = "nieco";
    }
}
