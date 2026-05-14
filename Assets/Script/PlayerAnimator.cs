using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveInput.x != 0 || pm.moveInput.y != 0)
        {
            am.SetBool("Move", true);

            SpiteDirection();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpiteDirection()
    {
        if (pm.lastX < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
