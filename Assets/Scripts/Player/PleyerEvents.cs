using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PleyerEvents : MonoBehaviour
{
    public float TimeStunn = 3;
    [HideInInspector]
    public bool Stunned = false;

    private static float _timeTowin;

    public Animator anim;
    public GameObject go;

    private void Start()
    {
        anim = go.GetComponent<Animator>();
        _timeTowin = TimeStunn;
    }

    public void StunAnim()
    {
        anim.SetBool("Stunned", true);
    }

    public void IdleAnim()
    {
        anim.SetBool("Stunned", false);
    }

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
            StunAnim();
        }
    }

    private void TimeForStunn()
    {
        _timeTowin -= Time.deltaTime;
        if (_timeTowin < 0)
        {
            _timeTowin = TimeStunn;
            Stunned = false;
            IdleAnim();
        }
    }
}
