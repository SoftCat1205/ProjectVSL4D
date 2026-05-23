using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, PlayerMovement.Instance.transform.position, enemyData.MoveSpeed * Time.deltaTime);
    }
}
