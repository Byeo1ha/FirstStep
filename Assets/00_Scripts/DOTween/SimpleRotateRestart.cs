using DG.Tweening;
using UnityEngine;

public class SimpleRotateRestart : MonoBehaviour
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
        transform
            .DORotate(
                new Vector3(0f, 0f, 360f),
                2f,
                RotateMode.FastBeyond360
            )
            .SetLoops(-1, LoopType.Restart);
    }
}
