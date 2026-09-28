using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }
    public event Action OnRotate;
    public event Action OnEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnRotateKeyDown(InputAction.CallbackContext context)
    {
        if (context.performed) OnRotate?.Invoke();
    }

    public void OnFunctionKeyDown(InputAction.CallbackContext context)
    {
        if (context.performed) OnEvent?.Invoke();
    }
}
