using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    public event Action<Cube> Split;

    private int _hundredPercent = 100;
    
    public int CloneChance { get; private set; } = 100;
    
    private void OnMouseDown()
    {
        if (Random.Range(1, _hundredPercent + 1) <= CloneChance)
        {
            print(CloneChance);
            Split?.Invoke(this);
        }
        
        Destroy(gameObject);
    }

    public void Init(int cloneChance, Vector3 size)
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        
        CloneChance = cloneChance;

        gameObject.transform.localScale = size;
    }
}
