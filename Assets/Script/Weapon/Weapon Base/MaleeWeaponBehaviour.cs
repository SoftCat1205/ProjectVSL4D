using System;
using UnityEngine;

public class MaleeWeaponBehaviour : MonoBehaviour
{
    public float destoryAfterSeconds;
    protected PlayerMovement pm;

    protected virtual void Awake()
    {
        pm = PlayerMovement.Instance;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destoryAfterSeconds);
    }
}