using DG.Tweening;
using UnityEngine;

public class SimpleRotateLocalAxisAdd : MonoBehaviour
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
                new Vector3(0f, 0f, 360),
                2f,
                RotateMode.LocalAxisAdd);
    }
}
