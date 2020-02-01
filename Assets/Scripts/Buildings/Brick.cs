﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject CrackTexturePrefab;
    public bool BrickDed = false;
    
    [Range(1, 3)]
    public int BrickLives = 3;
    [Range(0, 250)]
    public float BreakForce = 15;
    [Range(0, 250)]
    public float BreakTorque = 15;

    private int _brickLives;

    private void Start()
    {
        GetNearBricks();
        _brickLives = BrickLives;
    }

    private void GetNearBricks()
    {
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right);
        if (rightHit && (rightHit.collider.gameObject.tag == "Brick" || rightHit.collider.gameObject.tag == "Grownd_Brick"))
        {
            var Join = gameObject.AddComponent<HingeJoint2D>();
            Join.connectedBody = rightHit.collider.gameObject.GetComponent<Rigidbody2D>();
            Join.breakForce = BreakForce;
            Join.breakTorque = BreakTorque;
        }

        RaycastHit2D downHit = Physics2D.Raycast(transform.position, Vector2.down);
        if (downHit && (downHit.collider.gameObject.tag == "Brick" || downHit.collider.gameObject.tag == "Grownd_Brick"))
        {
            var Join = gameObject.AddComponent<HingeJoint2D>();
            Join.connectedBody = downHit.collider.gameObject.GetComponent<Rigidbody2D>();
            Join.breakForce = BreakForce;
            Join.breakTorque = BreakTorque;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameManager.UpdateBrickStatus();
            BrickDed = true;
            Destroy(gameObject);
        }
    }

    public void DropOneLife()
    {
        _brickLives -= 1;
        if (_brickLives <= 0)
            Destroy(gameObject);
        
        if(_brickLives == BrickLives - 1)
        {
            Instantiate(CrackTexturePrefab, transform);
            return;
        }

        GetComponentInChildren<Crack>().SecondHit();
    }
}
