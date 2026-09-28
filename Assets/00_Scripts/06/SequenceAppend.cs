using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SequenceAppend : MonoBehaviour
{
    private RectTransform rectTransform;
    
    private Vector3 originalPos;
    private Vector3 originalScale;

    private Sequence sequence;

    public bool IsEvent { get; private set; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        originalScale = transform.localScale;

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        DoAction();
    }

    private void OnDisable()
    {
        rectTransform.anchoredPosition = originalPos;
        transform.localScale = originalScale;
    }

    private void DoAction()
    {
        sequence?.Kill();
        sequence = DOTween.Sequence();

        IsEvent = true;

        sequence
            .Append(
                GetComponent<RectTransform>()
                .DOAnchorPosX(100f, 1f)
            )
            .Append(transform.DOScale(2f, 1f))
            .OnComplete(() => IsEvent = false);
    }
}
