using System;
using DG.Tweening;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private PlaySound music;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float fadeTime;
    [SerializeField] private float holdTime;

    private void Awake()
    {
        canvas.enabled = false;
    }

    [ContextMenu("Win")]
    public async void InitiateWin()
    {
        canvas.enabled = true;
        group.alpha = 0;
        FindAnyObjectByType<GamePause>().SetPause(false);
        FindAnyObjectByType<GamePause>().enabled = false;
        await Awaitable.WaitForSecondsAsync(holdTime);
        music.Play();
        group.DOFade(1, fadeTime);
        await Awaitable.WaitForSecondsAsync(fadeTime);
    }
}
