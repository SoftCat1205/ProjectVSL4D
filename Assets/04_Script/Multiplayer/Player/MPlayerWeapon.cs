using Fusion;
using UnityEngine;

public class MPlayerWeapon : NetworkBehaviour
{
    [Header("Weapon Slots")]
    [SerializeField] private MWeapon leftArm;
    [SerializeField] private MWeapon rightArm;
    [SerializeField] private MWeapon leftBack;
    [SerializeField] private MWeapon rightBack;

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