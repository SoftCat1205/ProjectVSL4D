using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    public int pierce;


    protected PlayerMovement pm;
    private float currentCooldown;

    void Awake()
    {
        pm = PlayerMovement.Instance;
    }

    protected virtual void Start()
    {
        currentCooldown = cooldownDuration;
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
        currentCooldown = cooldownDuration;
    }
}
