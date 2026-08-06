using UnityEngine;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(EnemyStats))]
public class EnemyMovement : MonoBehaviour
{
    EnemyStats es;

    void Start()
    {
        es = GetComponent<EnemyStats>();
    }

    void FixedUpdate()
    {

    }
}
