using UnityEngine;
using UnityEngine.AI;

public class DestroyObjectOnClick : MonoBehaviour {

    public LayerMask layerMask;
    public Camera cam;
    public NavMeshSurface surface;

	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log(hit.collider.gameObject);
                Destroy(hit.collider.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            RecalculateNavMesh.UpdateNavMesh(surface);
        }
	}
}
