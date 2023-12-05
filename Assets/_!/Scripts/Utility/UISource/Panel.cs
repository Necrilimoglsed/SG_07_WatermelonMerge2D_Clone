using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    [SerializeField] private string id;
    public string ID => id;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Appear()
    {
        DOTween.Kill(_canvasGroup);

        _canvasGroup.DOFade(1, .28f)
            .SetEase(Ease.OutSine)
            .OnComplete(() =>
            {
                _canvasGroup.blocksRaycasts = true;
                _canvasGroup.interactable = true;
            });
    }

    public void Disappear()
    {
        DOTween.Kill(_canvasGroup);

        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = false;

        _canvasGroup.DOFade(0, .28f)
            .SetEase(Ease.OutSine);
    }
}
