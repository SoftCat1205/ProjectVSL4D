using System;
using Fusion;
using UnityEngine;

public class MPlayerController : NetworkBehaviour
{
    [SerializeField] private MPlayerMovement playerMovement;

    public override void FixedUpdateNetwork()
    {
        Debug.Log($"InputAuthority={Object.HasInputAuthority}, StateAuthority={Object.HasStateAuthority}");

        if (!GetInput(out NetworkInputData input))
            return;

        playerMovement.Move(input.Move);

        Debug.Log($"Transform: {transform.position}");
    }

    public override void Spawned()
    {
        Debug.Log(
            $"Spawned! StateAuthority={Object.HasStateAuthority}, InputAuthority={Object.HasInputAuthority}"
        );
    }
}
