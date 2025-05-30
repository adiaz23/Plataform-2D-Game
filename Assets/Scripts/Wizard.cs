using System.Collections;
using UnityEngine;

public class Wizard : Enemy
{

    [SerializeField] private GameObject fireBall;
    [SerializeField] private float attackTime;

    private HealthSystem healthSystem;

    private Transform spawnFireBallsPoint;
    private Animator animator;
    private bool isActive = false;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        spawnFireBallsPoint = transform.GetChild(1);
    }

    void Update()
    {
        if (healthSystem.GetLives() <= 0 && !isActive)
        {
            healthSystem.StartDeadAnimation(animator);
            isActive = true;
        }
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
}
