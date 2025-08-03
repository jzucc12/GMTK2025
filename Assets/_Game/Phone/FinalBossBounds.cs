using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinalBossBounds : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private RectTransform image;
    [SerializeField] private bool setBoundsSelf;
    [SerializeField] private Vector2 selfBoundsMin;
    [SerializeField] private Vector2 selfBoundsMax;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    private Vector2 currentMove;
    private Vector2 startPos;
    public event Action oof;
    public bool move;
    public void OnPointerEnter(PointerEventData eventData)
    {
        oof?.Invoke();
    }

    private void Awake()
    {
        startPos = image.anchoredPosition;
        Reset();
        if (setBoundsSelf)
        {
            SetBounds(selfBoundsMin, selfBoundsMax);
        }
    }

    public void SetBounds(Vector2 min, Vector2 max)
    {
        minBounds = min;
        minBounds.x += image.sizeDelta.x / 2;
        minBounds.y += image.sizeDelta.y / 2;
        maxBounds = max;
        maxBounds.x -= image.sizeDelta.x / 2;
        maxBounds.y -= image.sizeDelta.y / 2;
        FixedUpdate();
    }

    public void Reset()
    {
        if (startPos == Vector2.zero)
        {
            startPos = image.anchoredPosition;
        }
        image.anchoredPosition = startPos;
        float vert = UnityEngine.Random.Range(.4f, .6f);
        float flipX = Mathf.Sign(UnityEngine.Random.Range(-1, 2));
        float flipY = Mathf.Sign(UnityEngine.Random.Range(-1, 2));
        currentMove = new Vector2(moveSpeed * (1 - vert) * flipX, moveSpeed * vert * flipY);
    }

    private void FixedUpdate()
    {
        if (!move) return;
        Vector2 goal = (Vector2)image.anchoredPosition + currentMove;
        if(goal.x > maxBounds.x)
        {
            goal.x = maxBounds.x;
            currentMove.x *= -1;
        }
        else if(goal.x < minBounds.x)
        {
            goal.x = minBounds.x;
            currentMove.x *= -1;
        }
        if (goal.y > maxBounds.y)
        {
            goal.y = maxBounds.y;
            currentMove.y *= -1;
        }
        else if (goal.y < minBounds.y)
        {
            goal.y = minBounds.y;
            currentMove.y *= -1;
        }
        image.anchoredPosition = goal;
    }
}
