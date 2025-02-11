using UnityEngine;

public class CubeExploder
{
    private float _radiusDefault;
    private float _forceDefault;

    public CubeExploder(float radius = 5, float force = 100)
    {
        _radiusDefault = radius;
        _forceDefault = force;
    }

    public void Explode(CubeView cube)
    {
        float multiplier = cube.Cube.Multiplier;

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, _radiusDefault / multiplier);

        if (colliders.Length > 0)
            foreach (Collider collider in colliders)
                if (collider.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddExplosionForce(_forceDefault / multiplier, cube.transform.position, _radiusDefault / multiplier);
    }
}
