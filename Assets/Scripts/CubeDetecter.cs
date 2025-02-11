using UnityEngine;

public class CubeDetecter
{
    public bool TryRaycastCube(out CubeView cube)
    {
        cube = default;

        if (GetRaycast(out RaycastHit hit))
            return hit.collider.TryGetComponent(out cube);

        return false;
    }

    private bool GetRaycast(out RaycastHit hit)
    {
        return Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
    }
}
