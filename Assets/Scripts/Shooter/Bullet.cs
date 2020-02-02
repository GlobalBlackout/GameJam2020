using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject WarningSignal;

    [Range(5, 10)]
    public float BombRange = 8;
    [Range(100, 500)]
    public float _bulletSpeed = 500;

    private ParticleSystem BulletParticles;
    private Rigidbody2D _bulletRB;
    private float _startXPosition;
    private float _startYPosition;

    void Start()
    {
        _startXPosition = transform.position.x;
        _startYPosition = transform.position.y;
        _bulletRB = GetComponent<Rigidbody2D>();
        BulletParticles = GameObject.Find("BulletPar").GetComponent<ParticleSystem>();

        Shoot();
    }

    private void Shoot()
    {
        Vector2 ShootingVector = GetDirectionForShooting();

        PutAllert(ShootingVector);

        float angle = Mathf.Atan2(ShootingVector.y, ShootingVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _bulletRB.AddForce(ShootingVector * _bulletSpeed);
    }

    private void PutAllert(Vector2 direction)
    {
        LayerMask mask = LayerMask.GetMask("MiniMap");

        RaycastHit2D minimapHit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, mask);
        if (minimapHit)
        {
            Destroy(GameObject.Find("WorningSign(Clone)"));
            Instantiate(WarningSignal, new Vector3(minimapHit.point.x, minimapHit.point.y, 0), Quaternion.identity);
        }
    }

    private Vector2 GetDirectionForShooting()
    {
        return new Vector2(Random.Range(-BombRange, BombRange) - _startXPosition, -_startYPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<SoundManager>().PlayExplosion();

        if (collision.gameObject.tag == "Player_Brick")
            Destroy(collision.gameObject);

        if (collision.gameObject.tag == "Brick")
            collision.gameObject.GetComponent<Brick>().DropOneLife();

        BulletParticles.gameObject.transform.position = transform.position;
        BulletParticles.Play();
        Destroy(gameObject);
    }

}
