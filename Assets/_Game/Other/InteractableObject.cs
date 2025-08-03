using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InteractableObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject activateWindow;
    [SerializeField] private float angle;
    [SerializeField] private float time;
    [SerializeField] private UnityEvent OnInteract;
    private Sequence seq;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        seq = DOTween.Sequence();
        seq.Append(transform.DORotate(new Vector3(0, 0, -angle), time / 2f).SetEase(Ease.Linear));
        seq.Append(transform.DORotate(new Vector3(0, 0, angle), time).SetEase(Ease.Linear));
        seq.Append(transform.DORotate(Vector3.zero, time / 2f).SetEase(Ease.Linear));
        seq.SetLoops(-1);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        seq.Kill(true);
        transform.eulerAngles = Vector3.zero;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        activateWindow.SetActive(true);
        OnInteract?.Invoke();
    }
}
