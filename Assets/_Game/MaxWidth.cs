using UnityEngine;
using UnityEngine.UI;

public class MaxWidth : MonoBehaviour
{
    [SerializeField] private float maxWidth;
    [SerializeField] private VerticalLayoutGroup group;
    [SerializeField] private ContentSizeFitter fitter;
    [SerializeField] private ContentSizeFitter myfitter;
    private RectTransform rect;


    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rect.sizeDelta.x > maxWidth)
        {
            group.childControlWidth = true;
            fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            myfitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            var rect = group.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(325, rect.sizeDelta.y);
        }
        else
        {
            group.childControlWidth = false;
            fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
            myfitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
    }
}
