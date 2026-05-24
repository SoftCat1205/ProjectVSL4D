using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnemyMovement : MonoBehaviour
{
    EnemyStats es;

    void Start()
    {
        es = GetComponent<EnemyStats>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerMovement.Instance.transform.position, es.currentMoveSpeed * Time.deltaTime);
    }
}
