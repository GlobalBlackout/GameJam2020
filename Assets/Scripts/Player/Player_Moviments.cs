using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moviments : MonoBehaviour
{

    public float Speed = 20f;

    public float JetpackForce = 1f;
    public float MaxVelocity = 10;
    public float Acceleration = 50;
    public float RemaningForce = 3;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        JatpackMovement();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))       
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        

        if (Input.GetKey(KeyCode.D))     
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }

    private void JatpackMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (_rb.velocity.y > MaxVelocity)
                _rb.velocity = new Vector2(_rb.velocity.x, MaxVelocity);
            else
                _rb.AddForce(Vector2.up * Acceleration);
        }

        if (Input.GetKeyUp(KeyCode.W))
            _rb.velocity = new Vector2(_rb.velocity.x, RemaningForce);
    }
}
