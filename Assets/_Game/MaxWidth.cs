using UnityEngine;

public class MaxWidth : MonoBehaviour
{
    [SerializeField] private float maxWidth;
    private RectTransform rect;


    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rect.sizeDelta.x > maxWidth)
        {
            rect.sizeDelta = new Vector2(maxWidth, rect.sizeDelta.y);
        }
    }
}
