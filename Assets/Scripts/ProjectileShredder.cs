using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShredder : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            Destroy(collision.gameObject);
        }
    }
}
