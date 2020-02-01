using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool BrickDed = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!BrickDed)
        {
            if (collision.gameObject.tag == "Ground")
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                BrickDed = true;
            }

            if (collision.gameObject.tag == "Brick")
                if (collision.gameObject.GetComponent<Brick>().BrickDed == true)
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                    BrickDed = true;
                }
        }
    }
}
