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
    private CubeColorize _colorize = new(Color.white);

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(createFunc: () => Instantiate(_prefab));
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
        cube.gameObject.SetActive(true);
        cube.OnGroundTouched += Prepare;

        _colorize.Return(cube);

        Vector3 cubePosition = transform.position;
        cubePosition.x += Random.Range(-_spawnRadius, _spawnRadius);
        cubePosition.z += Random.Range(-_spawnRadius, _spawnRadius);

        cube.transform.position = cubePosition;
        cube.transform.rotation = Quaternion.identity;
    }

    private void Prepare(Cube cube)
    {
        float min = 2;
        float max = 5;

        _colorize.Random(cube);
        float time = Random.Range(min, max);

        StartCoroutine(Delay(() => Release(cube), time));
    }

    private void Release(Cube cube)
    {
        cube.Material.color = Color.white;
        cube.OnGroundTouched -= Prepare;
        cube.gameObject.SetActive(false);
        cube.Reload();
        _pool.Release(cube);
    }

    private IEnumerator Delay(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
}