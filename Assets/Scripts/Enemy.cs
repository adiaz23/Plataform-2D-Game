using System.Collections;
using Mono.Cecil.Cil;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField] protected Transform[] patrolPoints;
    [SerializeField] protected float speedPatrol;

    [Header("Attack System")]
    [SerializeField] protected int attackDamage;
    
    protected Vector3 actualDestination;
    protected HealthSystem healthSystem;
    protected Animator animator;
    protected int actualIndex = 0;
    protected bool canFollowPlayer = true;
    private bool isActive = false;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
        actualDestination = patrolPoints[actualIndex].position;
        StartCoroutine(Patrol());
    }

    protected virtual void Update()
    {
        if (healthSystem.GetLives() <= 0 && !isActive)
        {
            healthSystem.StartDeadAnimation(animator);
            isActive = true;
        }
    }

    protected IEnumerator Patrol()
    {
        yield return new WaitForEndOfFrame();

        while (gameObject)
        {
            while (transform.position != actualDestination)
            {
                float steps = speedPatrol * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, actualDestination, steps);
                yield return null;
            }
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        actualIndex++;
        if (actualIndex >= patrolPoints.Length)
        {
            actualIndex = 0;
        }
        actualDestination = patrolPoints[actualIndex].position;
        RotateToDestination(actualDestination);
    }

    private void RotateToDestination(Vector3 actualPosition)
    {
        if (actualPosition.x < transform.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    protected IEnumerator FollowPlayer(Collider2D player)
    {
        while (gameObject && player != null)
        {
            float steps = speedPatrol * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, steps);
            RotateToDestination(player.transform.position);
            yield return null;
        }
    }

    //Animation event
    protected virtual void Attack(Collider2D player)
    {
        if (player != null)
        {
            HealthSystem healthSystem = player.GetComponent<HealthSystem>();
            healthSystem.GetDamage(attackDamage);
        }

    }

    protected abstract void EnemyDetected(Collider2D other);

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerDetection"))
        {
            EnemyDetected(other);
        }
        else if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            Attack(other);
        }
    }
}