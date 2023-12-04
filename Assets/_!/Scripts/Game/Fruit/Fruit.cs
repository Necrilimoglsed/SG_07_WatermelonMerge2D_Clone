using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IFactoryElement
{
    [SerializeField] private Transform rotateTarget;

    public void Prepare(object customParameter = null)
    {
        Debug.Log("Prepare completed");
        transform.DORotate(rotateTarget.eulerAngles, 1)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }

    public object Interact()
    {
        DataHandler.CoinAmount++;
        Disappear();
        return null;
    }

    private void Disappear()
    {
        DOTween.Kill(transform);

        transform.DOScale(0, .3f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
    }
}
