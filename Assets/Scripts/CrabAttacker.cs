using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generic stop and hit attacker abstraction
public class CrabAttacker : MonoBehaviour
{
    //Cached reference
    Attacker attacker;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender collidedDefender = collision.gameObject.GetComponent<Defender>();

        if (collidedDefender)
        {
            attacker.SetTargetAndStartAttack(collidedDefender);
        }
    }
}
