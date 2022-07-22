using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public NPC_WaveManager nPC_WaveManager;
    public GameObject annoyingGreenGuyCamera;
    public GameObject mainGameCamera;
    public GameObject shopPanelCamera;
    public bool canTransitionToGreenGuy;
    public GameObject shopPanel;


    private void Start()
    {
        canTransitionToGreenGuy = true;
        nPC_WaveManager = FindObjectOfType<NPC_WaveManager>();

    }
    private void Update()
    {
        if (canTransitionToGreenGuy)
        {

        Transition();
        }
    }

    public void Transition()
    {
        if (nPC_WaveManager.waveCount == 3 && nPC_WaveManager.LastWaveSpawned == true)
        {
            mainGameCamera.SetActive(false);
            annoyingGreenGuyCamera.SetActive(true);
            canTransitionToGreenGuy = false;    
        }
    }

    public void ShopTransition()
    {
        annoyingGreenGuyCamera.SetActive(false);
        shopPanelCamera.SetActive(true );
        StartCoroutine(WaitTime());
        
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2);
        shopPanel.SetActive(true);


        
    }
   
}


