using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_WaveManager : MonoBehaviour
{
    public NPC_Waves nPC_Waves;
    public NPC_manager nPC_Manager;

    private bool waveStarted = false;
    public int waveCount = 0;

    public float spawnRate = 0;
    private float spawnTimer = 0;

    private int spawnedNPCs = 0;
    private int nPCsToSpawn = 5;

    public bool LastWaveSpawned;

    public List<GameObject> currentWave = new List<GameObject>();
    public  NPC_Waves[] NPC_Waves;
    public bool isInteractingWithQuest;
    // Start is called before the first frame update
    void Start()
       
    {
        LastWaveSpawned = true;
        NPC_Waves = (NPC_Waves[])Resources.LoadAll<NPC_Waves>("");
        nPC_Manager = FindObjectOfType<NPC_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //CreateWave(waveCount);
        CreateWave(waveCount);
        if (waveStarted)
        {
        SpawnWave();

        }
       
        CheckIfWaveFinished();
    } 

    private void CreateWave(int waveNumber)
    {
        if (LastWaveSpawned)
        {

        nPCsToSpawn = 3;
        spawnedNPCs = 0;
        waveStarted = true;
        waveCount++;
        Debug.Log("Wave created");
        LastWaveSpawned = false;
        }

    }
   /* private int NumberOfNPCs(int waveNumber)
    {
        return 1 + (waveNumber - 1);
    }*/

    private void SpawnWave()
    {
        if (waveStarted && spawnedNPCs < nPCsToSpawn)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnRate)
            {
                currentWave.Add(nPC_Manager.NPCspawn());
                spawnedNPCs++;
                spawnTimer = 0;
                //Debug.Log("Wave Spawned");
            }

        }
        
    }


    private void CheckIfWaveFinished()
    {
        if (waveStarted && spawnedNPCs == nPCsToSpawn)
        {
            waveStarted = false;
            Debug.Log("Wave Finished Spawning NPCs");
            LastWaveSpawned = true;
            currentWave.Clear();


        }
    }
    public void NPCfinished(GameObject npc)
    {
        currentWave.Remove(npc);
        Debug.Log("NPC removed from wave");
    }
    public int WaveCount { get { return waveCount; } }
}
