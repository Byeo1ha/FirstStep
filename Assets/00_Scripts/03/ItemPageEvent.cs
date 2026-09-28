using DG.Tweening;
using UnityEngine;

public class ItemPageEvent : MonoBehaviour
{
    [SerializeField] private GameObject targetPage;

    private bool isEvent;

    private void Awake()
    {
        targetPage.SetActive(false);
        targetPage.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    public void ToggleActiveButton()
    {
        if (isEvent) return;

        if (targetPage.activeSelf)
            DisablePage();
        else 
            EnablePage();
    }

    private void EnablePage()
    {
        isEvent = true;

        targetPage.SetActive(true);

        targetPage.transform
            .DOScale(0.7f, 0.8f)
            .SetEase(Ease.InOutBack)
            .OnComplete(() => isEvent = false);
    }

    private void DisablePage()
    {
        isEvent = true;

        targetPage.transform
            .DOScale(0.3f, 0.1f)
            .SetEase(Ease.InOutBack)
            .OnComplete(() => 
                {
                    isEvent = false;
                    targetPage.SetActive(false);
                }
            );
    }
}
