using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(WeaponController))]
public class Weapon : MonoBehaviour
{
    public string WeaponName { get; private set; }
    public int Level { get; private set; }

    public WeaponController Controller { get; private set; }

    private void Awake()
    {
        Controller = GetComponent<WeaponController>();
    }

    public void LevelUp()
    {
        Level++;
    }
}
