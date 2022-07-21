using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishYearButton : MonoBehaviour
{
    NPC_WaveManager waveManager;
    // Start is called before the first frame update
    private void Start()
    {
        waveManager = FindObjectOfType<NPC_WaveManager>();
    }
    public void FinishYearConfirm()
    {
        waveManager.EndYear = true;
    }

    public void StartYearConfrim()
    {
        waveManager.CanYearStart = true;
    }
}


