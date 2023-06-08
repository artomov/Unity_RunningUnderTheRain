using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translator : MonoBehaviour
{
    private Vector3 _initialPosition;

    void Awake()
    {
        _initialPosition = transform.position;
    }

    public void TranslateSelf(Vector3 translationVector, Space space = Space.Self)
    {
        transform.Translate(translationVector, space);
    }
    public void ResetPosition()
    {
        transform.position = _initialPosition;
    }
}
