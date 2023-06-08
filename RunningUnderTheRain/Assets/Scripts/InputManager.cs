using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {get; private set;}

    private bool _isMousePressed = false;
    public bool IsMousePressed => _isMousePressed;

    private InputControls inputControls;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Attempt to create an additional instance of InputManager (singleton)");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        inputControls = new InputControls();
        inputControls.MainMap.Enable();
        inputControls.MainMap.MousePress.started += OnMousePressStarted;
        inputControls.MainMap.MousePress.canceled += OnMousePressCanceled;
    }

    private void OnMousePressStarted(InputAction.CallbackContext obj)
    {
        _isMousePressed = true;
    }
    private void OnMousePressCanceled(InputAction.CallbackContext obj)
    {
        _isMousePressed = false;
    }

    public Vector2 ReadMouseDelta()
    {
        return inputControls.MainMap.MousePosition.ReadValue<Vector2>();
    }
}
