using UnityEngine;
using Fusion;

public enum InputButtons
{
    LeftArm,
    RightArm,
    LeftBack,
    RightBack,
    Augment,
    Interact
}

public struct NetworkInputData : INetworkInput
{
    public Vector2 Move;
    public Vector2 Aim;
    public NetworkButtons Buttons;
}