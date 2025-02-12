using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class CubeLifespan : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnDelay;

    [SerializeField] private Cube _prefab;

    private ObjectPool<Cube> _pool;

    private UserInput _input = new();
    private CubeColorize _colorize = new(UnityEngine.Color.white);

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(createFunc: () => Create(),
                                     actionOnGet: (cube) => GetCube(cube),
                                     actionOnRelease: (cube) => ReleaseCube(cube));
    }

    private IEnumerator Start()
    {
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while(_input.IsEscape == false)
        {
            Spawn();

            yield return delay;
        }
    }

    private void Spawn()
    {
        Cube cube = _pool.Get();

        Vector3 cubePosition = transform.position;
        cubePosition.x += Random.Range(-_spawnRadius, _spawnRadius);
        cubePosition.z += Random.Range(-_spawnRadius, _spawnRadius);

        cube.transform.position = cubePosition;
        cube.transform.rotation = Quaternion.identity;
    }

    private void ReleaseCube(Cube cube)
    {
        _colorize.Return(cube);
        cube.GroundTouched -= Color;
        cube.Destroyed -= _pool.Release;
        cube.gameObject.SetActive(false);
        cube.Reload();
    }

    private void GetCube(Cube cube)
    {
        cube.gameObject.SetActive(true);
        cube.GroundTouched += Color;
        cube.Destroyed += _pool.Release;
        _colorize.Return(cube);
    }

    private Cube Create()
    {
        return Instantiate(_prefab);
    }

    private void Color(Cube cube)
    {
        _colorize.Paint(cube);
    }

    private IEnumerator Delay(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
}