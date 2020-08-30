using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public LayerMask WhatIsGround;
    public float JumpForce;
    public float DownForce;

    private Rigidbody2D _rb;
    private Transform _feetPos;

    private const float GROUNDCHECK_RADIUS = 0.4f;

    public float JumpTimeCounter;
    public float MaxJumpTime = 0.6f;

    private float _jumpBufferCounter;
    private float _jumpBufferTime = 0.2f;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _feetPos = gameObject.GetComponentInChildren<Transform>();
        _jumpBufferCounter = _jumpBufferTime;
    }

    private void Update()
    {
        if (canHoldToJump())
        {
            JumpTimeCounter -= Time.deltaTime;
        }
        if (isGrounded())
        {
            JumpTimeCounter = MaxJumpTime;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            goDownImmideately();
        }
        jumpBuffer();
    }
    private void FixedUpdate()
    {
        if (canInitialJump())
            jump(JumpForce*Time.fixedDeltaTime);
        if (canHoldToJump())
        {
            jump(30f * JumpForce * Time.fixedDeltaTime);
        }
    }
    private void jump(float speedOfJump)
    {
        _rb.velocity = new Vector2(_rb.velocity.x, speedOfJump);
    }
    private bool isGrounded()//Is player grounded
    {
        return Physics2D.OverlapCircle(_feetPos.position, GROUNDCHECK_RADIUS, WhatIsGround);
    }
    private void jumpBuffer()//Has player pressed button just before landing
    {
        if (Input.GetKeyDown(KeyCode.K))
            _jumpBufferCounter = _jumpBufferTime;
        _jumpBufferCounter -= Time.deltaTime;
    }
    private bool canInitialJump()//Has player buffered the jump and is he grounded
    {
        if (_jumpBufferCounter > 0f && isGrounded())
            return true;
        else
            return false;
    }

    private bool canHoldToJump()//Is player holding the jump button and can it jump
    {
        return Input.GetKey(KeyCode.K) && JumpTimeCounter >= 0f;
    }
    private void goDownImmideately()//Give player -y velocity for faster landing
    {
        _rb.velocity = Vector2.down * DownForce;
    }
}
