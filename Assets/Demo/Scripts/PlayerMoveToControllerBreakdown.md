Certainly! Here is a simple script to make a Nav Mesh Agent navigate to a target GameObject, with the ability to control the speed of the agent.

### Step-by-Step Instructions:

1. **Ensure you have a GameObject with a Nav Mesh Agent component**:
   - Select your agent GameObject.
   - Add the `NavMeshAgent` component (`Component > Navigation > NavMeshAgent`).

2. **Create a target GameObject**:
   - Create a GameObject in your scene that will act as the target.
   - Position it within the bounds of the Nav Mesh.

3. **Create a script**:
   - Create a new C# script in your project and name it `AgentController`.
   - Attach this script to the GameObject that has the `NavMeshAgent` component.

4. **Edit the script**:

```csharp
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
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
```

### Explanation:

- **target**: A public Transform that represents the target GameObject. Assign this in the Inspector.
- **speed**: A public float for setting the speed of the agent. You can adjust this in the Inspector or through script.
- **NavMeshAgent agent**: A reference to the Nav Mesh Agent component.

### Script Breakdown:

1. **Start Method**:
   - Get the `NavMeshAgent` component.
   - Check if the agent and target are set.
   - Set the agent's destination to the target's position.
   - Set the agent's speed.

2. **Update Method**:
   - Continuously update the agent's destination if the target moves.
   - Optionally, adjust the agent's speed dynamically using the up and down arrow keys.

### Usage:

1. Attach the script to the agent GameObject.
2. Assign the target GameObject to the `target` field in the Inspector.
3. Adjust the `speed` as needed in the Inspector.

This script will allow the Nav Mesh Agent to navigate to the target GameObject and let you control its speed dynamically.