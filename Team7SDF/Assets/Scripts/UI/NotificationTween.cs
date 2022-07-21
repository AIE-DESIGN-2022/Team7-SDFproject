using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NotificationTween : MonoBehaviour
{
    public UnityEvent onCompleteCallBack;

    public float startingX;
    public float startingY;

    public float distanceX;
    public float durationX;
    public float distanceY;
    public float durationY;
    public float delay;
    public float lingerDelay;
    public float reset;
    public LeanTweenType easeType;

    public void NotificationOn()
    {
        LeanTween.moveY(gameObject, distanceY, durationY).setDelay(delay).setEase(easeType).setOnComplete(FadeOut);
        LeanTween.moveX(gameObject, distanceX, durationX).setDelay(delay).setEase(easeType).setOnComplete(OnComplete);
    }

    public void OnComplete()
    {
        if (onCompleteCallBack != null)
        {
            onCompleteCallBack.Invoke();
        }
    }

    public void FadeOut()
    {
        LeanTween.moveX(gameObject, startingX, reset).setDelay(lingerDelay).setOnComplete(ResetPosition);
    }

    public void ResetPosition()
    {
        LeanTween.moveY(gameObject, startingY, durationY).setDelay(lingerDelay);        
    }
}
