using DG.Tweening;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] private Vector3 targetPos;

    public void OnClickBtn()
    {
        transform.DOMove(targetPos, 2f);
    }
}
