using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField]
    private float _delay;

    private int _count;

    private Coroutine _coroutine;
    private bool _isWorking = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isWorking == false)
            Begin();

        if (Input.GetMouseButtonDown(1) && _isWorking)
            Stop();
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

            Debug.Log(_count);

            yield return delay;
        }
    }
}
