using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMover : MonoBehaviour
{

    [SerializeField] private Transform _referenceTransform;
    [SerializeField] private Transform _pivotForward;
    [SerializeField] private Transform _pivotBackward;
    [SerializeField] private float _angle;

    [SerializeField] private ControlsUI controlsUI;

    private Translator _pivotForwardTranslator;
    private Translator _pivotBackwardTranslator;

    private Vector3 _pivotForwardPositionDifference;
    private Vector3 _pivotBackwardPositionDifference;

    void Awake()
    {

        _pivotForwardTranslator = _pivotForward.GetComponent<Translator>();
        _pivotBackwardTranslator = _pivotBackward.GetComponent<Translator>();

        _pivotForwardPositionDifference = transform.position - _pivotForward.position;
        _pivotBackwardPositionDifference = transform.position - _pivotBackward.position;
    }

    void Update()
    {
        if (GameManager.Instance.ShouldGuyMove)
        {
            Vector3 translationVector = _referenceTransform.right * GameManager.Instance.GuySpeed * Time.deltaTime;
            transform.Translate(translationVector, Space.World);
            _pivotForwardTranslator.TranslateSelf(translationVector, Space.World);
            _pivotBackwardTranslator.TranslateSelf(translationVector, Space.World);
        }
    }

    public void ResetPosition()
    {
        SetRotation(0);
        transform.position = _referenceTransform.position;
        _pivotForwardTranslator.ResetPosition();
        _pivotBackwardTranslator.ResetPosition();
        SetRotation(controlsUI.GuyAngle);
    }

    public void SetRotation(float angle)
    {
        // chosing the pivot
        Transform pivot = (angle > 0)? _pivotForward : _pivotBackward;
        Vector3 posDiff = (angle > 0)? _pivotForwardPositionDifference : _pivotBackwardPositionDifference;

        // set to pivot -> rotate -> move back
        transform.SetPositionAndRotation(pivot.position, pivot.rotation);
        transform.Rotate(transform.forward, -angle);
        transform.Translate(posDiff);
    }
}
