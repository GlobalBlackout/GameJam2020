using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviments : MonoBehaviour
{
    [Header("Player")]
    [Range(1, 20)]
    public float Speed = 10f;
    [Range(0, 5)]
    public float PlayerInertial = 3;

    [Space(1)]

    [Header("Jetpack")]
    [Range(1, 20)]
    public float MaxVelocity = 10;
    [Range(1, 100)]
    public float Acceleration = 50;
    [Range(0, 5)]
    public float JetpackInertial = 3;

    public SpriteRenderer PlayerSpriteRender;

    private Rigidbody2D _rb;
    private PleyerEvents _pe;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _pe = GetComponent<PleyerEvents>();
    }
    
    private void FixedUpdate()
    {
        if (!_pe.Stunned)
        {
            JatpackMovement();
            Move();
        }
    }

    private void Move()
    {
        float inputType = Input.GetAxis("Horizontal");

        PlayerFlip(inputType);

        if (inputType != 0 || Mathf.Abs(_rb.velocity.x) > Speed)
        {
            if (Mathf.Abs(_rb.velocity.x) < Speed)
                _rb.velocity = new Vector2(MaxVelocity * inputType, _rb.velocity.y);
            else
                _rb.AddForce(Vector2.left * Acceleration * inputType);

            if (Mathf.Abs(_rb.velocity.x) > Speed)
                _rb.velocity = new Vector2(MaxVelocity * inputType, _rb.velocity.y);
        }
    }

    private void JatpackMovement()
    {
        float inputType = Input.GetAxis("Vertical");

        if (inputType != 0)
            if (_rb.velocity.y > MaxVelocity * inputType)
                _rb.velocity = new Vector2(_rb.velocity.x, MaxVelocity * inputType);
            else
                _rb.AddForce(Vector2.up * Acceleration);
        else if(_rb.velocity.y > 0)
            _rb.velocity = new Vector2(_rb.velocity.x, JetpackInertial * inputType);
    }

    private void PlayerFlip(float inputType)
    {
        if(inputType > 0)
            PlayerSpriteRender.flipX = true;
        else if(inputType < 0)
            PlayerSpriteRender.flipX = false;
    }
}
