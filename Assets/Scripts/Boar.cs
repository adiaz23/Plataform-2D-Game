using UnityEngine;

public class Boar : Enemy
{

    protected Animator animator;
    protected HealthSystem healthSystem;

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
        animator.SetBool("running", true);
    }
}
