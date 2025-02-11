using UnityEngine;

public class CubeSpawner : MonoBehaviour 
{
    [SerializeField] private CubeView _prefab;

    public void Spawn(Vector3 position, float multiplier)
    {
        for (int i = 0; i < GetDivideAmount(); i++)
            CreateCube(position, multiplier);
    }

    private void CreateCube(Vector3 position, float multiplier)
    {
        int divider = 2;
        float force = 5;
        float radius = 5;

        CubeView newCube = Instantiate(_prefab);
        newCube.Initialize(new Cube(multiplier / divider));
        newCube.transform.position = position;
        newCube.transform.localScale *= newCube.Cube.Multiplier;
        newCube.Body.AddExplosionForce(force, position, radius, default, ForceMode.Impulse);
    }

    private int GetDivideAmount()
    {
        int min = 2;
        int max = 6;

        return Random.Range(min, max);
    }
}
