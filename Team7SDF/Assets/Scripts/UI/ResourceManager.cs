using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{

    //Civilisation Resources
    public int populationCount;

    public float happinessPercentCount;
    public int maxHappiness;
    public int minHappiness;

    public int currencyCount;
    public int researchLogCount;

    public TextMeshProUGUI populationCountText;
    public TextMeshProUGUI happinessPercentCountText;
    public TextMeshProUGUI currencyCountText;
    public TextMeshProUGUI researchLogCountText;



    //Special Resources (spendable in shop)
    public int techChipCount;
    public int alloyCount;
    public int fuelCount;

    public TextMeshProUGUI techChipCountText;
    public TextMeshProUGUI alloyCountText;
    public TextMeshProUGUI fuelCountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateResourceTextUI();
    }






    public void updateResourceTextUI()
    {
        techChipCountTextUI();
        alloyCountTextUI();
        fuelCountTextUI();

        populationCountTextUI();
        happinessPercentCountTextUI();
        currencyCountTextUI();
        researchLogCountTextUI();
    }
    public void techChipCountTextUI()
    {
        techChipCountText.text = techChipCount.ToString();
    }
    public void alloyCountTextUI()
    {
        alloyCountText.text = alloyCount.ToString();
    }
    public void fuelCountTextUI()
    {
        fuelCountText.text = fuelCount.ToString();
    }


    public void populationCountTextUI()
    {
        populationCountText.text = populationCount.ToString();
    }
    public void happinessPercentCountTextUI()
    {
        happinessPercentCountText.text = happinessPercentCount.ToString();
    }
    public void currencyCountTextUI()
    {
        currencyCountText.text = currencyCount.ToString();
    }
    public void researchLogCountTextUI()
    {
        researchLogCountText.text = researchLogCount.ToString();
    }



}
