using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidedObject = collision.gameObject;
        Attacker collidedAttacker = collidedObject.GetComponent<Attacker>();

        if (collidedAttacker)
        {
            collidedObject.GetComponent<Health>().DecHealth(damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
