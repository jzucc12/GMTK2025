using TMPro;
using UnityEngine;

public class PhoneApp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialedNumber;
    private CharacterCodeReceiver receiver;


    private void Awake()
    {
        receiver = GetComponent<CharacterCodeReceiver>();
    }
    
    private void OnEnable()
    {
        receiver.OnCodeChanged += UpdateOutput;
    }

    private void OnDisable()
    {
        receiver.OnCodeChanged -= UpdateOutput;
    }

    private void UpdateOutput(string number)
    {
        string output = "";
        if (number.Length > 0)
        {
            output = "1(";
        }

        if (number.Length >= 3)
        {
            output += number.Substring(0, 3);
            output += ")";
            number = number.Remove(0, 3);
        }

        if (number.Length >= 4)
        {
            output += number.Substring(0, 3);
            output += "-";
            number = number.Remove(0, 3);
            output += number.Substring(0, 1);
            number = number.Remove(0, 1);
        }

        output += number;

        dialedNumber.text = output;
    }
}
