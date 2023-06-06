using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    [SerializeField] float _guySpeed;
    public float GuySpeed => _guySpeed;

    private bool _shouldGyuMove = true;
    public bool ShouldGuyMove => _shouldGyuMove;

    void Awake()
    {
        if (Instance != null && Instance != this)
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
}
