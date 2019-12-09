using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

    [SerializeField] [Range(0.01f, 0.1f)] float walkSpeed = 0.01f;
    [SerializeField] int damage = 30;

    bool doWalk = true;

    float fallSpeed;
    int laneNumber;

    Defender target;

    //Cached reference
    Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        target = null;
    }

    public void AttackTarget()
    {
        if (!target)
        {
            ToggleWalk();
            animator.SetBool("doAttack", false);

            return;
        }

        target.GetComponent<Health>().DecHealth(damage);
    }

    public void SetTargetAndStartAttack(Defender target)
    {
        this.target = target;
        ToggleWalk();
        animator.SetBool("doAttack", true);
    }

    private void FixedUpdate()
    {
        if (doWalk)
        {
            transform.Translate(Vector3.left * walkSpeed);
        }
    }

    public void SetMovementSpeed(float walkSpeed)
    {
        this.walkSpeed = walkSpeed;
    }

    public void ToggleWalk()
    {
        doWalk = !doWalk;
    }

    public int GetLane()
    {
        return laneNumber;
    }

    public void SetLane(int number)
    {
        laneNumber = number;
    }

    private void OnDestroy()
    {
        EnemySpawner eSpawner = FindObjectOfType<EnemySpawner>();
        eSpawner.DecAttackersInLane(laneNumber);
    }

}
