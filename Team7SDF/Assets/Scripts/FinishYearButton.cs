using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishYearButton : MonoBehaviour
{
    NPC_WaveManager waveManager;
    CameraTransition transition;
    // Start is called before the first frame update
    private void Start()
    {
        transition = FindObjectOfType<CameraTransition>();
        waveManager = FindObjectOfType<NPC_WaveManager>();
    }
    public void FinishYearConfirm()
    {
        waveManager.EndYear = true;
        transition.canTransitionToGreenGuy = true;
        waveManager.CheckIfYearFinished();
    }

    public void StartYearConfrim()
    {
        waveManager.CanYearStart = true;
    }


}


