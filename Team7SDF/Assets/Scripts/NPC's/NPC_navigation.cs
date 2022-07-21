using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public enum eNPCstate
{
    MoveTowardsWaitPoint,
    MoveTowardsInteractionPoint,
    Interaction,
    MoveTowardsExitPoint,
    MoveTowardsDespawnPoint,
    //StepBack,
    None

}
public class NPC_navigation : MonoBehaviour
{

    public eNPCstate nPC_state;

    public bool isNPC_active = true;
    public bool isNPC_InteractionPointOccupied = false;
    public bool isNPC_InteractionCompleted = false;

    public float interactionRange;

    public GameObject target;
    public GameObject spawnPoint;
    public GameObject waitPoint;
    public GameObject interactionPoint;
    public GameObject exitPoint;
    public GameObject despawnPoint;
    public GameObject stepBack;
    public GameObject CurrentQuestGivingNPC;

    public float stoppingRange;
    public float stepBackDistance;

    private NavMeshAgent agent;
    private NPC_WaveManager waveManager;

    public DialogueController dialogueController;
    public ResourceCostUpdater npcResourceCostUpdater;

    public Animator animator;
    PlayerManager playerManager;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();
        npcResourceCostUpdater = FindObjectOfType<ResourceCostUpdater>();

        dialogueController = GetComponentInParent<DialogueController>();
        spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
        waitPoint = GameObject.FindGameObjectWithTag("Wait");
        interactionPoint = GameObject.FindGameObjectWithTag("Interaction");
        exitPoint = GameObject.FindGameObjectWithTag("Exit");
        despawnPoint = GameObject.FindGameObjectWithTag("Despawn");
        stepBack = transform.GetChild(0).gameObject; 
        waveManager = FindObjectOfType<NPC_WaveManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
    void Start()
    {
        target = waitPoint;
        nPC_state = eNPCstate.MoveTowardsWaitPoint;
    }

    private void Update()
    {
        if (!isNPC_active) return;
        NPCnavLogic();
        NPCmovementLogic();
    }

    private void NPCmovementLogic()
    {
        if (nPC_state == eNPCstate.Interaction) return;

        if (PathIsClear())
        {
            agent.isStopped = false;
            agent.destination = target.transform.position;
        }
        else
        {
            agent.isStopped = true;
            agent.destination = transform.position;
           animator.SetBool("Idle",true);
        }

    }

