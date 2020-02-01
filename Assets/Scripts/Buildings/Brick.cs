using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject CrackTexturePrefab;
    public bool BrickDed = false;
    
    [Range(1, 3)]
    public int BrickLives = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!BrickDed)
        {
            if (collision.gameObject.tag == "Ground")
            {
                GameManager.UpdateBrickStatus();
                BrickDed = true;
                Destroy(gameObject);
            }
        }
    }

    public void DropOneLife()
    {
        BrickLives -= 1;
        if (BrickLives <= 0)
            Destroy(gameObject);
        
        if(BrickLives == 2)
        {
            Instantiate(CrackTexturePrefab, transform);
            return;
        }

        GetComponentInChildren<Crack>().SecondHit();
    }
}
