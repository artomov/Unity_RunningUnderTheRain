using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMover : MonoBehaviour
{
    private Vector3 _initialPosition;

    void Awake()
    {
        _initialPosition = transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.ShouldGuyMove)
        {
            transform.Translate(transform.right * GameManager.Instance.GuySpeed * Time.deltaTime);
        }
    }

    public void ResetPosition()
    {
        transform.position = _initialPosition;
    }
}
