using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinalBossEnemy : MonoBehaviour, IPointerEnterHandler
{
    public static event Action oof;
    public void OnPointerEnter(PointerEventData eventData)
    {
        oof?.Invoke();
    }
}
