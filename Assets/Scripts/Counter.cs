using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField]
    private float _delay;

    private int _count;

    private Coroutine _coroutine;
    private bool _isWorking = false;

    public event Action<int> OnValueChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (_isWorking)
            Stop();
        else
            Begin();
    }

    private void Begin()
    {
        _isWorking = true;
        _coroutine = StartCoroutine(Process());
    }

    private void Stop()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
        _isWorking = false;
    }

    private IEnumerator Process()
    {
        var delay = new WaitForSeconds(_delay);

        while (_isWorking)
        {
            _count++;

            OnValueChanged?.Invoke(_count);

            yield return delay;
        }
    }
}
