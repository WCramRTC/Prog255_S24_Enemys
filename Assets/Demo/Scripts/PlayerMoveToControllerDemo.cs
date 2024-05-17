using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveToControllerDemo : MonoBehaviour
{
    public Transform target;  // The target GameObject
    public float speed = 3.5f;  // Speed of the agent

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found on this GameObject.");
            return;
        }

        if (target != null)
        {
            agent.SetDestination(target.position);
            agent.speed = speed;  // Set the speed of the agent
        }
        else
        {
            Debug.LogError("Target not set for the NavMeshAgent.");
        }
    }

    void Update()
    {
        // Update the agent's destination if the target moves
        if (target != null)
        {
            agent.SetDestination(target.position);
        }

        // Change the speed dynamically using keys (optional)
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += 0.5f;
            agent.speed = speed;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed = Mathf.Max(0.5f, speed - 0.5f);  // Ensure speed doesn't go below 0.5
            agent.speed = speed;
        }
    }

}
