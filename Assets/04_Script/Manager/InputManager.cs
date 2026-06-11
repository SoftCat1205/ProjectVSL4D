using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public InputSystem_Actions inputActions;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Dodge.performed += OnDodge;
        inputActions.Player.Augment.performed += OnAugment;
        inputActions.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        inputActions.Player.Dodge.performed -= OnDodge;
        inputActions.Player.Augment.performed -= OnAugment;
        inputActions.Player.Interact.performed -= OnInteract;

        inputActions.Disable();
    }

    private void OnDodge(InputAction.CallbackContext context)
    {

    }

    private void OnAugment(InputAction.CallbackContext context)
    {

    }

    private void OnInteract(InputAction.CallbackContext context)
    {

    }
}