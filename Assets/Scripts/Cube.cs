using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    public float Multiplier;

    public Rigidbody Body {  get; private set; }

    private void OnEnable()
    {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        Body = GetComponent<Rigidbody>();
    }
}
