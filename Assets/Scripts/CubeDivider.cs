using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class CubeDivider : MonoBehaviour, IPointerClickHandler
{
    protected float Multiplier = 1;

    protected Rigidbody Rigidbody;

    public void OnPointerClick(PointerEventData eventData)
    {
        Divide();
    }

    private void Divide()
    {
        if (Random.Range(0f, 1f) < Multiplier)
        {
            for (int i = 0; i < GetDivideAmount(); i++)
                CreateCube();
        }

        Destroy(gameObject);
    }

    private void CreateCube()
    {
        float force = 5;
        float radius = 5;
        float upward = 5;
        int divider = 2;

        CubeDivider cube = Instantiate(gameObject).GetComponent<CubeDivider>();
        cube.Multiplier = Multiplier / divider;
        cube.transform.localScale /= divider;
        cube.Rigidbody.AddExplosionForce(force, transform.position, radius, upward, ForceMode.Impulse);
    }

    private int GetDivideAmount()
    {
        int min = 2;
        int max = 6;

        return Random.Range(min, max);
    }

    private void OnEnable()
    {
        Rigidbody ??= GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
