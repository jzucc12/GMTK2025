using System;
using TMPro;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private string myChar;
    [SerializeField] private TextMeshProUGUI display;
    public event Action<string> Pressed;


    private void OnValidate()
    {
        if (display)
        {
            display.text = myChar;
        }
    }

    public void OnPress()
    {
        Pressed?.Invoke(myChar);
    }
}
