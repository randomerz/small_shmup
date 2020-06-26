using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_Slide : MonoBehaviour
{
    public AnimationCurve curveIn;
    public AnimationCurve curveOut;
    public LeanTweenType inType;
    public LeanTweenType outType;
    
    public float time = 0.5f;

    public void SlideTo(Vector3 to)
    {
        if (inType == LeanTweenType.animationCurve)
            LeanTween.moveLocal(gameObject, to, time).setEase(curveIn);
        else
            LeanTween.moveLocal(gameObject, to, time).setEase(inType);
    }

    public void SlideToDelayDisable(Vector3 to)
    {
        if (outType == LeanTweenType.animationCurve)
            LeanTween.moveLocal(gameObject, to, time).setEase(curveOut).setOnComplete(DisableMe);
        else
            LeanTween.moveLocal(gameObject, to, time).setEase(outType).setOnComplete(DisableMe);
    }

    public void SlideToDelay(Vector3 to, float delay)
    {
        if (outType == LeanTweenType.animationCurve)
            LeanTween.moveLocal(gameObject, to, time).setEase(curveOut).setDelay(delay);
        else
            LeanTween.moveLocal(gameObject, to, time).setEase(outType).setDelay(delay);
    }

    public void SlideToDelayDisable(Vector3 to, float delay)
    {
        if (outType == LeanTweenType.animationCurve)
            LeanTween.moveLocal(gameObject, to, time).setEase(curveOut).setDelay(delay).setOnComplete(DisableMe);
        else
            LeanTween.moveLocal(gameObject, to, time).setEase(outType).setDelay(delay).setOnComplete(DisableMe);
    }


    private void DisableMe()
    {
        gameObject.SetActive(false);
    }
}
