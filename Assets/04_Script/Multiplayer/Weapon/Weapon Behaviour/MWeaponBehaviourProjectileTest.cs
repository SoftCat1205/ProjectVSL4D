using Fusion;
using UnityEngine;

public class MWeaponBehaviourProjectileTest : NetworkBehaviour
{
    [SerializeField] private float projectileSpeed = 25f;
    [SerializeField] private Rigidbody2D rigidBody;

    private Vector2 direction;

    public void Initialize(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    public override void FixedUpdateNetwork()
    {
        rigidBody.MovePosition(rigidBody.position + projectileSpeed * Time.deltaTime * direction.normalized);
    }
}