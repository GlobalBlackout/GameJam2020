using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float TimeBetweenShoot = 10;

    private float TimeLeft;
    private float _sphereRadius;

    private void Start()
    {
        _sphereRadius = GetComponent<CircleCollider2D>().radius;
        TimeLeft = TimeBetweenShoot;
    }

    void Update()
    {
        TimerForShoot();
    }

    private void TimerForShoot()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            ShootNewBullet();
            TimeLeft = TimeBetweenShoot;
        }
    }

    private void ShootNewBullet()
    {
        Vector3 positionToSpown = GetPositionToSpawn();
        Instantiate(BulletPrefab, positionToSpown, Quaternion.identity);
    }

    private Vector3 GetPositionToSpawn()
    {
        float x = Random.Range(-_sphereRadius, _sphereRadius);

        return new Vector3(x, GetYValue(x), 0);
    }

    private float GetYValue(float x)
    {
        return Mathf.Sqrt(Mathf.Pow(_sphereRadius, 2) - Mathf.Pow(x, 2)) + transform.position.y;
    }
}
