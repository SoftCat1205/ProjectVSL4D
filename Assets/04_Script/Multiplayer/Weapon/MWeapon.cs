using Fusion;
using UnityEngine;

public class MWeapon : NetworkBehaviour
{
    public virtual void Activate()
    {
        Debug.Log("Weapon Activated!");
    }
}