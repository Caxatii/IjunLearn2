using UnityEngine;
using Random = UnityEngine.Random;

public class CubeDivider : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;

    private CubeDetecter _detector = new();
    private CubeExploder _exploder = new();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (_detector.TryRaycastCube(out CubeView cube))
            DivideCube(cube);
    }

    private void DivideCube(CubeView cubeView)
    {
        float multiplier = cubeView.Cube.Multiplier;
        Vector3 position = cubeView.transform.position;

        if (Random.Range(0f, 1f) < multiplier)
        {
            _spawner.Spawn(position, multiplier);
        }
        else
        {
            _exploder.Explode(cubeView);
        }

        Destroy(cubeView.gameObject);
    }
}