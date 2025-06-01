using UnityEngine;

public class Bee : Enemy
{
    protected override void EnemyDetected(Collider2D other)
    {
        StopAllCoroutines();
        StartCoroutine(FollowPlayer(other));
    }

    protected override void Attack(Collider2D other)
    {
        animator.SetTrigger("Attack");
        base.Attack(other);
    }
}
