using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    private NavMeshAgent playerAgent;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;
        Interact();
    }

    void Update()
    {
        if (playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {

            }

        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class");
    }
}

