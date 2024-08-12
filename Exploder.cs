using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private float _explosionForce = 200;
    
    private void OnEnable()
    {
        _spawner.CubesSpawned += Explode;
    }
    
    private void OnDisable()
    {
        _spawner.CubesSpawned += Explode;
    }

    private void Explode(Vector3 explosionPosition, List<Rigidbody> cubes)
    {
        foreach (Rigidbody cube in cubes)
            cube.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }
}
