using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public int buyPrice;
    public int sellPrice;

    public ResourceManager resourceManager;

    public void Awake()
    {
        
    }
    public void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
    }
    public void BuyButton(ResourceButton buttonClicked)
    {
        switch (buttonClicked.resourceType)
        {
            case ResourceType.chips:
                resourceManager.techChipCount += buttonClicked.quantity;
                resourceManager.currencyCount -= buyPrice;
                buyPrice = buttonClicked.quantity * 10;
                break;


            case ResourceType.alloy:
                resourceManager.alloyCount += buttonClicked.quantity;
                resourceManager.currencyCount -= buyPrice;
                buyPrice = buttonClicked.quantity * 10;
                break;


            case ResourceType.fuel:
                resourceManager.fuelCount += buttonClicked.quantity;
                resourceManager.currencyCount -= buyPrice;
                buyPrice = buttonClicked.quantity * 10;
                break;
        }

    }
    public void SellButton(ResourceButton buttonClicked)
    {
        switch (buttonClicked.resourceType)
        {
            case ResourceType.chips:
                resourceManager.techChipCount -= buttonClicked.quantity;
                resourceManager.currencyCount += sellPrice;
                sellPrice = buttonClicked.quantity * 5;
                break;


            case ResourceType.alloy:
                resourceManager.alloyCount -= buttonClicked.quantity;
                resourceManager.currencyCount += sellPrice;
                sellPrice = buttonClicked.quantity * 5;
                break;


            case ResourceType.fuel:
                resourceManager.fuelCount -= buttonClicked.quantity;
                resourceManager.currencyCount += sellPrice;
                sellPrice = buttonClicked.quantity * 5;
                break;



        }

    }

    
}
