using Fusion;
using UnityEngine;

public class MPlayerWeapon : NetworkBehaviour
{
    [Header("Weapon Slots")]
    [SerializeField] private MWeaponController leftArm;
    [SerializeField] private MWeaponController rightArm;
    [SerializeField] private MWeaponController leftBack;
    [SerializeField] private MWeaponController rightBack;

    public void Activate(NetworkInputData input)
    {
        if (input.Buttons.IsSet(InputButtons.LeftArm))
        {
            if (leftArm != null)
                leftArm.Activate();
        }

        if (input.Buttons.IsSet(InputButtons.RightArm))
        {
            if (rightArm != null)
                rightArm.Activate();
        }

        if (input.Buttons.IsSet(InputButtons.LeftBack))
        {
            if (leftBack != null)
                leftBack.Activate();
        }

        if (input.Buttons.IsSet(InputButtons.RightBack))
        {
            if (rightBack != null)
                rightBack.Activate();
        }
    }
}