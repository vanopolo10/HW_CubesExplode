using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private int _hundredPercent = 100;
    
    public event Action<Cube> Split;
    
    public int CloneChance { get; private set; } = 100;
    
    private void OnMouseDown()
    {
        if (Random.Range(1, _hundredPercent + 1) <= CloneChance)
        {
            Split?.Invoke(this);
        }
        
        Destroy(gameObject);
    }

    public void Init(int cloneChance, Vector3 size)
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        
        CloneChance = cloneChance;

        gameObject.transform.localScale = size;
    }
}
