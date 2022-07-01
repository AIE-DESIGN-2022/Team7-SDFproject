using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_WaveManager : MonoBehaviour
{
    public NPC_Waves nPC_Waves;
    private NPC_manager nPC_Manager;

    private bool waveStarted = true;
    private int waveCount = 1;

    public float spawnRate = 0.5f;
    private float spawnTimer = 0;

    private int spawnedNPCs = 0;
    private int nPCsToSpawn = 3;

    public List<GameObject> currentWave = new List<GameObject>();
    public  NPC_Waves[] NPC_Waves;
    // Start is called before the first frame update
    void Start()
    {
        NPC_Waves = (NPC_Waves[])Resources.LoadAll<NPC_Waves>("");
        nPC_Manager = FindObjectOfType<NPC_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //CreateWave(waveCount);
        SpawnWave();
        CheckIfWaveFinished();
    }

    private void CreateWave(int waveNumber)
    {
        nPCsToSpawn = NumberOfNPCs(waveNumber);
        spawnedNPCs = 0;
        waveStarted = true;
        Debug.Log("Wave created");

    }
    private int NumberOfNPCs(int waveNumber)
    {
        return 1 + (waveNumber - 1);
    }

    private void SpawnWave()
    {
        if (waveStarted && spawnedNPCs < nPCsToSpawn)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnRate)
            {
                Debug.Log("Wave Spawned");
                currentWave.Add(nPC_Manager.NPCspawn());
                spawnedNPCs++;
                spawnTimer = 0;
            }

        }
        
    }


    private void CheckIfWaveFinished()
    {
        if (waveStarted && spawnedNPCs == nPCsToSpawn)
        {
            waveStarted = false;
            waveCount++;
            Debug.Log("Wave Finished");
        }
    }
    public void NPCfinished(GameObject npc)
    {
        currentWave.Remove(npc);
        Debug.Log("NPC removed from wave");
    }
    public int WaveCount { get { return waveCount; } }
}
