using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerEvents : MonoBehaviour
{
    public float TimeStunn = 3;
    [HideInInspector]
    public bool Stunned = false;

    private static float _timeTowin;

    private void Update()
    {
        if (Stunned)
            TimeForStunn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet" && !Stunned)
        {
            Stunned = true;
        }
    }

    private void TimeForStunn()
    {
        _timeTowin -= Time.deltaTime;
        if (_timeTowin < 0)
        {
            _timeTowin = TimeStunn;
            Stunned = false;
        }
    }
}
