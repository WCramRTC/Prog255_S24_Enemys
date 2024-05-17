using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class DriveToPoint : MonoBehaviour
{
    NavMeshAgent vehicle;
    public GameObject[] destination;
    private Transform currentDestination;
     public float threshold = 0.1f;
     public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        currentDestination = destination[0].transform;
        vehicle = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        
        vehicle.SetDestination(currentDestination.position);
        vehicle.speed = speed;
        
        // Check if the destination has been reached
        if (!vehicle.pathPending && vehicle.remainingDistance <= vehicle.stoppingDistance && vehicle.remainingDistance <= threshold)
        {
            if (vehicle.hasPath || vehicle.velocity.sqrMagnitude == 0f)
            {
                // Arrived at destination
                currentDestination = destination[1].transform;
            }
        }

    }
}
