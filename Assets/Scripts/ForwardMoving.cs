using UnityEngine;

public class ForwardMoving : MonoBehaviour
{
    [SerializeField] private float _speed;

    void FixedUpdate()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
