using DG.Tweening;
using UnityEngine;

public class SimpleScale : MonoBehaviour
{
    public void OnClickBtn()
    {
        transform.DOScale(2f, 1f);
    }
}
