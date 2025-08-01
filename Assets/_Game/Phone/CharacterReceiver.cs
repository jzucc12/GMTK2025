using UnityEngine;

public class CharacterCodeReceiver : CodeReceiver
{
    [SerializeField] private CharacterButton[] senders;

    protected override void OnEnable()
    {
        base.OnEnable();
        foreach (CharacterButton sender in senders)
        {
            sender.Pressed += AddToCode;
        }
    }
    
    protected override void OnDisable()
    {
        base.OnDisable();
        foreach (CharacterButton sender in senders)
        {
            sender.Pressed -= AddToCode;
        }
    }
}