using UnityEngine;

public class Bee : Enemy
{

    private Animator animator;
    private HealthSystem healthSystem;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        base.Start();
    }

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

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (healthSystem.GetLives() <= 0)
        {
            healthSystem.StartDeadAnimation(animator);
        }
    }
}
