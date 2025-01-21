using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField]
    private Counter _counter;

    private void OnValidate()
    {
        if (_counter != null)
            _counter.OnValueChanged += Show;
    }

    private void Show(int count)
    {
        Debug.Log(count);
    }

    private void OnDisable()
    {
        _counter.OnValueChanged -= Show;
    }
}
