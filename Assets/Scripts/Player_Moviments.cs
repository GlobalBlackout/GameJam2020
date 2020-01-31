using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moviments : MonoBehaviour
{

    public Rigidbody2D Rb;
    public float Speed = 20f;
    public float JumpForce = 1f;
    public float Gravity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Speed * 0.01f);
        }

    }

  }
