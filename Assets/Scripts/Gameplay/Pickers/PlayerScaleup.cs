using DG.Tweening;
using TMPro;
using UnityEngine;

public class PlayerScaleup : MonoBehaviour
{
    [SerializeField] private TextMeshPro scaleText;
    [SerializeField] private float scaleCount;
    
    private void OnEnable()
    {
        EventManager.OnCollectorSuccess += ScaleUpPlayer;
        EventManager.OnCollectorSuccess += ShowUpText;
    }
    private void OnDisable()
    {
        EventManager.OnCollectorSuccess -= ScaleUpPlayer;
        EventManager.OnCollectorSuccess -= ShowUpText;
    }

    private void ScaleUpPlayer()
    {
        transform.DOPunchScale(Vector3.right * .6f, 1);
        transform.DOScaleX(scaleCount, 1).SetEase(Ease.Flash);
    }

    private void ShowUpText()
    {
        scaleText.gameObject.SetActive(true);
        scaleText.DOFade(1, 0f).SetEase(Ease.Flash).OnComplete(() => scaleText.DOFade(0, 0).SetDelay(.65f));
        scaleText.rectTransform.DOAnchorPosY(.85f, .65f).SetRelative(true).SetEase(Ease.OutBounce).OnComplete(() =>
            scaleText.rectTransform.DOAnchorPosY(-.85f, .65f).SetRelative(true));

        // scaleText.transform.DOScale(1, 1).OnComplete((() =>
        // {
        //     scaleText.transform.DOScale(0, 1);
        // }));
    }
}