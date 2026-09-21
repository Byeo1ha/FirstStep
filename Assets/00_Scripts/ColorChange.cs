using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetImage;
    [SerializeField] private RawImage rawImage;
    [SerializeField] private Color newColor = Color.red;

    private Color originalImageColor;
    private Color originalRawColor;
    
    private bool isChange;
    private bool isEvent;

    private Sequence sequence;

    private void Awake()
    {
        originalImageColor = targetImage.color;
        originalRawColor = rawImage.color;
    }

    public void ToggleColorButton()
    {
        if (isEvent) return;

        if (isChange) SetChangeColor(false);
        else SetChangeColor(true);
    }

    private void SetChangeColor(bool value)
    {
        sequence?.Kill();
        sequence = DOTween.Sequence();

        Color color;
        Color RawColor;

        isEvent = true;

        if (value) 
        {
            color = newColor;
            RawColor = newColor;
            isChange = true;
        }
        else 
        {
            color = originalImageColor;
            RawColor = originalRawColor; 
            isChange = false;
        }

        sequence
            .Append(targetImage.DOColor(color, 1f))
            .Join(rawImage.DOColor(RawColor, 1f))
            .OnComplete(() => isEvent = false);
    }
}
