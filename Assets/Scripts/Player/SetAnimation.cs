using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    public SpriteRenderer Player;
    public Sprite Stunned;

    public Animator anim;

    public void StunAnim()
    {
        anim.SetBool("Stunned", true);
    }

    public void IdleAnim()
    {
        anim.SetBool("Stunned", false);
    }
}
