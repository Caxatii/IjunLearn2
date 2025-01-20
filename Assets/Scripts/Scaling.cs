using UnityEngine;

public class Scaling : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.localScale += Vector3.one * _speed * Time.deltaTime;
    }
}
