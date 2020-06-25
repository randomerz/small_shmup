using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_Slide : MonoBehaviour
{
    public AnimationCurve curveIn;
    public AnimationCurve curveOut;
    public LeanTweenType inType;
    public LeanTweenType outType;

    public Vector3 newPos;
    public float time = 0.5f;

    public void SlideIn()
    {
        if (inType == LeanTweenType.animationCurve)
            LeanTween.moveLocal(gameObject, newPos, time).setOnComplete(Close).setEase(curveIn);
        else
            LeanTween.moveLocal(gameObject, newPos, time).setOnComplete(Close).setEase(inType);
    }

    public void SlideOut()
    {
        if (outType == LeanTweenType.animationCurve)
            LeanTween.moveLocal(gameObject, newPos, time).setOnComplete(Close).setEase(curveOut);
        else
            LeanTween.moveLocal(gameObject, newPos, time).setOnComplete(Close).setEase(outType);
    }

    public void Close()
    {
        Debug.Log("closed stats");
    }
}
