using UnityEngine;

public class Bee : Enemy
{

    private Animator anim;

    protected override void Start()
    {
        anim = GetComponent<Animator>();
        base.Start();
    }

    protected override void EnemyDetected(Collider2D other)
    {
        StopAllCoroutines();
        StartCoroutine(FollowPlayer(other));
    }

    protected override void Attack(Collider2D other)
    {
        anim.SetTrigger("Attack");
        base.Attack(other);
    }
}
