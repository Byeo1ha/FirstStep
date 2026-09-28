using UnityEngine;

public class SequenceButton : MonoBehaviour
{
    [SerializeField] private SequenceAppend target;

    public void OnBtnClick()
    {
        if (target.IsEvent) return;
        
        if(!target.gameObject.activeSelf) 
            target.gameObject.SetActive(true);
        else 
            target.gameObject.SetActive(false);
    }
}
