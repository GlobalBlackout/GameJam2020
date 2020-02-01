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

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        JatpackMovement();
        Move();
    }

    private void Move()
    {
        float inputType = Input.GetAxis("Horizontal");
      
         if (inputType != 0)
            if (Mathf.Abs(_rb.velocity.x) < Speed)
                _rb.velocity = new Vector2(MaxVelocity * inputType, _rb.velocity.y);
            else
                _rb.AddForce(Vector2.left * Acceleration * inputType);
       
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
}
