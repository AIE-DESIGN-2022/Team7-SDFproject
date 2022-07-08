using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndYearTween : MonoBehaviour
{
    public float duration;
    public float rotateAmount;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.rotateY(gameObject, rotateAmount, duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
