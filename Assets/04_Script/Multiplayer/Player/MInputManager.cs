using UnityEngine;

public class MInputManager : MonoBehaviour
{
    public Vector2 Move { get; private set; }
    public Vector2 Aim { get; private set; }

    public bool LeftArm { get; private set; }
    public bool RightArm { get; private set; }
    public bool LeftShoulder { get; private set; }
    public bool RightShoulder { get; private set; }
    public bool Augment { get; private set; }
    public bool Interact { get; private set; }

    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void Update()
    {
        Move = _inputActions.Player.Move.ReadValue<Vector2>();
        Vector2 screenAim = _inputActions.Player.Aim.ReadValue<Vector2>();
        Aim = Camera.main.ScreenToWorldPoint(screenAim);
        LeftArm = _inputActions.Player.LeftArm.IsPressed();
        RightArm = _inputActions.Player.RightArm.IsPressed();
        LeftShoulder = _inputActions.Player.LeftShoulder.IsPressed();
        RightShoulder = _inputActions.Player.RightShoulder.IsPressed();
        Augment = _inputActions.Player.Augment.IsPressed();
        Interact = _inputActions.Player.Interact.IsPressed();
    }
}