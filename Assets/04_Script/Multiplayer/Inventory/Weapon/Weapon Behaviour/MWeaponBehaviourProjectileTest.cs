using Fusion;
using UnityEngine;

public class MWeaponBehaviourProjectileTest : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    private Vector2 _direction;
    private float _projectileSpeed;
    private float _lifetime = 3f;
    private float _damage;

    public void Initialize(Vector2 direction, WeaponScriptableObject weaponData)
    {
        _direction = direction.normalized;
        _projectileSpeed = weaponData.Speed;
        _lifetime = weaponData.Lifetime;
        _damage = weaponData.Damage;

        Invoke(nameof(DestoryProjectile), _lifetime);
    }

    private void DestoryProjectile()
    {
        Runner.Despawn(Object);
    }

    public override void FixedUpdateNetwork()
    {
        rigidBody.MovePosition(rigidBody.position + _projectileSpeed * Time.deltaTime * _direction.normalized);
    }
}