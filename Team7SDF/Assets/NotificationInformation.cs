using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationInformation : MonoBehaviour
{
    public int amount;
    public TextMeshProUGUI resourceAmount;
    public Sprite ResourceIcon;
    public TextMeshProUGUI symbol;

    private void Start()
    {
        resourceAmount.text = symbol.text + "" + amount;
    }
}
