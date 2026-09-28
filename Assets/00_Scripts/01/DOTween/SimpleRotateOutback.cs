using DG.Tweening;
using UnityEngine;

public class SimpleRotateOutback : MonoBehaviour
{
    private void OnEnable()
    {
        InputSystem.Instance.OnRotate += Action;
    }

    private void OnDisable()
    {
        InputSystem.Instance.OnRotate -= Action;
    }

    private void Action()
    {
        transform.DORotate(
            transform.eulerAngles + new Vector3(0f, 0f, 360f),
            2f,
            RotateMode.FastBeyond360)
        .SetEase(Ease.OutBack);
    }
}
