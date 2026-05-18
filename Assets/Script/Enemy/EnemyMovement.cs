using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;


    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerMovement.Instance.transform.position, moveSpeed * Time.deltaTime);
    }
}
