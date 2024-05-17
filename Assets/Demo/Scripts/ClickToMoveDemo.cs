using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMoveDemo : MonoBehaviour
{
 public NavMeshAgent playerAgent; // Reference to the player's NavMeshAgent
    public GameObject clickIndicatorPrefab; // Prefab of the sphere to place at the clicked location

    private GameObject currentClickIndicator; // Reference to the current click indicator
    public float speed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Remove the previous click indicator if it exists
                if (currentClickIndicator != null)
                {
                    Destroy(currentClickIndicator);
                }

                // Place the new click indicator at the hit point
                currentClickIndicator = Instantiate(clickIndicatorPrefab, hit.point, Quaternion.identity);

                // Move the player agent to the hit point
                if (playerAgent != null)
                {
                    playerAgent.SetDestination(hit.point);
                    playerAgent.speed = speed;
                }
            }
        }
    }
}
