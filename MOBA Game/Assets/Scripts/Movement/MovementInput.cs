using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementInput : MonoBehaviour {

    // How fast the player should move. (Later take that value from player stats)
    [SerializeField] float movementSpeed;

    // How fast the player should rotate towards the target.
    [SerializeField] float rotationSpeed;

    // The layers the raycast will detect?
    [SerializeField] LayerMask acceptableTarget;

    // The player's camera.
    [SerializeField] Camera playerCam;

    // The NavMeshAgent attached to the player.
    [SerializeField] NavMeshAgent playerAgent;

    // The path given from the NavMesh.
    List<Vector3> path;

    NavMeshPath navMeshPath = new NavMeshPath();

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetTargetPosition(Input.mousePosition);
        }

        if (path != null)
        {
            UpdateMovement();
        }
    }

    void GetTargetPosition(Vector3 mousePos)
    {
        // Raycast from mouse position.
        Ray ray = playerCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, acceptableTarget))
        {
            path = navMeshPath.GetPath(hit.point, playerAgent);

            if(path == null)
            {
                return;
            }

            // Path should be at player height at all time
            for (int i = 0; i < path.Count; i++)
            {
                Vector3 currPos = path[i];
                currPos.y = 5f;
                path[i] = currPos;
            }
        }
    }

    void UpdateMovement()
    {
        Vector3 dir = (path[0] - transform.position).normalized;
        transform.position += dir * movementSpeed * Time.deltaTime;
    }
}
