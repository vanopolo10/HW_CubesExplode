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

    private void Explode(Vector3 explosionPosition)
    {
        foreach (Rigidbody cube in GetExplodableObjects(explosionPosition))
            cube.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 explosionPosition)
    {
        Collider[] hits = Physics.OverlapSphere(explosionPosition, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        
        return cubes;
    }
}
