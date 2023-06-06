using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCounter : MonoBehaviour
{
    [SerializeField] private ParticleCollisionDetector particleCollisionDetector;

    private int _dropCountPrevious = 0;
    private int _dropCount = 0;


    public System.Action<int, int> OnDropCountChanged;

    void Start()
    {
        particleCollisionDetector.OnCollisionDetected += RegisterDrop;
    }

    private void RegisterDrop()
    {
        _dropCount++;
        OnDropCountChanged?.Invoke(_dropCount, _dropCountPrevious);
    }

    public void ResetDropCount()
    {
        _dropCountPrevious = _dropCount;
        _dropCount = 0;
        OnDropCountChanged?.Invoke(_dropCount, _dropCountPrevious);
    }
}
