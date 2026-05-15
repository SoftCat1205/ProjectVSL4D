using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Reference
    private Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [HideInInspector] public Vector2 moveDir;
    [HideInInspector] public float lastX; //Stores the latest X vector input 
    [HideInInspector] public float lastY; //Stores the latest Y vector input

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();

        if (moveDir.x != 0)
        {
            lastX = moveDir.x;
        }

        if (moveDir.y != 0)
        {
            lastY = moveDir.y;
        }
    }

    void Move()
    {
        rb.linearVelocity = moveDir.normalized * moveSpeed;
    }
}
