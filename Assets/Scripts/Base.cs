using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] int livesPerEnemyPassed = 1;

    //Cached reference
    Lives livesDisplay;

    void Start()
    {
        livesDisplay = FindObjectOfType<Lives>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            livesDisplay.DecLives(livesPerEnemyPassed);
            attacker.GetComponent<Health>().DestroyRoutine();
        }
    }
}
