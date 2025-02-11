using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> OnGroundTouched;

    private bool _isGroundTouched;

    public Material Material {  get; private set; }

    private void Awake()
    {
        Material = GetComponent<MeshRenderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
            if (_isGroundTouched == false)
            {
                _isGroundTouched = true;
                OnGroundTouched?.Invoke(this);
            }
    }

    public void Reload() =>
        _isGroundTouched = false;
}
