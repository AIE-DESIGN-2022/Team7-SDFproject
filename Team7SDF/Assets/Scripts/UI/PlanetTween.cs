using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTween : MonoBehaviour
{
    public float spinTime;
    private float rotate;
    private float startPoint;
    public void Start()
    {
        startPoint = 0;
        rotate = 360;
        LeanTween.rotate(gameObject, new Vector3(startPoint, rotate, 0), spinTime).setOnComplete(PlanetSpinLoopOne);
    }
    public void PlanetSpinLoopOne()
    {
        startPoint = 0;
        rotate = 360;
        LeanTween.rotate(gameObject, new Vector3(startPoint, rotate, 0), spinTime).setOnComplete(PlanetSpinLoopTwo);
    }

    public void PlanetSpinLoopTwo()
    {
        startPoint = 0;
        rotate = 360;
        LeanTween.rotate(gameObject, new Vector3(startPoint, rotate, 0), spinTime).setOnComplete(PlanetSpinLoopOne);
    }

}
