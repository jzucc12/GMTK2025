using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

public class CodeReceiver : MonoBehaviour
{
    [SerializeField] private int maxCodeLength;
    [SerializeField] private string[] codes;
    [SerializeField] private UnityEvent[] results;
    [SerializeField] private UnityEvent defaultResult;
    private Dictionary<string, UnityEvent> codeSets = new();
    private StringBuilder currentCode;
    public event Action<string> OnCodeChanged;


    private void OnValidate()
    {
        if (codes.Length != results.Length)
        {
            Debug.LogError($"{name} has {codes.Length} codes but {results.Length} results. These must match!");
        }
    }

    protected virtual void Awake()
    {
        for (int ii = 0; ii < codes.Length; ii++)
        {
            codeSets.Add(codes[ii], results[ii]);
        }
    }

    protected virtual void OnEnable() { }
    protected virtual void OnDisable() { }

    protected virtual void Start()
    {
        currentCode = new StringBuilder();
        ResetCode();
    }

    public void SubmitCode()
    {
        foreach (var pair in codeSets)
        {
            if (pair.Key != currentCode.ToString()) continue;
            pair.Value?.Invoke();
            return;
        }
        defaultResult?.Invoke();
    }

    public void DeleteChar()
    {
        currentCode.Remove(currentCode.Length - 1, 1);
        OnCodeChanged?.Invoke(currentCode.ToString());
    }
    
    public void AddToCode(string addOn)
    {
        currentCode.Append(addOn);
        if (currentCode.Length > maxCodeLength)
        {
            currentCode.Remove(maxCodeLength, currentCode.Length-maxCodeLength);
        }
        OnCodeChanged?.Invoke(currentCode.ToString());
    }

    public void ResetCode()
    {
        currentCode.Clear();
        OnCodeChanged?.Invoke(currentCode.ToString());
    }
}