using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int initialHealth = 100;
    [SerializeField] ParticleSystem deathVFX;

    [SerializeField] int health; //serialized for debugging

    private void Start()
    {
        health = initialHealth;
    }

    public void IncHealth(int amt)
    {
        health += amt;
    }

    public void DecHealth(int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            DestroyRoutine();
        }
    }

    public void DestroyRoutine()
    {
        Destroy(gameObject);

        Destroy(
            Instantiate(deathVFX, transform.position, Quaternion.identity),
            1f);
    }
}
