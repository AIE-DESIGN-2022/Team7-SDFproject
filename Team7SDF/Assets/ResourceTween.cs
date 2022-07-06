using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTween : MonoBehaviour
{
    public float duration;
    public float delay;
    public float addSize;

    public float shakeLeft;
    public float shakeRight;
    public float reset;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void AddResource()
    {
        LeanTween.scale(gameObject, new Vector3(addSize, addSize, addSize), duration);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), duration).setDelay(delay);
    }
    public void RemoveResource()
    {
        LeanTween.moveX(gameObject, shakeLeft, duration);
        LeanTween.moveX(gameObject, shakeRight, duration);
        LeanTween.moveX(gameObject, reset, duration).setDelay(delay);
    }
}
