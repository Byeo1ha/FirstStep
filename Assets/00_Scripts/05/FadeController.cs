using DG.Tweening;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] private CanvasGroup targetCanvasGroup;

    private bool isChange;
    private bool isEvent;

    private void OnEnable()
    {
        InputSystem.Instance.OnEvent += Fade;
    }

    private void OnDisable()
    {
        InputSystem.Instance.OnEvent -= Fade;
    }

    private void Fade()
    {
        if (isEvent) return;

        if (!isChange) FadeIn();
        else FadeOut();
    }

    private void FadeIn()
    {
        isChange = true;
        isEvent = true;

        targetCanvasGroup
            .DOFade(0f, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() => isEvent = false);
    }

    private void FadeOut()
    {
        isChange = false;
        isEvent = true;

        targetCanvasGroup
            .DOFade(1f, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(() => isEvent = false);
    }
}
