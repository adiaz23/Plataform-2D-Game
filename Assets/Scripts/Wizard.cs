using System.Collections;
using UnityEngine;

public class Wizard : Enemy
{

    [SerializeField] private GameObject fireBall;
    [SerializeField] private float attackTime;

    private HealthSystem healthSystem;

    private Transform spawnFireBallsPoint;
    private Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        spawnFireBallsPoint = transform.GetChild(1);
    }

    protected override void EnemyDetected(Collider2D other)
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (gameObject)
        {
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(attackTime);
        }
    }

    //Animation event
    private void shootFireBall()
    {
        Instantiate(fireBall, spawnFireBallsPoint.position, transform.rotation);
    }

     protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (healthSystem.GetLives() <= 0)
        {
            healthSystem.Destroy();
        }
    }
    
}
