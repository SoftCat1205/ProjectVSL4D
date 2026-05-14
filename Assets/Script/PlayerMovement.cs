using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Reference
    private Rigidbody2D rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [HideInInspector] public Vector2 moveInput;
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
        moveInput = value.Get<Vector2>();

        if (moveInput.x != 0)
        {
            lastX = moveInput.x;
        }

        if (moveInput.y != 0)
        {
            lastY = moveInput.y;
        }
    }

    void Move()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }
}
