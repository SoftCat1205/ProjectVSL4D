using UnityEngine;

public class MPlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [Header("Stats")]
    [SerializeField] private float playerSpeed = 5f;

    public void Move(Vector2 input)
    {
        rigidBody.MovePosition(rigidBody.position + playerSpeed * Time.deltaTime * input.normalized);
    }
}