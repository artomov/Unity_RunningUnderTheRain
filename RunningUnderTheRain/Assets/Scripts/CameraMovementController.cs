using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private float MouseXSensitivity;
    [SerializeField] private float MouseYSensitivity;
    [SerializeField] private CursorRaycastAnalyzer cursorRaycastAnalyzer;

    private CinemachineFreeLook freeLook;

    void Awake()
    {
        freeLook = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        if (!cursorRaycastAnalyzer.IsOverUI())
        {
            if(InputManager.Instance.IsMousePressed)
            {
                UpdateCameraPosition();
            }
        }
    }

    private void UpdateCameraPosition()
    {
        Vector2 mouseDelta = InputManager.Instance.ReadMouseDelta();

        freeLook.m_XAxis.Value += mouseDelta[0] * Time.deltaTime * MouseXSensitivity;
        freeLook.m_XAxis.Value = Mathf.Clamp(freeLook.m_XAxis.Value, -180f, 180f);

        freeLook.m_YAxis.Value += mouseDelta[1] * Time.deltaTime * MouseYSensitivity;
        freeLook.m_YAxis.Value = Mathf.Clamp(freeLook.m_YAxis.Value, -1f, 1f);

    }

}
