using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private float _guySpeed = 0f;
    public float GuySpeed => _guySpeed;

    private bool _shouldGyuMove = false;
    public bool ShouldGuyMove => _shouldGyuMove;

    [SerializeField] private GuyMover _guyMover;
    [SerializeField] private DropCounter _dropCounter;

    void Awake()
    {
        if (Instance != null && Instance != this) // singleton stuff
        {
            Debug.LogWarning("Attempt to create additional instance of GameManager (singleton)");
            Destroy(gameObject);
        } 
        else
        {
            Instance = this;
        }
    }

    public void SetShouldMove(bool shouldMove)
    {
        _shouldGyuMove = shouldMove;
    }

    public void ResetGame()
    {
        SetShouldMove(false);
        _guyMover.ResetPosition();
        _dropCounter.ResetDropCount();
    }

    public void SetGuySpeed_kmh(float speed)
    {
        _guySpeed = speed / 3.6f;
    }

    public void SetGuyAngle(float angle)
    {
        _guyMover.SetRotation(angle);
    }
}
