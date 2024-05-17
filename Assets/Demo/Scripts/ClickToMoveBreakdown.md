Certainly! Here is a script that will place a sphere at the clicked location and move a Nav Mesh Agent to that position.

### Step-by-Step Instructions:

1. **Create a GameObject with a Nav Mesh Agent**:
   - Select your agent GameObject.
   - Add the `NavMeshAgent` component (`Component > Navigation > NavMeshAgent`).

2. **Create a new script**:
   - Create a new C# script in your project and name it `ClickToMove`.
   - Attach this script to an empty GameObject in your scene (e.g., `GameController`).

3. **Edit the script**:

```csharp
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public NavMeshAgent playerAgent; // Reference to the player's NavMeshAgent
    public GameObject clickIndicatorPrefab; // Prefab of the sphere to place at the clicked location

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Place the click indicator at the hit point
                Instantiate(clickIndicatorPrefab, hit.point, Quaternion.identity);

                // Move the player agent to the hit point
                if (playerAgent != null)
                {
                    playerAgent.SetDestination(hit.point);
                }
            }
        }
    }
}
```

### Explanation:

- **playerAgent**: A public reference to the Nav Mesh Agent component on the player.
- **clickIndicatorPrefab**: A public reference to a prefab that represents the sphere to be instantiated at the clicked location.

### Script Breakdown:

1. **Update Method**:
   - Check if the left mouse button is clicked (`Input.GetMouseButtonDown(0)`).
   - Cast a ray from the camera to the mouse position (`ScreenPointToRay`).
   - If the ray hits a collider in the scene (`Physics.Raycast`):
     - Instantiate the click indicator prefab at the hit point.
     - Move the player agent to the hit point using `SetDestination`.

### Usage:

1. Attach the script to an empty GameObject (e.g., `GameController`).
2. Assign the player GameObject (with the Nav Mesh Agent component) to the `playerAgent` field in the Inspector.
3. Create a sphere prefab to use as the click indicator:
   - Create a sphere in your scene (`GameObject > 3D Object > Sphere`).
   - Adjust its size and appearance as needed.
   - Drag it from the scene hierarchy to the project window to create a prefab.
4. Assign the sphere prefab to the `clickIndicatorPrefab` field in the Inspector.

This script will allow you to click on any point in the scene, place a sphere at the clicked location, and move the Nav Mesh Agent to that position.

Sure! To ensure that only one sphere is present at any time, you can modify the script to remove the previous sphere before placing a new one. Here's the updated script:

### Updated Script

```csharp
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    public NavMeshAgent playerAgent; // Reference to the player's NavMeshAgent
    public GameObject clickIndicatorPrefab; // Prefab of the sphere to place at the clicked location

    private GameObject currentClickIndicator; // Reference to the current click indicator

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
                }
            }
        }
    }
}
```

### Explanation of Changes

- **currentClickIndicator**: A private variable to keep track of the currently active click indicator.
- **Remove Previous Indicator**: Before instantiating a new click indicator, the script checks if there is an existing one and destroys it (`Destroy(currentClickIndicator)`).
- **Update Reference**: After creating the new click indicator, it updates the `currentClickIndicator` reference.

### Usage

1. Attach the updated script to an empty GameObject (e.g., `GameController`).
2. Assign the player GameObject (with the Nav Mesh Agent component) to the `playerAgent` field in the Inspector.
3. Assign the sphere prefab to the `clickIndicatorPrefab` field in the Inspector.

This script ensures that each time you click, the previous sphere is removed before placing a new one, keeping only one sphere in the scene at a time.