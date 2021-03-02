using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{

    public PlayerBehaviour player;
    public TMP_InputField nameInput;
    public Toggle showSlidersToggle;

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }

    public void ChangePlayerName()
    {
        player.SetName(nameInput.text);
    }

    public void OnToggleChanged()
    {
        player.SetSlidersVisibility(showSlidersToggle.isOn);
    }
}
