using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack : MonoBehaviour
{
    public Sprite LowCrack;
    public Sprite BigCrack;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = LowCrack;
    }

    public void SecondHit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = BigCrack;
    }
}
