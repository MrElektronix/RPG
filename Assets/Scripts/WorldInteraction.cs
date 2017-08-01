using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;

    // Use this for initialization
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // als je linkermuisknop naar beneden wordt gedrukt en de muis zit niet op een canvas object
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else
            {
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
