using UnityEngine;
using DG.Tweening;
using System;

public class Popup : MonoBehaviour
{
    [HideInInspector, SerializeField]
    private Vector3 _initPosition;
    [SerializeField]
    private float _duration = 0.7f;
    [SerializeField]
    private RectTransform movingObject;
    [SerializeField]
    private AnimationCurve _inCurve;
    [SerializeField]
    private AnimationCurve _outCurve;

    public event Action onBeginShow;
    public event Action onEndShow;


    public event Action onBeginHide;
    public event Action onEndHide;

    public bool IsActive
    {
        get => gameObject.activeSelf;
        set => gameObject.SetActive(value);
    }

    private Vector3 currentPosition
    {
        get => movingObject.anchoredPosition3D;
        set => movingObject.anchoredPosition3D = value;
    }

    private Vector3 outOfScreenPosition
    {
        get => new Vector3(0, Screen.height, 0);
    }

    private void OnValidate()
    {
        if (movingObject == null) movingObject = GetComponent<RectTransform>();

        _initPosition = currentPosition;
    }

    public void Show()
    {
        if (IsActive) return;

        onBeginShow?.Invoke();

        currentPosition = outOfScreenPosition;

        var tween = movingObject.DOAnchorPos3D(_initPosition, _duration).SetEase(_inCurve).SetUpdate(true);

        tween.onKill += () =>
        {
            onEndShow?.Invoke();
        };

        IsActive = true;
    }

    public void Hide()
    {
        if (!IsActive) return;

        onBeginHide?.Invoke();

        currentPosition = _initPosition;
        var tween = movingObject.DOAnchorPos3D(outOfScreenPosition, _duration).SetEase(_outCurve).SetUpdate(true);
        tween.onKill += () => {
            IsActive = false;
            onEndHide?.Invoke();
        };
    }

    public void HideImmediate()
    {
        if (!IsActive) return;

        onBeginHide?.Invoke();
        onEndHide?.Invoke();

        currentPosition = outOfScreenPosition;

        IsActive = false;
    }

    public void ShowImmediate()
    {
        if (IsActive) return;

        currentPosition = _initPosition;

        IsActive = true;

        onBeginShow?.Invoke();
        onEndShow?.Invoke();
    }


}
