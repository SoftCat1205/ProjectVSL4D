using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class MPlayerWeapon : NetworkBehaviour
{
    [Header("Weapon Slots")]
    [SerializeField] private List<MWeaponController> weaponControllers = new(4);

    [Header("Weapon Positions")]
    [SerializeField] private List<Transform> weaponPositions = new(4);

    public void EquipWeapon(MWeaponController weaponController, int index)
    {
        MWeaponController weapon = Runner.Spawn(weaponController, weaponPositions[index].position, weaponPositions[index].rotation);

        weaponControllers[index] = weapon;

        weapon.transform.SetParent(weaponPositions[index]);
    }

    public void Activate(NetworkInputData input)
    {
        if (input.Buttons.IsSet(InputButtons.LeftArm))
        {
            if (weaponControllers[0] != null)
                weaponControllers[0].Activate(input.Aim);
        }

        if (input.Buttons.IsSet(InputButtons.RightArm))
        {
            if (weaponControllers[1] != null)
                weaponControllers[1].Activate(input.Aim);
        }

        if (input.Buttons.IsSet(InputButtons.LeftBack))
        {
            if (weaponControllers[2] != null)
                weaponControllers[2].Activate(input.Aim);
        }

        if (input.Buttons.IsSet(InputButtons.RightBack))
        {
            if (weaponControllers[3] != null)
                weaponControllers[3].Activate(input.Aim);
        }
    }
}