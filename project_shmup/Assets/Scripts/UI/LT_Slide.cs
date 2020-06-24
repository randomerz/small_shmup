using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_Slide : MonoBehaviour
{
    public AnimationCurve curve;
    public LeanTweenType inType;
    public LeanTweenType outType;

    public float newX = 0;
    public float newY = 0;
    public float time = 0.5f;

    public void Slide()
    {
        LeanTween.moveLocal(gameObject, new Vector3(newX, newY, 0), time).setOnComplete(Close).setEase(outType);
    }

    public void Close()
    {
        Debug.Log("closed stats");
    }
}
