using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool BrickDed = false;
    public int BrickLives = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!BrickDed)
        {
            if (collision.gameObject.tag == "Ground")
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                GameManager.UpdateBrickStatus();
                BrickDed = true;
                // Destroy(this.gameObject);
            }

            if (collision.gameObject.tag == "Brick")
                if (collision.gameObject.GetComponent<Brick>().BrickDed == true)
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    GameManager.UpdateBrickStatus();
                    BrickDed = true;
                }
        }
    }

    public void DropOneLife()
    {
        BrickLives -= 1;
        if (BrickLives <= 0)
            Destroy(gameObject);
        Color newColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color(newColor.r, newColor.g - 0.5f, newColor.b);
    }
}
