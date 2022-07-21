using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColourControl : MonoBehaviour
{
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
}
