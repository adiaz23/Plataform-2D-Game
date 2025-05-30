using UnityEngine;

public class Bee : Enemy
{

    private Animator animator;
    private HealthSystem healthSystem;

    private bool isActive = false;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        base.Start();
    }

    protected void Update()
    {
        if (healthSystem.GetLives() <= 0 && !isActive)
        {
            healthSystem.StartDeadAnimation(animator);
            isActive = true;
        }
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
}
