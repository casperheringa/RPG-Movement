using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class worldInteraction : MonoBehaviour {
    NavMeshAgent playerAgent;

    [SerializeField]
    GameObject ping;
    GameObject currentPing;

    void Start()
    {

        playerAgent = GetComponent<NavMeshAgent>();
        currentPing = Instantiate(ping, transform.position, Quaternion.identity);

    }

    void Update () {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            GetInteraction();

        currentPing.SetActive(playerAgent.remainingDistance > 0.5f);
        	
	}
    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if(Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObj = interactionInfo.collider.gameObject;
            playerAgent.destination = currentPing.transform.position = interactionInfo.point;
        }
    }

}
