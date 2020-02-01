using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _bulletRB;
    private float _startXPosition;
    private float _startYPosition;

    private float _bulletSpeed = 500;
    void Start()
    {
        _startXPosition = transform.position.x;
        _startYPosition = transform.position.y;
        _bulletRB = GetComponent<Rigidbody2D>();

        Shoot();
    }

    private void Shoot()
    {
        Vector2 ShootingVector = GetDirectionForShooting();

        _bulletRB.AddForce(ShootingVector * _bulletSpeed);
    }

    private Vector2 GetDirectionForShooting()
    {
        return new Vector2(Random.Range(-10, 10) - _startXPosition, -_startYPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Brick")
            Destroy(collision.gameObject);

        // if (collision.gameObject.tag == "Brick")
        //     collision.gameObject.GetComponent<Brick>().DropOneLife();

        Destroy(this.gameObject);
    }
}
