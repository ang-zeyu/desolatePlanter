using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject projectileFirer;

    //Cached reference
    EnemySpawner enemySpawner;

    Defender defender;
    Animator animator;
    GameObject projectileParent;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        defender = GetComponent<Defender>();
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void FixedUpdate()
    {
        FireIfLaneOccupied();
    }

    private void FireIfLaneOccupied()
    {
        animator.SetBool("hasEnemyInLane",
            enemySpawner.GetAttackersInLane(defender.GetY()) > 0);
    }

    public void Fire()
    {
        Projectile p = Instantiate(projectile, projectileFirer.transform.position, projectile.transform.rotation);
        p.transform.parent = projectileParent.transform;
    }
}
