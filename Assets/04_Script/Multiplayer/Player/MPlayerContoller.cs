using Fusion;
using UnityEngine;

public class MPlayerController : NetworkBehaviour
{
    [SerializeField] private MPlayerMovement playerMovement;
    [SerializeField] private MPlayerFacing playerFacing;
    [SerializeField] private MPlayerAim playerAim;
    [SerializeField] private MPlayerWeapon playerWeapon;
    [SerializeField] private MPlayerCamera playerCamera;

    [SerializeField] private MWeapon startWeapon;

    public Vector2 AimDirection { get; private set; }

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasInputAuthority)
            return;

        if (!GetInput(out NetworkInputData input))
            return;

        AimDirection = (input.Aim - (Vector2)transform.position).normalized;

        playerMovement.Move(input.Move);
        playerFacing.Facing(AimDirection);
        playerAim.Aim(AimDirection);
        playerWeapon.Activate(input, AimDirection);
        playerCamera.UpdateAim(AimDirection);
    }

    public override void Spawned()
    {
        Debug.Log($"Spawned! StateAuthority={Object.HasStateAuthority}, InputAuthority={Object.HasInputAuthority}");

        playerWeapon.EquipWeapon(startWeapon, 0);
    }
}
