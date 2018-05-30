using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementInput : MonoBehaviour {

    // How fast the player should move. (Later take that value from player stats)
    [SerializeField] float movementSpeed;

    // How fast the player should rotate towards the target.
    [SerializeField] float rotationSpeed;

    // How close to the target is acceptable?
    [SerializeField] float stoppingDistance;

    // The layers the raycast will detect?
    [SerializeField] LayerMask acceptableTarget;

    // The player's camera.
    [SerializeField] Camera playerCam;

    // The NavMeshAgent attached to the player.
    [SerializeField] NavMeshAgent playerAgent;

    // The path given from the NavMesh.
    List<Vector3> path = new List<Vector3>();

    MovementPath navMeshPath = new MovementPath();

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetTargetPosition(Input.mousePosition);
        }

        if (path.Count > 0)
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
            //Debug.Log(hit.point);
            path = navMeshPath.GetPath(hit.point, playerAgent);

            if(path == null)
            {
                path = new List<Vector3>();
                return;
            }
        }
    }

    void UpdateMovement()
    {
        Vector3 playerPos = transform.position;
        Vector3 targetPos = path[0];

        // Target position should have the same height as player.
        targetPos.y = playerPos.y;
        Vector3 dir = (targetPos - playerPos).normalized;
        transform.position += dir * movementSpeed * Time.deltaTime;

        if(Vector3.Distance(targetPos, playerPos) <= stoppingDistance)
        {
            if(path.Count > 1)
            {
                path.RemoveAt(0);
            }
            else
            {
                path = new List<Vector3>();
            }
        }
    }
}
