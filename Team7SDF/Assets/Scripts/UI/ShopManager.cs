using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public GameObject sellShop;
    public int buyPrice;
    public int sellPrice;
    public ResourceButton[] resourceButtons;

    public ResourceManager resourceManager;

    private void Update()
    {
        /*CheckButtonsBuy();
        CheckButtonsSell();*/
    }
    public void Start()
    {
        resourceManager = FindObjectOfType<ResourceManager>();
        resourceButtons = FindObjectsOfType<ResourceButton>();

        CheckButtonsBuy();
        CheckButtonsSell();
        sellShop.SetActive(false);

    }

    public void CheckButtonsBuy()
    {
        foreach (ResourceButton button in resourceButtons)
        {

            if (button.buttonType == ButtonType.buy )
            {

                if (resourceManager.currencyCount < button.price)
                {
                    Debug.Log(button.name + "Button going off!");
                    button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    button.GetComponent<Button>().interactable = true;
                }
            }
        }
    }
    public void CheckButtonsSell()
    {
        foreach (ResourceButton button in resourceButtons)
        {
            if (button.buttonType == ButtonType.sell)
            {
                if (button.resourceType == ResourceType.chips)
                {
                    if (resourceManager.techChipCount < button.quantity)
                    {
                        button.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        button.GetComponent<Button>().interactable = true;
                    }
                }

                if (button.resourceType == ResourceType.alloy)
                {
                    if (resourceManager.alloyCount < button.quantity)
                    {
                        button.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        button.GetComponent<Button>().interactable = true;
                    }
                }
                if (button.resourceType == ResourceType.fuel)
                {
                    if (resourceManager.fuelCount < button.quantity)
                    {
                        button.GetComponent<Button>().interactable = false;
                    }
                    else
                    {
                        button.GetComponent<Button>().interactable = true;
                    }
                }
            }
        }
    }
    public void BuyButton(ResourceButton buttonClicked)
    {

        switch (buttonClicked.buttonType)
        {
            case ButtonType.buy:

                switch (buttonClicked.resourceType)
                {
                    case ResourceType.chips:

                        buyPrice = buttonClicked.quantity * 10;
                        resourceManager.techChipCount += buttonClicked.quantity;
                        resourceManager.currencyCount -= buyPrice;
                        break;


                    case ResourceType.alloy:
                        buyPrice = buttonClicked.quantity * 10;
                        resourceManager.alloyCount += buttonClicked.quantity;
                        resourceManager.currencyCount -= buyPrice;
                        break;


                    case ResourceType.fuel:
                        buyPrice = buttonClicked.quantity * 10;
                        resourceManager.fuelCount += buttonClicked.quantity;
                        resourceManager.currencyCount -= buyPrice;
                        break;
                }
                break;

            case ButtonType.sell:
                switch (buttonClicked.resourceType)
                {
                    case ResourceType.chips:
                        sellPrice = buttonClicked.quantity * 5;
                        resourceManager.techChipCount -= buttonClicked.quantity;
                        resourceManager.currencyCount += sellPrice;
                        Debug.Log(sellPrice);
                        break;

                    case ResourceType.alloy:
                        sellPrice = buttonClicked.quantity * 5;
                        resourceManager.alloyCount -= buttonClicked.quantity;
                        resourceManager.currencyCount += sellPrice;
                        Debug.Log(sellPrice);
                        break;


                    case ResourceType.fuel:
                        sellPrice = buttonClicked.quantity * 5;
                        resourceManager.fuelCount -= buttonClicked.quantity;
                        resourceManager.currencyCount += sellPrice;
                        Debug.Log(sellPrice);
                        break;
                }
                break;
        }
        CheckButtonsBuy();
        CheckButtonsSell();
    }


}