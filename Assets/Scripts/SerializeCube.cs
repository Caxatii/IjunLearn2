using UnityEngine;

[RequireComponent (typeof(CubeView))]
public class SerializeCube : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<CubeView>().Initialize(new Cube(1));
    }
}
