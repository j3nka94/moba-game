using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementPath {

    public List<Vector3> GetPath(Vector3 targetPosition, NavMeshAgent agent)
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        agent.CalculatePath(targetPosition, navMeshPath);

        int counter = 0;
        while (navMeshPath.status != NavMeshPathStatus.PathComplete || counter < 200)
        {
            // Wait for path and use counter in case of an infinite loop
            counter++;

            if(counter >= 200 && navMeshPath.status != NavMeshPathStatus.PathComplete)
            {
                return null;
            }
        }

        if (navMeshPath.status == NavMeshPathStatus.PathComplete)
        {
            // Convert from array to list
            List<Vector3> path = new List<Vector3>();
            for (int i = 0; i < navMeshPath.corners.Length; i++)
            {
                path.Add(navMeshPath.corners[i]);
                Debug.Log(navMeshPath.corners[i]);
            }

            return path;
        }

        return null;
    }
}
