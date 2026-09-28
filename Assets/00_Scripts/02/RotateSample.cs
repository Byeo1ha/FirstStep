using DG.Tweening;
using UnityEngine;

public class RotateSample : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Vector3 targetScale;

    private bool isEvent;

    public void ScaleExtendBtn()
    {
        if (isEvent) return;

        isEvent = true;

        targetObject.transform
            .DOScale(targetScale, 1f)
            .OnComplete(() => isEvent = false);
    }

    public void OutBounceBtn()
    {
        DORotateEvent(Ease.OutBounce);
    }

    public void InSineBtn()
    {
        DORotateEvent(Ease.InSine);
    }

    public void LinearBtn()
    {
        DORotateEvent(Ease.Linear);
    }
    
    public void OutBackBtn()
    {
        DORotateEvent(Ease.OutBack);
    }

    private void DORotateEvent(Ease ease)
    {
        if (isEvent) return;

        isEvent = true;

        targetObject.transform.DORotate(
            new Vector3(0f, 0f, 360f), 
            2f,
            RotateMode.FastBeyond360)
            .SetEase(ease)
            .OnComplete(() => isEvent = false);
    }
}
