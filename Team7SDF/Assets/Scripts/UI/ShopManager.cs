using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public ResourceManager resourceManager;

    [Header("Chip Economy")]

    public int buyChipCost;
    public int sellChipCost;
    public TextMeshProUGUI buyChipCostText;
    public TextMeshProUGUI sellChipCostText;

    [Header("Alloy Economy")]

    public int buyAlloyCost;
    public int sellAlloyCost;
    public TextMeshProUGUI buyAlloyCostText;
    public TextMeshProUGUI sellAlloyCostText;

    [Header("Fuel Economy")]

    public int buyFuelCost;
    public int sellFuelCost;
    public TextMeshProUGUI buyFuelCostText;
    public TextMeshProUGUI sellFuelCostText;

    [Header("Buy/Sell Quantity")]

    public int currentBuyQuantity;
    public int currentSellQuantity;

    public int quantity_x1 = 1;
    public int quantity_x10 = 10;
    public int quantity_x50 = 50;

    




    // Start is called before the first frame update
    void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyChip(Button buyButton)
    {
        Debug.Log("BUY CHIP");
   
    }

    public void SellChip(Button sellButton)
    {
        Debug.Log("SELL CHIP");
      
    }

    public void BuyAlloy(Button buyButton)
    {
        Debug.Log("BUY ALLOY");
    
    }

    public void SellAlloy(Button sellButton)
    {
        Debug.Log("SELL ALLOY");

    }

    public void BuyFuel(Button buyButton)
    {
        Debug.Log("BUY FUEL");

    }

    public void SellFuel(Button sellButton)
    {
        Debug.Log("SELL FUEL");
    }

}
