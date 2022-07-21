using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ButtonType { buy, sell}

public class ResourceButton : MonoBehaviour
{
    public ButtonType buttonType;
    public ResourceType resourceType;
    public int quantity;
    public int price;
    public int sellPrice;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI sellPriceText;

    private void Start()
    {
        if (price == 0 && priceText == null)
        {
            SetSellPrice();
        }
        else if (sellPrice == 0 && sellPriceText == null)
        {
            SetBuyPrice();
        }
    }
    public void SetBuyPrice()
    {

        priceText.text = price.ToString();
    }
    public void SetSellPrice()
    {

        sellPriceText.text = sellPrice.ToString();
    }
}
