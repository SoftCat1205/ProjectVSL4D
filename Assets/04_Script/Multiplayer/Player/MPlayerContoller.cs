using Fusion;
using UnityEngine;

public class MPlayerController : NetworkBehaviour
{
    [SerializeField] private MPlayerMovement playerMovement;
    [SerializeField] private MPlayerFacing playerFacing;
    [SerializeField] private MPlayerAim playerAim;
    [SerializeField] private MPlayerWeapon playerWeapon;

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasInputAuthority)
            return;

        if (!GetInput(out NetworkInputData input))
            return;

        playerMovement.Move(input.Move);
        playerFacing.Facing(input.Aim);
        playerAim.Aim(input.Aim);
        playerWeapon.Activate(input);
    }

    public override void Spawned()
    {
        Debug.Log($"Spawned! StateAuthority={Object.HasStateAuthority}, InputAuthority={Object.HasInputAuthority}");
    }
}
