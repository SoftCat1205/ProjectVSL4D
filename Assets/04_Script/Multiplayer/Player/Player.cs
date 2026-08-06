using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerFacing playerFacing;
    [SerializeField] private PlayerAim playerAim;
    [SerializeField] private WeaponManager playerWeapon;
    [SerializeField] private PlayerCamera playerCamera;

    [SerializeField] private WeaponScriptableObject startWeapon;

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
