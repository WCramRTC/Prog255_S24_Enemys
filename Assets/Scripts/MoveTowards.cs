using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    // Target
    public GameObject target;

    // Start is called before the first frame update
    public float speed = 5.0f;

    void Update() {
        // Current position
        Vector3 currentPosition = transform.position;

        // Target position
        Vector3 targetPosition = target.transform.position;

        // Ensuring the y-coordinate remains constant if needed
        targetPosition.y = currentPosition.y;

        // Calculate the new position moving towards the target
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        // Update the object's position
        transform.position = newPosition;
    }


    // // Update is called once per frame
    // void Update()
    // {
    //     // Speed 
    //     // Meili was correct - we needed to mulitply by Time.deltaTime
    //     // Direction 
    //     Vector3 distanceFrom = transform.position - target.transform.position / 60f; 

    //     // Old school route
    //     // transform.position += target.transform.position * Time.deltaTime;

    //     // MoveTowards

    // }
}
