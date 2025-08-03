using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FinalBossBounds : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private RectTransform image;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    private Vector2 currentMove;
    private Vector2 startPos;
    public event Action oof;
    public void OnPointerEnter(PointerEventData eventData)
    {
        oof?.Invoke();
    }

    private void Awake()
    {
        startPos = transform.position;
        Reset();
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
        transform.position = startPos;
        float vert = UnityEngine.Random.Range(.25f, .75f);
        float flipX = Mathf.Sign(UnityEngine.Random.Range(-1, 2));
        float flipY = Mathf.Sign(UnityEngine.Random.Range(-1, 2));
        currentMove = new Vector2(moveSpeed * (1 - vert) * flipX, moveSpeed * vert * flipY);
    }

    private void FixedUpdate()
    {
        Vector2 goal = (Vector2)transform.localPosition + currentMove;
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
        transform.localPosition = goal;

        //float vert = Random.Range(.25f, .75f);
        //float flipX = Mathf.Sign(Random.Range(-1, 2));
        //float flipY = Mathf.Sign(Random.Range(-1, 2));
        //rb.linearVelocity = new Vector2(moveSpeed * (1 - vert), moveSpeed * vert);
    }
}
