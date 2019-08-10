using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Prepping,
    Airborne,
    Sticking,
    Damaged,
    Dead
}

public class SlimeJump : MonoBehaviour
{
    public PlayerState playerState = PlayerState.Idle;
    [HideInInspector] public float maxForce = 1;
    Animator anim;

    Vector2 aim;
    Rigidbody2D rbody;
    float force;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (playerState == PlayerState.Idle || playerState == PlayerState.Prepping)
        {

            if (Input.GetMouseButton(0))
            {
                if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= 0)
                {
                    transform.localRotation = new Quaternion(0, -180, 0, 0);
                }
                else
                {
                    transform.localRotation = new Quaternion(0, 0, 0, 0);
                }

                playerState = PlayerState.Prepping;
                anim.SetBool("IsPrepping", true);
                aim = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                force = Mathf.Clamp01(Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)));              
            }
            if (Input.GetMouseButtonUp(0))
            {
                force *= maxForce;
                anim.SetBool("IsPrepping", false);
                rbody.AddForce(aim * force, ForceMode2D.Impulse);
                playerState = PlayerState.Airborne;
            }
        }
        else if (playerState == PlayerState.Airborne)
        {
            if (rbody.velocity.y == 0)
            {
                playerState = PlayerState.Idle;
            }
        }
    }
}
