using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private bool _isGroundTouched;

    public event Action<Cube> GroundTouched;
    public event Action<Cube> Destroyed;

    public Material Material {  get; private set; }

    private void Awake()
    {
        Material = GetComponent<MeshRenderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isGroundTouched == false)
            if ( collision.gameObject.TryGetComponent(out Platform platform))
            {
                _isGroundTouched = true;
                GroundTouched?.Invoke(this);
                StartCoroutine(DestroyTimer());
            }
    }

    public void Reload() =>
        _isGroundTouched = false;

    private IEnumerator DestroyTimer()
    {
        int min = 2;
        int max = 5;

        yield return new WaitForSeconds(Random.Range(min, max));
        Destroyed?.Invoke(this);
    }
}
