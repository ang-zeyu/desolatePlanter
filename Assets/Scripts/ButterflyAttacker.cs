using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAttacker : MonoBehaviour
{
    //Cached reference
    Attacker attacker;
    Animator animator;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender collidedDefender = collision.gameObject.GetComponent<Defender>();

        if (collidedDefender)
        {
            DefenderShooter shooter = collision.gameObject.GetComponent<DefenderShooter>();

            if (shooter)
            {
                attacker.SetTargetAndStartAttack(collidedDefender);
            }
            else
            {
                InitiateFlySequence();
            }
        }
    }

    private void InitiateFlySequence()
    {
        GetComponent<Attacker>().ToggleWalk();
        animator.SetBool("doFlyOver", true);
    }

    public void DeactivateFlySequence()
    {
        animator.SetBool("doFlyOver", false);
    }

    public void SetPositionToChild()
    {
        transform.position = transform.GetChild(0).transform.position;
        GetComponent<Attacker>().ToggleWalk();
    }
}
