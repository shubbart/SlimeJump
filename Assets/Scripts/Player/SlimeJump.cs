using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Airborne,
    Sticking,
    Damaged,
    Dead
}

public class SlimeJump : MonoBehaviour
{
    public PlayerState playerState = PlayerState.Idle;
    public float forceMultiplier = 1;

    Vector2 aim;
    Rigidbody2D rbody;
    float force;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (playerState == PlayerState.Idle)
        {
            if (Input.GetMouseButton(0))
            {
                aim = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                force = Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) * forceMultiplier;
            }
            if (Input.GetMouseButtonUp(0))
            {
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
