using UnityEngine;
using Random = UnityEngine.Random;

public class CubeDivider : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (GetRaycast(out RaycastHit hit))
            if (hit.collider.TryGetComponent(out Cube cube))
                DivideCube(cube);
    }

    private void DivideCube(Cube cube)
    {
        float multiplier = cube.Multiplier;
        Vector3 position = cube.transform.position;

        Destroy(cube.gameObject);

        if (Random.Range(0f, 1f) > multiplier)
            return;

        for (int i = 0; i < GetDivideAmount(); i++)
            CreateCube(position, multiplier);
    }

    private void CreateCube(Vector3 position, float multiplier)
    {
        int divider = 2;
        float force = 5;
        float radius = 5;

        Cube newCube = Instantiate(_cubePrefab);
        newCube.transform.position = position;
        newCube.Multiplier = multiplier / divider;
        newCube.transform.localScale *= newCube.Multiplier;
        newCube.Body.AddExplosionForce(force, position, radius, default, ForceMode.Impulse);
    }

    private bool GetRaycast(out RaycastHit hit)
    {
        return Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
    }

    private int GetDivideAmount()
    {
        int min = 2;
        int max = 6;

        return Random.Range(min, max);
    }
}
