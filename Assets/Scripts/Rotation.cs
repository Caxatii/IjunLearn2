using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Rotate(0, _speed, 0);
    }
}
