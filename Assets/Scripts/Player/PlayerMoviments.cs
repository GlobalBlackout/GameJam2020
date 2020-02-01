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

        Debug.Log(_rb.velocity);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))      
            if (_rb.velocity.x < -Speed)
                _rb.velocity = new Vector2(-MaxVelocity, _rb.velocity.y);
            else
                _rb.AddForce(Vector2.left * Acceleration);      
        else if (Input.GetKeyUp(KeyCode.A))
            _rb.velocity = new Vector2(-JetpackInertial, _rb.velocity.y);

        if (Input.GetKey(KeyCode.D))       
            if (_rb.velocity.x > Speed)
                _rb.velocity = new Vector2(MaxVelocity, _rb.velocity.y);
            else
                _rb.AddForce(Vector2.right * Acceleration);
        
        else if (Input.GetKeyUp(KeyCode.D))
            _rb.velocity = new Vector2(JetpackInertial, _rb.velocity.y);
    }

    private void JatpackMovement()
    {
        if (Input.GetKey(KeyCode.W))
            if (_rb.velocity.y > MaxVelocity)
                _rb.velocity = new Vector2(_rb.velocity.x, MaxVelocity);
            else
                _rb.AddForce(Vector2.up * Acceleration);
        else if (Input.GetKeyUp(KeyCode.W))
            _rb.velocity = new Vector2(_rb.velocity.x, JetpackInertial);
    }
}
