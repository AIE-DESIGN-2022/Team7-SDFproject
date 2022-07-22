using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_WaveManager : MonoBehaviour
{
    public SoundtrackController soundtrackController;
    public NPC_Waves nPC_Waves;
    public NPC_manager nPC_Manager;
    public NpcDialogueTracker npcDialogueTracker;
    public CameraTransition cameraTransition;

    public TextMeshProUGUI YearCountText;

    public bool CanYearStart;
    public bool EndYear;
    private bool waveStarted = false;
    public int YearLoreCount = 2049;
    public int yearCount = 1;
    public int waveCount = 0;

    public GameObject signalLight;

    public float spawnRate = 0;
    private float spawnTimer = 0;

    private int spawnedNPCs = 0;
    private int nPCsToSpawn = 5;

    //private int nPCsInSceneQuestsCompleted = 0;

    public bool LastWaveSpawned;

    public List<GameObject> currentWave = new List<GameObject>();
    public NPC_Waves[] NPC_Waves;
    public bool isInteractingWithQuest;

    public ColourControl colourControl;
    // Start is called before the first frame update
    void Start()

    {
        CanYearStart = false;
        UpdateYearCountText();
        cameraTransition = FindObjectOfType<CameraTransition>();
        soundtrackController = FindObjectOfType<SoundtrackController>();
        npcDialogueTracker = FindObjectOfType<NpcDialogueTracker>();
        LastWaveSpawned = true;
        NPC_Waves = (NPC_Waves[])Resources.LoadAll<NPC_Waves>("");
        nPC_Manager = FindObjectOfType<NPC_manager>();
        colourControl = FindObjectOfType<ColourControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //CreateWave(waveCount);
        if (CanYearStart == true)
        {
            CreateWave(waveCount);
            if (waveStarted)
            {
                SpawnWave();

            }
            else
            {
                return;
            }


        }

        if (spawnedNPCs == 3)
        {
            colourControl.SetColourRed();
        }
        CheckIfYearFinished();
        CheckIfWaveFinished();
    }

    public void CreateWave(int waveNumber)
    {
        if (LastWaveSpawned && waveCount <= 2)
        {
            colourControl.SetColourGreen();
            GetComponent<AudioController>().PlayClip();

            nPCsToSpawn = 3;
            spawnedNPCs = 0;
            waveStarted = true;
            waveCount++;
            //Debug.Log("Wave created");
            LastWaveSpawned = false;
            
        }
    }
    /* private int NumberOfNPCs(int waveNumber)
     {
         return 1 + (waveNumber - 1);
     }*/

    private void SpawnWave()
    {
        EndYear = false;
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
        if (waveStarted && spawnedNPCs == nPCsToSpawn && currentWave.Count == 0)
        {
            npcDialogueTracker.npcCount = 0;
            waveStarted = false;
            //Debug.Log("Wave Finished Spawning NPCs");
            LastWaveSpawned = true;
            currentWave.Clear();
        }
    }

    public void CheckIfYearFinished()
    {
        if (waveCount == 3 && spawnedNPCs == nPCsToSpawn && currentWave.Count == 0 && EndYear == true)
        {
            Debug.Log("Yearending");
            yearCount++;
            YearLoreCount++;
            waveCount = 0;
            soundtrackController.ChangeSoundtrack();
            UpdateYearCountText();

            //pause for end of year statistics
        }
    }
    public void NPCfinished(GameObject npc)
    {
        currentWave.Remove(npc);
        //Debug.Log("NPC removed from wave");
    }
    public int WaveCount { get { return waveCount; } }

    public void UpdateYearCountText()
    {
        YearCountText.text = YearLoreCount.ToString();
    }
}
