using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColourControl : MonoBehaviour
{

    public Material lightMaterial;

    private void Start()
    {
    }
    public void CurrentPanelColourBuy()
    {
        gameObject.GetComponent<Image>().color = Color.green;
    }
    public void CurrentPanelColourSell()
    {
        gameObject.GetComponent<Image>().color = Color.red;
    }
    public void CurrentPanelColourOff()
    {
        gameObject.GetComponent<Image>().color = Color.grey;
    }

    public void SetColourRed()
    {
        lightMaterial.color = Color.red;
    }
    public void SetColourGreen()
    {
        lightMaterial.color = Color.green;
    }
}