    private void NPCnavLogic()
    {
        if (!PathIsClear()) return;

        float distanceToTarget = transform.position.x - target.transform.position.x;
        float distanceToWaitPoint = transform.position.x - waitPoint.transform.position.x;
        float distanceToInteractionPoint = transform.position.x - interactionPoint.transform.position.x;
        float distanceToExitPoint = transform.position.x - exitPoint.transform.position.x;
        float distanceToDespawnPoint = transform.position.x - despawnPoint.transform.position.x;

        float distanceToStepBack = transform.position.x - stepBack.transform.position.x;

        if (distanceToTarget < 0) distanceToTarget *= -1;
        if (distanceToWaitPoint < 0) distanceToWaitPoint *= -1;
        if (distanceToInteractionPoint < 0) distanceToInteractionPoint *= -1;
        if (distanceToExitPoint < 0) distanceToExitPoint *= -1;
        if (distanceToDespawnPoint < 0) distanceToDespawnPoint *= -1;

        if (distanceToTarget < 0) distanceToTarget *= -1;

        /*
        if (distanceToTarget < interactionRange && nPCstate != eNPCstate.StepBack)
        {
            if (distanceToTarget < interactionRange - stepBackDistance)
            {
                if (!isNPCactive) return;
                SetNPCstate(eNPCstate.StepBack);
            }
        }

        */


        if (distanceToWaitPoint < interactionRange && nPC_state == eNPCstate.MoveTowardsWaitPoint && waveManager.isInteractingWithQuest == false)
        {

            waveManager.isInteractingWithQuest = true;
            if (!isNPC_active) return;
            SetNPCstate(eNPCstate.MoveTowardsInteractionPoint);

        }

        else if (distanceToInteractionPoint < interactionRange && nPC_state == eNPCstate.MoveTowardsInteractionPoint)
        {


            if (!isNPC_active) return;
            animator.SetTrigger("Walk");

            SetNPCstate(eNPCstate.Interaction);
            //FindObjectOfType<NpcDialogueTracker>().trackedNPC = CurrentQuestGivingNPC;


        }
        else if (distanceToWaitPoint < interactionRange && nPC_state == eNPCstate.MoveTowardsWaitPoint && waveManager.isInteractingWithQuest == true)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);


        }

        if (nPC_state == eNPCstate.Interaction && isNPC_InteractionCompleted)
        {
            SetNPCstate(eNPCstate.MoveTowardsExitPoint);
            waveManager.isInteractingWithQuest = false;
        }
        else if (distanceToExitPoint < interactionRange && nPC_state == eNPCstate.MoveTowardsExitPoint)
        {


            if (!isNPC_active) return;
            SetNPCstate(eNPCstate.MoveTowardsDespawnPoint);

        }
        else if(nPC_state == eNPCstate.MoveTowardsDespawnPoint && distanceToDespawnPoint < interactionRange)
        {
            isNPC_active = false;
            Destroy(transform.parent.gameObject);
            waveManager.NPCfinished(transform.parent.gameObject);
        }

    }



    private bool PathIsClear()
    {
        Vector3 direction = new Vector3(-1, 0, 0);
        Debug.DrawRay(this.transform.position, direction * stoppingRange, Color.red);
        RaycastHit[] hits = Physics.RaycastAll(this.transform.position, direction, stoppingRange);
        
        if (hits.Length > 0)
        {
            //print(name + " hits");
            foreach (RaycastHit hit in hits)
            {
                NPC_navigation npc = hit.transform.gameObject.GetComponent<NPC_navigation>();
                if (npc != null)
                {
                    return false;
                }
            }
        }
        else
        {
            
        }
        return true;
    }



    private void SetNPCstate(eNPCstate newState)
    {
        nPC_state = newState;
        switch (nPC_state)
        {
            case eNPCstate.MoveTowardsWaitPoint:
                target = waitPoint;
                animator.SetTrigger("Walk");
                /*                if (isNPC_InteractionPointOccupied && !isNPC_InteractionCompleted && this.transform.position != target.transform.position)
                                {
                                    agent.isStopped = false;
                                    SetNPCstate(eNPCstate.MoveTowardsInteractionPoint);
                                }*/
                break;

            case eNPCstate.MoveTowardsInteractionPoint:
                animator.SetTrigger("Walk");
                target = interactionPoint;
/*                if (!isNPC_InteractionPointOccupied && !isNPC_InteractionCompleted && this.transform.position != target.transform.position)
                {
                    agent.isStopped = false;
                    SetNPCstate(eNPCstate.Interaction);
                }*/
                break;


            case eNPCstate.Interaction:
                isNPC_InteractionPointOccupied = true;
                target = gameObject;
                transform.parent.tag = "InteractingNPC";
                gameObject.tag = "InteractingNPC";
                FindObjectOfType<NpcDialogueTracker>().dialogueBox.SetActive(true);
                FindObjectOfType<NpcDialogueTracker>().yesButton.SetActive(true);
                FindObjectOfType<NpcDialogueTracker>().noButton.SetActive(true);
                FindObjectOfType<NpcDialogueTracker>().GetCurrentNpcData(GetComponentInParent<NPC_object>());
                dialogueController.PlayDialogue();
                animator.SetTrigger("Talk");
                //transform.LookAt(playerManager.transform);
                //npcResourceCostUpdater.QuestResourceRequirements();
                /*                if (isNPC_InteractionCompleted)
                                {
                                    SetNPCstate(eNPCstate.MoveTowardsExitPoint);
                                }*/



                break;

            case eNPCstate.MoveTowardsExitPoint:
                animator.SetTrigger("Walk");
                transform.parent.tag = "Untagged";
                gameObject.tag = "Untagged";
                FindObjectOfType<NpcDialogueTracker>().dialogueBox.SetActive(false);
                FindObjectOfType<NpcDialogueTracker>().yesButton.SetActive(false);
                FindObjectOfType<NpcDialogueTracker>().noButton.SetActive(false);
                FindObjectOfType<NpcDialogueTracker>().ClearCurrentNpcData();
                target = despawnPoint;
                isNPC_InteractionCompleted = true;
                if (!isNPC_InteractionPointOccupied && isNPC_InteractionCompleted && this.transform.position != target.transform.position)
                {
                    isNPC_InteractionPointOccupied = false;
                    agent.isStopped = false;
                    SetNPCstate(eNPCstate.MoveTowardsDespawnPoint);

                }
                break;

            case eNPCstate.MoveTowardsDespawnPoint:
                animator.SetTrigger("Walk");
                target = despawnPoint;
                break;
        }
        if (nPC_state != eNPCstate.Interaction)
        {
            agent.destination = target.transform.position;
        }
    }
    public NavMeshAgent navMeshAgent { get { return agent; } }

    public void idleTrigger()
    {
        if(agent.isStopped == true)
        {
            animator.SetBool("Idle", true);
        }
    }
}
