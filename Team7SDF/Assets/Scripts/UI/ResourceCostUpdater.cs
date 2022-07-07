using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ResourceCostUpdater : MonoBehaviour
{
    public LayoutElement layoutElement;
    public int resourceCount;
    public GameObject costObjectOne;
    public GameObject costObjectTwo;
    public GameObject costObjectThree;

    private void Update()
    {
        if (costObjectThree.activeInHierarchy)
        {
            resourceCount = 3;
        }
        else if(costObjectTwo.activeInHierarchy)
        {
            resourceCount = 2;
        }
        else if(costObjectOne.activeInHierarchy)
        {
            resourceCount = 1;
        }

        if (resourceCount == 1)
        {
            layoutElement.minWidth = 172;
        }
        else if (resourceCount == 2)
        {
            layoutElement.minWidth = 360;
        }
        else if (resourceCount == 3)
        {
            layoutElement.minWidth = 576;
        }


    }
    public void SetResourceCost()
    {

    }
}
