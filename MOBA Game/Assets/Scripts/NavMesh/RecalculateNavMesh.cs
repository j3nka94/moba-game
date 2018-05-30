using UnityEngine.AI;

public static class RecalculateNavMesh {

    public static void UpdateNavMesh(NavMeshSurface surface)
    {
        surface.BuildNavMesh();
    }
}
