using Fusion;
using UnityEngine;

public class MPlayerFacing : NetworkBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Facing(Vector2 aimPosition)
    {
        float direction = aimPosition.x - transform.position.x;

        if (direction > 0)
            FaceRight();
        else if (direction < 0)
            FaceLeft();
    }

    private void FaceRight()
    {
        spriteRenderer.flipX = false;
    }

    private void FaceLeft()
    {
        spriteRenderer.flipX = true;
    }
}
