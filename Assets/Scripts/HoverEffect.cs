using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]float _hoverScaleIncrase = 1.1f;
    [SerializeField] float _clickScaleIncrase = 1.3f;
    [SerializeField] float _tweenEffectDuration = 0.1f;
    [SerializeField]AudioClip _clickSound;
    private Vector3 _originalScale;

    void Awake()
    {
        _originalScale = transform.localScale;
    }

    void OnEnable()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = _originalScale;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector2.one * _clickScaleIncrase;
        LeanTween.scale(gameObject, Vector2.one * _hoverScaleIncrase, _tweenEffectDuration).setIgnoreTimeScale(true);
        Debug.Log("OnPoinetDown");
        //AudioManager.PlayAudio(_clickSound, AudioManager.SoundType.SFX, 1f, false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector2.one * _hoverScaleIncrase, _tweenEffectDuration).setIgnoreTimeScale(true);
        Debug.Log("OnPoinerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector2.one, _tweenEffectDuration).setIgnoreTimeScale(true);
        Debug.Log("OnPoinerExit");
    }
}
