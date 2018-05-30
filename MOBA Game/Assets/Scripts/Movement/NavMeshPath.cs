using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPath {

    public List<Vector3> GetPath(Vector3 targetPos, NavMeshAgent agent)
    {
        agent.SetDestination(targetPos);

        while (agent.pathPending)
        {
            //Wait for path
        }

        if (agent.hasPath)
        {
            // Convert from array to list
            List<Vector3> positions = new List<Vector3>();
            for (int i = 0; i < agent.path.corners.Length; i++)
            {
                positions.Add(agent.path.corners[i]);
            }

            return positions;
        }

        return null;
    }
}
