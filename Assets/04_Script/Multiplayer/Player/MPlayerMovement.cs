using Fusion;
using UnityEngine;

public class MPlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;

    [Header("Stats")]
    [SerializeField] private float playerSpeed = 5f;

    // public void Move(Vector2 input)
    // {
    //     rigidBody.MovePosition(rigidBody.position + playerSpeed * Time.deltaTime * input.normalized);
    // }
    public void Move(Vector2 input)
    {
        Vector2 oldPos = rigidBody.position;
        Vector2 newPos = oldPos + input.normalized * playerSpeed * Time.deltaTime;

        rigidBody.MovePosition(newPos);

        Debug.Log($"Old: {oldPos} | New: {newPos} | Current: {rigidBody.position}");
    }
}