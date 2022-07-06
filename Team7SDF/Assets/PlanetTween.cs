using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTween : MonoBehaviour
{
    public float spinTime;

    private void Update()
    {
        StartCoroutine(PlanetSpin());
    }

    IEnumerator PlanetSpin()
    {
        LeanTween.rotate(gameObject, new Vector3(0, 360, 0), spinTime);
        yield return new WaitForSeconds(spinTime);
    }
}
