using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    [field: SerializeField] public string myChar { get; private set; }
    [SerializeField] private TextMeshProUGUI display;
    [field: SerializeField] public Button MyButton { get; private set; }
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
