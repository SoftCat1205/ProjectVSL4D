using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;

    protected PlayerMovement pm;
    private float currentCooldown;

    void Awake()
    {
        pm = PlayerMovement.Instance;
    }

    protected virtual void Start()
    {
        currentCooldown = weaponData.CooldownDuration;
    }

    protected virtual void FixedUpdate()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
