using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCubeAmount = 2;
    [SerializeField] private int _maxCubeAmount = 6;

    [SerializeField] private Cube _scenedCube;
    
    private int _cloneChanceReduce = 2;
    private int _cloneScaleReduce = 2;

    public event Action<Vector3, List<Rigidbody>> CubesSpawned;

    private void Awake()
    {
        _scenedCube.Split += SpawnCubes;
    }

    private void SpawnCubes(Cube cube)
    {
        cube.Split -= SpawnCubes;

        int cloneChance = cube.CloneChance / _cloneChanceReduce;

        int cubeAmount = Random.Range(_minCubeAmount, _maxCubeAmount + 1);
        
        Vector3 newSize = cube.transform.localScale /= _cloneScaleReduce;

        List<Rigidbody> cubesRigidbody = new List<Rigidbody>();
        
        for (int i = 0; i < cubeAmount; i++)
        {
            var clone = Instantiate(cube, cube.transform.position, new Quaternion());
        
            clone.Init(cloneChance, newSize);
            
            cubesRigidbody.Add(clone.GetComponent<Rigidbody>());
            
            clone.Split += SpawnCubes;
        }
        
        CubesSpawned?.Invoke(cube.transform.position, cubesRigidbody);
    }
}
