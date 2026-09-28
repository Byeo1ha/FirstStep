using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetImage;
    [SerializeField] private RawImage rawImage;

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

    public void ToggleColorRedButton()
    {
        ToggleColor(Color.red);
    }

    public void ToggleColorBlueButton()
    {
        ToggleColor(Color.blue);
    }

    public void ToggleColorGreenButton()
    {
        ToggleColor(Color.green);
    }

    private void ToggleColor(Color color)
    {
        if (isEvent) return;

        if (isChange && targetImage.color == color) 
            SetChangeColor(false, color);
        else 
            SetChangeColor(true, color);
    }

    private void SetChangeColor(bool value, Color color)
    {
        sequence?.Kill();
        sequence = DOTween.Sequence();

        Color changeColor;
        Color rawColor;

        isEvent = true;

        if (value) 
        {
            changeColor = color;
            rawColor = color;
            isChange = true;
        }
        else 
        {
            changeColor = originalImageColor;
            rawColor = originalRawColor; 
            isChange = false;
        }

        sequence
            .Append(targetImage.DOColor(changeColor, 1f))
            .Join(rawImage.DOColor(rawColor, 1f))
            .OnComplete(() => isEvent = false);
    }
}
