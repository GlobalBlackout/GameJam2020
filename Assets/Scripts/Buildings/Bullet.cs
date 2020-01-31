using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Target;

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
        return new Vector2(Target.transform.position.x - _startXPosition, Target.transform.position.y - _startYPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
