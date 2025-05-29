using UnityEngine;

public class Boar : Enemy
{

    protected Animator animator;
    protected HealthSystem healthSystem;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        base.Start();
    }

    protected override void EnemyDetected(Collider2D other)
    {
        animator.SetBool("running", true);
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
